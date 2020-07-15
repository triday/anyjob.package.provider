using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using YS.Knife.Rest.Client;

namespace AnyJob.Package.Impl.Rest.Client
{
    [YS.Knife.ServiceClass]
    public class RestClientPackageProvider : ClientBase, IPackageProviderService
    {
        public RestClientPackageProvider(IHttpClientFactory httpClientFactory, IOptions<ApiServicesOptions> apiServicesOptions) : base(httpClientFactory, apiServicesOptions, "PackageService")
        {
        }

        public Task<List<ActionInfo>> GetActions(string packageName, string version)
        {
            return this.SendHttp<List<ActionInfo>>(
                    new RestApiInfo
                    {
                        Method = HttpMethod.Get,
                        Path = "packages/{packageName}/{version}/actions",
                        Arguments = new List<RestArgument>
                        {
                            new RestArgument("packageName", ArgumentSource.FromRouter, packageName),
                            new RestArgument("version", ArgumentSource.FromRouter, version),
                        }
                    }
                );
        }

        public Task<PackageVersionInfo> GetLatestPackageVersion(string packageName)
        {
            return this.SendHttp<PackageVersionInfo>(
                     new RestApiInfo
                     {
                         Method = HttpMethod.Get,
                         Path = "packages/{packageName}/versions/latest",
                         Arguments = new List<RestArgument>
                         {
                            new RestArgument("packageName", ArgumentSource.FromRouter, packageName),
                         }
                     }
                 );
        }

        public Task<List<PackageFileInfo>> GetPackageFiles(string packageName, string version)
        {
            return this.SendHttp<List<PackageFileInfo>>(
                     new RestApiInfo
                     {
                         Method = HttpMethod.Get,
                         Path = "packages/{packageName}/{version}/files",
                         Arguments = new List<RestArgument>
                         {
                            new RestArgument("packageName", ArgumentSource.FromRouter, packageName),
                            new RestArgument("version", ArgumentSource.FromRouter, version),
                         }
                     }
                 );
        }

        public Task<Dictionary<string, List<PackageVersionInfo>>> ListPackages()
        {
            return this.SendHttp<Dictionary<string, List<PackageVersionInfo>>>(
                    new RestApiInfo
                    {
                        Method = HttpMethod.Get,
                        Path = "packages/all",
                        Arguments = new List<RestArgument>
                        {
                        }
                    }
                );
        }

        public Task UploadPackage(PackageVersionContentInfo contentInfo)
        {
            throw new NotImplementedException();
        }
    }
}
