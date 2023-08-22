namespace SinovadDemoWebApi.CustomHub
{
    public class MediaServerConnection
    {
        public string MediaServerGuid { get; set; }
        public string UserGuid { get; set; }
        public DateTime LastConnection { get; set; }
        public bool Enable { get; set; }

    }
}
