using System.Collections.Generic;
using AnyJob.Package.Core.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyJob.Package.Impl.FileSystem.UnitTest
{
    [TestClass]
    public class FileSystemPackageProviderServiceTest : PackageProviderServiceTest
    {
        public FileSystemPackageProviderServiceTest() : base(new Dictionary<string, object>
        {
            ["FileProvider:RootDir"] = "../../../../../example/packs"
        })
        {

        }
    }
}
