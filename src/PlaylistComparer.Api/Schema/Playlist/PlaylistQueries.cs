using HotChocolate.Types;
using PlaylistComparer.Api.Factories;
using PlaylistComparer.StreamingServices.Models;
using PlaylistComparer.StreamingServices.Services.Spotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Schema.Playlist
{
    [ExtendObjectType(Name = "RootQuery")]
    public class PlaylistQueries
    {
        private readonly StreamingServicesFactory Factory;
        public PlaylistQueries(StreamingServicesFactory factory)
        {
            Factory = factory;
        }
        public async Task<PlaylistModel> GetPlaylist(String url)
        {
            return await Factory.GetStramingService(url).PlaylistService.GetPlaylistAsync(url);
        }
        public async Task<List<PlaylistModel>> GetPlaylists(List<String> urls)
        {
            List<PlaylistModel> playlists = new List<PlaylistModel>();
            foreach (String url in urls)
            {
                playlists.Add(await Factory.GetStramingService(url).PlaylistService.GetPlaylistAsync(url));
            }
            return playlists;
        }
    }
}