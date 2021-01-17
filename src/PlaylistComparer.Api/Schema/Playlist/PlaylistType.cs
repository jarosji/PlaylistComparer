using HotChocolate.Types;
using PlaylistComparer.Api.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Schema.Playlist
{
    public class PlaylistType : ObjectType<PlaylistModel>
    {
        protected override void Configure(IObjectTypeDescriptor<PlaylistModel> descriptor)
        {
            
        }
    }
}
