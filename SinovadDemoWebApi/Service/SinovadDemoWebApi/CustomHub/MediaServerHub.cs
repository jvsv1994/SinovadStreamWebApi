﻿using Microsoft.AspNetCore.SignalR;

namespace SinovadDemoWebApi.CustomHub
{
    public class MediaServerHub: Hub
    {
        public async Task UpdateItemsByMediaServer(string mediaServerGuid)
        {
            await Clients.Group(mediaServerGuid).SendAsync("UpdateItemsByMediaServer");
        }
        public async Task UpdateItemsByLibrary(string libraryGuid)
        {
            await Clients.Group(libraryGuid).SendAsync("UpdateItemsByLibrary");
        }
        public async Task UpdateLibraries(string mediaServerGuid)
        {
            await Clients.Group(mediaServerGuid).SendAsync("UpdateLibraries");
        }
        public async Task UpdateTranscoderSettings(string mediaServerGuid)
        {
            await Clients.Group(mediaServerGuid).SendAsync("UpdateTranscoderSettings");
        }

        public async Task UpdateMediaServers(string userGuid)
        {
            await Clients.Group(userGuid).SendAsync("UpdateMediaServers");
        }

        public async Task AddConnectionToUserClientsGroup(string userGuid)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId,userGuid);
        } 
        public async Task AddConnectionToMediaServerClientsGroup(string mediaServerGuid)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, mediaServerGuid);
        }
        public async Task AddConnectionToLibraryClientsGroup(string libraryGuid)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, libraryGuid);
        }
    }

}
