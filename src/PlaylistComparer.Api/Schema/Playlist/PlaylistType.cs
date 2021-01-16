using HotChocolate.Types;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Schema.Playlist
{
    public class PlaylistType : ObjectType<FullPlaylist>
    {
        protected override void Configure(IObjectTypeDescriptor<FullPlaylist> descriptor)
        {
            
        }
    }
}
