using Microsoft.AspNetCore.SignalR;
using SinovadDemoWebApi.Shared;

namespace SinovadDemoWebApi.CustomHub
{
    public class MediaServerHub: Hub
    {
        private readonly SharedData _sharedData;

        public MediaServerHub(SharedData sharedData)
        {
            _sharedData = sharedData;
        }

        // for web client

        public async Task UpdateMediaServers(string userGuid)
        {
            await Clients.Group(userGuid).SendAsync("UpdateMediaServers");
        }
        public async Task UpdateLibrariesByMediaServer(string userGuid, string mediaServerGuid)
        {
            await Clients.Group(userGuid).SendAsync("UpdateLibrariesByMediaServer", mediaServerGuid);
        }
        public async Task UpdateCurrentTimeMediaFilePlayBack(string userGuid, string mediaServerGuid,string mediaFilePlaybackGuid,double currentTime,bool isPlaying)
        {
            await Clients.Group(userGuid).SendAsync("UpdateCurrentTimeMediaFilePlayBack", mediaServerGuid, mediaFilePlaybackGuid, currentTime, isPlaying);
        }

        public async Task AddedMediaFilePlayBack(string userGuid, string mediaServerGuid, string mediaFilePlaybackGuid)
        {
            await Clients.Group(userGuid).SendAsync("AddedMediaFilePlayBack", mediaServerGuid, mediaFilePlaybackGuid);
        }

        public async Task RemoveMediaFilePlayBack(string userGuid, string mediaServerGuid, string mediaFilePlaybackGuid)
        {
            await Clients.Group(userGuid).SendAsync("RemoveMediaFilePlayBack", mediaServerGuid, mediaFilePlaybackGuid);
        }

        public async Task RemovedMediaFilePlayBack(string userGuid, string mediaServerGuid, string mediaFilePlaybackGuid)
        {
            await Clients.Group(userGuid).SendAsync("RemovedMediaFilePlayBack", mediaServerGuid, mediaFilePlaybackGuid);
        }
        public async Task RemoveLastTranscodedMediaFileProcess(string userGuid, string mediaServerGuid, string mediaFilePlaybackGuid)
        {
            await Clients.Group(userGuid).SendAsync("RemoveLastTranscodedMediaFileProcess", mediaServerGuid, mediaFilePlaybackGuid);
        }
        public async Task UpdateItemsByMediaServer(string userGuid, string mediaServerGuid)
        {
            await Clients.Group(userGuid).SendAsync("UpdateItemsByMediaServer", mediaServerGuid);
        }
        public async Task UpdateItemsByMediaServerAndLibrary(string userGuid, string mediaServerGuid, string libraryGuid)
        {
            await Clients.Group(userGuid).SendAsync("UpdateItemsByMediaServerAndLibrary", mediaServerGuid, libraryGuid);
        }
        public async Task UpdateMediaServerLastConnection(string userGuid,string mediaServerGuid)
        {
            var connectionFinded= _sharedData.ListConnections.Find(x => x.MediaServerGuid == mediaServerGuid);
            if(connectionFinded!=null)
            {
                connectionFinded.LastConnection = DateTime.Now;
                connectionFinded.UserGuid = userGuid;
                connectionFinded.Enable = true;
            }else
            {
                connectionFinded = new MediaServerConnection();
                connectionFinded.LastConnection= DateTime.Now;
                connectionFinded.MediaServerGuid = mediaServerGuid;
                connectionFinded.UserGuid= userGuid;
                connectionFinded.Enable = true;
                _sharedData.ListConnections.Add(connectionFinded);
            }
            await Task.CompletedTask;
        }

        public async Task AddConnectionToUserClientsGroup(string userGuid)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId,userGuid);
            var currentMilisecond = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            var enableConnections = _sharedData.ListConnections.FindAll(x => currentMilisecond - x.LastConnection.Ticks / TimeSpan.TicksPerMillisecond <= 5000);
            foreach (var connection in enableConnections)
            {
                await Clients.Group(connection.UserGuid).SendAsync("EnableMediaServer", connection.MediaServerGuid);
            }
        } 

    }

}
