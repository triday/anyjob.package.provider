using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyJob.Package.Core.UnitTest
{

    public abstract class PackageProviderServiceTest : YS.Knife.Hosting.KnifeHost
    {
        public PackageProviderServiceTest()
        {
        }
        public PackageProviderServiceTest(IDictionary<string, object> args) : base(args)
        {
        }
        [TestMethod]
        public async Task ShouldContainsExamplesPackageWhenListPackages()
        {
            var service = this.GetService<IPackageProviderService>();
            var packages = await service.ListPackages();

            packages.Should().ContainKey("example");

        }
        [TestMethod]
        public async Task ShouldReturnV001VersionWhenGetLatestExamplesVersion()
        {
            var service = this.GetService<IPackageProviderService>();
            var latestVersion = await service.GetLatestPackageVersion("example");
            latestVersion.Version.Should().Be("0.0.1");
        }

        [TestMethod]
        public async Task ShouldReturnFilesVersionWhenGetExamplePackageFiles()
        {
            var service = this.GetService<IPackageProviderService>();
            var packageFiles = await service.GetPackageFiles("example", "0.0.1");
            packageFiles.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task ShouldReturnActionsWhenGetExamplePackageActions()
        {
            var service = this.GetService<IPackageProviderService>();
            var packageActions = await service.GetActions("example", "0.0.1");
            packageActions.Count.Should().BeGreaterThan(0);
        }
    }
}
