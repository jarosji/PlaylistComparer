using HotChocolate.Types;
using PlaylistComparer.Spotify.Schema.Playlist;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Spotify.Schema
{
    public class Mutation : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("RootMutation");

            //descriptor.Field<PlaylistResolver>(x => x.RenamePlaylist(default, default)).Type<BooleanType>();
            descriptor.Field<PlaylistResolver>(x => x.RemoveDuplicates(default)).Type<PlaylistType>();
            descriptor.Field<PlaylistResolver>(x => x.CreatePlaylist(default)).Type<BooleanType>();
        }
    }
}
