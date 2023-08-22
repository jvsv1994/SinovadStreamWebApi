using Microsoft.AspNetCore.SignalR;

namespace SinovadDemoWebApi.CustomHub
{
    public class MediaServerHostedService : IHostedService, IDisposable
    {
        private Timer _timer;

        private readonly SharedData _sharedData;

        private readonly IHubContext<MediaServerHub> _hubContext;

        public MediaServerHostedService(SharedData sharedData, IHubContext<MediaServerHub> hubContext)
        {
            _sharedData = sharedData;
            _hubContext = hubContext;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CheckMediaServerConnection,null,TimeSpan.Zero,TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private void CheckMediaServerConnection(object state) {
            var currentMilisecond = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            var enableConnections=_sharedData.ListConnections.FindAll(x => (x.LastConnection.Ticks / TimeSpan.TicksPerMillisecond) - currentMilisecond <= 5000);
            foreach (var connection in enableConnections)
            {
                _hubContext.Clients.Group(connection.UserGuid).SendAsync("EnableMediaServer", connection.MediaServerGuid);
            }
            var disableConnections = _sharedData.ListConnections.FindAll(x => (x.LastConnection.Ticks / TimeSpan.TicksPerMillisecond) - currentMilisecond > 5000);
            foreach (var connection in disableConnections)
            {
                _hubContext.Clients.Group(connection.UserGuid).SendAsync("DisableMediaServer", connection.MediaServerGuid);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
