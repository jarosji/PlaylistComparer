using HotChocolate.Types;
using PlaylistComparer.Api.Factories;
using PlaylistComparer.StreamingServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Schema.Playlist
{
    [ExtendObjectType(Name = "RootMutation")]
    public class PlaylistMutations
    {
        private readonly StreamingServicesFactory Factory;
        public PlaylistMutations(StreamingServicesFactory factory)
        {
            Factory = factory;
        }
        public async Task<bool> CreatePlaylist(PlaylistModel input)
        {
            return await Factory.GetStramingService("Spotify").PlaylistService.CreatePlaylistAsync(input);
        }
        public async Task<PlaylistModel> RemoveDuplicates(String url)
        {
            throw new NotImplementedException();
        }
    }
}
