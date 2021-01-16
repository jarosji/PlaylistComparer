﻿using HotChocolate.Types;
using PlaylistComparer.Api.Schema.Playlist;
using PlaylistComparer.Schema.Track;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Schema
{
    public class Query : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("RootQuery");

            //Playlist Queries
            descriptor.Field<PlaylistResolver>(t => t.Playlist(default)).Type<PlaylistType>();
            descriptor.Field<PlaylistResolver>(t => t.Playlists(default)).Type<ListType<PlaylistType>>();

            //Track Queries
            descriptor.Field<TrackResolver>(t => t.Tracks(default)).Type<ListType<TrackType>>()
                .Argument("ids", x => x.Type<ListType<StringType>>().Description("IDs of playlists."));
        }
    }
}
