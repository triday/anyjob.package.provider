using Microsoft.VisualStudio.TestTools.UnitTesting;
using YS.Knife.Test;

namespace YS.Sequence.Impl.EFCore.SqlServer
{
    [TestClass]
    public class TestEnvironment
    {
        [AssemblyInitialize()]
        public static void Setup(TestContext _)
        {
            StartContainer();
        }

        [AssemblyCleanup()]
        public static void TearDown()
        {
            DockerCompose.Down();
        }

        private static void StartContainer()
        {
            DockerCompose.Up();
        }


    }
}
