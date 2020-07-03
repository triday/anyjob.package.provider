using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AnyJob.Package.Core;
using Microsoft.AspNetCore.Mvc;

namespace AnyJob.Package.Rest.Api
{
    [Route("packages")]
    public class PackageController : YS.Knife.Rest.Api.ApiBase<IPackageProviderService>, IPackageProviderService
    {
        [HttpGet]
        [Route("{packageName}/{version}/actions")]
        public Task<List<ActionInfo>> GetActions(string packageName, string version)
        {
            return this.Delegater.GetActions(packageName, version);
        }
        [HttpGet]
        [Route("{packageName}/versions/latest")]
        public Task<PackageVersionInfo> GetLatestPackageVersion(string packageName)
        {
            return this.Delegater.GetLatestPackageVersion(packageName);
        }
        [HttpGet]
        [Route("{packageName}/{version}/files")]
        public Task<List<PackageFileInfo>> GetPackageFiles(string packageName, string version)
        {
            return this.Delegater.GetPackageFiles(packageName, version);
        }
        [HttpGet]
        [Route("all")]
        public Task<Dictionary<string, List<PackageVersionInfo>>> ListPackages()
        {
            return this.Delegater.ListPackages();
        }
        [HttpPost]
        public Task UploadPackage(PackageVersionContentInfo contentInfo)
        {
            return this.Delegater.UploadPackage(contentInfo);
        }
    }
}
