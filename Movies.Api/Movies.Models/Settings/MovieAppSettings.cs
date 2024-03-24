namespace Movies.Models.Settings
{
    public class MovieAppSettings
    {
        public CacheSettings Cache { get; set; }
        public string PasswordEncryptionKey { get; set; }
        public bool EnableAuditLogs { get; set; }
    }

    public class CacheSettings
    {
        public int CacheConnectionStrings { get; set; } = 30;
        public int CacheNodes { get; set; } = 30;
        public bool UseRedisForCachePermissions { get; set; } = true;
        public int CachePermissions { get; set; } = 30;
    }
}
