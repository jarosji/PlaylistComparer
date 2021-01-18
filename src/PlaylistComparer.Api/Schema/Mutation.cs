using HotChocolate.Types;
using PlaylistComparer.Api.Schema.Playlist;
using PlaylistComparer.Api.Schema.User;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Schema
{
    public class Mutation : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("RootMutation");

            descriptor.Field<UserResolver>(x => x.LoginSpotify(default)).Type<BooleanType>().Description("Get code from localhost/:port/test/");

            descriptor.Field<PlaylistResolver>(x => x.RenamePlaylist(default, default)).Type<BooleanType>();
            descriptor.Field<PlaylistResolver>(x => x.RemoveDuplicates(default)).Type<PlaylistType>();
            descriptor.Field<PlaylistResolver>(x => x.CreatePlaylist(default)).Type<BooleanType>();
        }
    }
}
