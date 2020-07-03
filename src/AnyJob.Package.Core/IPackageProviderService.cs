using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AnyJob.Package.Core
{
    public interface IPackageProviderService
    {
        Task<Dictionary<string, List<PackageVersionInfo>>> ListPackages();
        Task<PackageVersionInfo> GetLatestPackageVersion(string packageName);
        Task<List<PackageFileInfo>> GetPackageFiles(string packageName, string version);
        Task<List<ActionInfo>> GetActions(string packageName, string version);
        Task UploadPackage(PackageVersionContentInfo contentInfo);

    }
    public class PackageVersionContentInfo:PackageVersionInfo
    {
        public string Name { get; set; }
        public Stream ZipStream { get; set; }
    }

    public class PackageVersionInfo
    {
        public string Version { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }

    }
    public class PackageFileInfo
    {
        public string Path { get; set; }
        public long FileSize { get; set; }
        public string FileHash { get; set; }
        public string FileHashType { get; set; }
        public string FileUrl { get; set; }
    }
    public class ActionInfo
    {
        public string Kind { get; set; }

        public string Description { get; set; }

        public string EntryPoint { get; set; }

        public bool Enabled { get; set; }

        public List<string> Tags { get; set; }

        public Dictionary<string, object> Inputs { get; set; }

        public object Output { get; set; }

       
    }


}
