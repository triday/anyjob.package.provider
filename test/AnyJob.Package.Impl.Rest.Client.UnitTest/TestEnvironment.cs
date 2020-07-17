using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YS.Knife.Test;

namespace AnyJob.Package.Impl.Rest.Client.UnitTest
{
    [TestClass]
    public class TestEnvironment
    {
        [AssemblyInitialize()]
        public static void Setup(TestContext _)
        {
            var port = Utility.GetAvailableTcpPort(8080);
            StartContainer(port);
        }

        [AssemblyCleanup()]
        public static void TearDown()
        {
            DockerCompose.Down();
        }

        private static void StartContainer(uint port)
        {
            DockerCompose.Up(new Dictionary<string, object>
            {
                ["SERVICE_PORT"] = port
            });
            Environment.SetEnvironmentVariable("ApiServices__Services__PackageService__BaseAddress", $"http://localhost:{port}");
        }


    }
}
