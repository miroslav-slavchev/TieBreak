namespace SwagLabs.Tests.Infrastructure.Config
{
    public class AppSettings
    {
        public AppConfig App { get; set; }
        public UsersConfig Users { get; set; }
    }

    public class AppConfig
    {
        public string Url { get; set; }
        public string HomePagePath { get; set; }
    }

    public class UsersConfig
    {
        public UserConfig StandardUser { get; set; }
        public UserConfig LockedOutUser { get; set; }
        public UserConfig ProblemUser { get; set; }
        public UserConfig PerformanceGlitchUser { get; set; }
        public UserConfig ErrorUser { get; set; }
        public UserConfig VisualUser { get; set; }
    }

    public class UserConfig
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
