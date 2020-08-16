using Microsoft.Extensions.FileProviders;
using YS.Knife.Hosting;

namespace AnyJob.Package.App
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            KnifeWebHost.Start(args);
        }


    }
}
