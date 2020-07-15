namespace AnyJob.Package.Impl.FileSystem
{
    [YS.Knife.OptionsClass("FileProvider")]
    public class FilePackageProviderOptions
    {
        public string RootDir { get; set; } = "/anyjob/packs";
        public string UrlFormat { get; set; } = "/{0}";
    }
}
