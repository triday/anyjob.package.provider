using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using YS.Knife.Hosting;

namespace AnyJob.Package.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            KnifeWebHost.Start(args);
        }


    }
}
