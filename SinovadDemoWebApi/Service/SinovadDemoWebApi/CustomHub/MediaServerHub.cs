using Microsoft.AspNetCore.SignalR;

namespace SinovadDemoWebApi.CustomHub
{
    public class MediaServerHub: Hub
    {

        // for web client

        public async Task UpdateMediaServers(string userGuid)
        {
            await Clients.Group(userGuid).SendAsync("UpdateMediaServers");
        }
        public async Task UpdateLibrariesByMediaServer(string userGuid, string mediaServerGuid)
        {
            await Clients.Group(userGuid).SendAsync("UpdateLibrariesByMediaServer", mediaServerGuid);
        }
        public async Task UpdateItemsByMediaServer(string userGuid, string mediaServerGuid)
        {
            await Clients.Group(userGuid).SendAsync("UpdateItemsByMediaServer", mediaServerGuid);
        }
        public async Task UpdateItemsByMediaServerAndLibrary(string userGuid, string mediaServerGuid, string libraryGuid)
        {
            await Clients.Group(userGuid).SendAsync("UpdateItemsByMediaServerAndLibrary", mediaServerGuid, libraryGuid);
        }

        public async Task AddConnectionToUserClientsGroup(string userGuid)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId,userGuid);
        } 

        // for media server client

        public async Task AddConnectionToMediaServerClientsGroup(string mediaServerGuid)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, mediaServerGuid);
        }
        public async Task UpdateTranscoderSettings(string mediaServerGuid)
        {
            await Clients.Group(mediaServerGuid).SendAsync("UpdateTranscoderSettings");
        }
    }

}
