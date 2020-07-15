using System.Collections.Generic;
using AnyJob.Package.Core.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyJob.Package.Impl.Rest.Client.UnitTest
{
    [TestClass]
    public class RestClientPackageProviderTest : PackageProviderServiceTest
    {
        public RestClientPackageProviderTest() : base(new Dictionary<string, object>
        {
            ["ApiServices:Services:PackageService:BaseAddress"] = "http://localhost:8080"
        })
        {

        }
    }
}
