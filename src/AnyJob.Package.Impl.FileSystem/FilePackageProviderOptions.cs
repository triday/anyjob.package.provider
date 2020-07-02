using System;
using System.Collections.Generic;
using System.Text;

namespace AnyJob.Package.Impl.FileSystem
{
    [YS.Knife.OptionsClass("FileProvider")]
    public class FilePackageProviderOptions
    {
        public string RootDir { get; set; } = "/anyjob/packs";
        public string BaseUrl { get; set; } = "http://localhost:9595";
    }
}
