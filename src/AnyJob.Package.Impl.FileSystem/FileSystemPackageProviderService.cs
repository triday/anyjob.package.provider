using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using YS.Knife;

namespace AnyJob.Package.Impl.FileSystem
{
    [ServiceClass(Lifetime = ServiceLifetime.Singleton)]
    public class FileSystemPackageProviderService : IPackageProviderService
    {
        static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        readonly FilePackageProviderOptions filePackageProviderOptions;
        public FileSystemPackageProviderService(FilePackageProviderOptions filePackageProviderOptions)
        {
            this.filePackageProviderOptions = filePackageProviderOptions;
        }
        private bool IsValidVersionDir(string packageDir, string version)
        {
            return Version.TryParse(version, out _);
        }
        private PackageVersionInfo GetPackageVersionInfo(string packageDir, string version)
        {
            var packageFile = Path.Combine(packageDir, version, "pack.json");
            if (File.Exists(packageFile))
            {
                var result = JsonSerializer.Deserialize<PackageVersionInfo>(File.ReadAllText(packageFile));
                result.Version = version;
                return result;
            }
            else
            {
                return new PackageVersionInfo
                {
                    Version = version
                };
            }
        }
        private string CombinUrl(string package, string version, string rpath)
        {
            return Path.Combine(filePackageProviderOptions.BaseUrl, package, version, rpath).Replace('\\', '/');

        }
        private IEnumerable<string> GetAllValidVersions(string packageRootDir)
        {
            string packageName = Path.GetFileName(packageRootDir);
            return from p in Directory.GetDirectories(packageRootDir)
                   let strVersion = Path.GetFileName(p)
                   where IsValidVersionDir(packageRootDir, strVersion)
                   let v = Version.Parse(strVersion)
                   orderby v
                   select strVersion;
        }
        string GetSHA256Hash(string path)
        {
            using (var hash = SHA256.Create())
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    var bytes = hash.ComputeHash(stream);
                    return BitConverter.ToString(bytes).Replace("-", "");
                }
            }

        }
        public Task<List<ActionInfo>> GetActions(string packageName, string version)
        {
            var versionDir = Path.Combine(filePackageProviderOptions.RootDir, packageName, version);
            var actions = from p in Directory.GetFiles(versionDir, "*.meta", SearchOption.TopDirectoryOnly)
                          select JsonSerializer.Deserialize<ActionInfo>(File.ReadAllText(p), JsonSerializerOptions);
            return Task.FromResult(actions.ToList());
        }


        public Task<PackageVersionInfo> GetLatestPackageVersion(string packageName)
        {
            var packageRootDir = Path.Combine(filePackageProviderOptions.RootDir, packageName);
            var latestVersion = GetAllValidVersions(packageRootDir).LastOrDefault();
            if (latestVersion == null)
            {
                return Task.FromResult(default(PackageVersionInfo));
            }
            return Task.FromResult(GetPackageVersionInfo(packageRootDir, latestVersion));
        }



        public Task<Dictionary<string, List<PackageVersionInfo>>> ListPackages()
        {
            var packages = from r in Directory.GetDirectories(filePackageProviderOptions.RootDir)
                           let packageName = Path.GetFileName(r)
                           select new
                           {
                               Name = packageName,
                               Versions = GetAllValidVersions(r).Select(v => GetPackageVersionInfo(r, v)).ToList()
                           };
            var result = packages.ToDictionary(p => p.Name, p => p.Versions);
            return Task.FromResult(result);
        }

        public Task<List<PackageFileInfo>> GetPackageFiles(string packageName, string version)
        {
            var versionDir = Path.Combine(filePackageProviderOptions.RootDir, packageName, version);

            var files = from p in Directory.GetFiles(versionDir, "*", SearchOption.AllDirectories)
                        let rpath = p.Substring(versionDir.Length + 1)
                        select new PackageFileInfo
                        {
                            Path = rpath,
                            FileHashType = "SHA256",
                            FileSize = new FileInfo(p).Length,
                            FileHash = GetSHA256Hash(p),
                            FileUrl = CombinUrl(packageName, version, rpath)
                        };

            return Task.FromResult(files.ToList());
        }



        public Task UploadPackage(PackageVersionContentInfo contentInfo)
        {
            throw new NotImplementedException();
        }
    }
}
