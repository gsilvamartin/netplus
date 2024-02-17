namespace NetDevExtensions.ServiceAbstractions.Cache.Redis.Configuration
{
    public class RedisRepositoryOptions
    {
        public string ConnectionString { get; set; }
        public int DatabaseNumber { get; set; } = 0;
        public int SyncTimeout { get; set; } = 5000;
        public bool AllowAdmin { get; set; } = false;
        public int ConnectTimeout { get; set; } = 5000;
        public int KeepAlive { get; set; } = 180;
        public bool AbortOnConnectFail { get; set; } = false;
    }
}