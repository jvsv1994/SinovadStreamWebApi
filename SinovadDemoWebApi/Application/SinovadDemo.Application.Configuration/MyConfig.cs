namespace SinovadDemo.Application.Configuration
{
    public class MyConfig
    {
        public string PathLog { get; set; }
        public string TMDbApiKey { get; set; }
        public string IMDbApiKey { get; set; }
        public SmtpSettings SmtpSettings { get; set; }
        public JwtSettings JwtSettings { get; set; }
        public PaperTrailSettings PaperTrailSettings { get; set; }
        public FtpSettings FtpSettings { get; set; }

    }
}
