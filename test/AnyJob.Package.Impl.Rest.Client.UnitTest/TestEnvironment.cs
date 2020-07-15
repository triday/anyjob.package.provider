using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            //StartContainer(availablePort, password);
            //SetConnectionString(availablePort, password);
            StartContainer();
        }

        [AssemblyCleanup()]
        public static void TearDown()
        {
            DockerCompose.Down();
        }
        //private static void SetConnectionString(uint port, string password)
        //{
        //    var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        //    {
        //        DataSource = $"127.0.0.1,{port}",
        //        InitialCatalog = "SequenceContext",
        //        UserID = "sa",
        //        Password = password
        //    };
        //    Environment.SetEnvironmentVariable("ConnectionStrings__SequenceContext", sqlConnectionStringBuilder.ConnectionString);
        //}
        private static void StartContainer()
        {
            DockerCompose.Up();
        }


    }
}
