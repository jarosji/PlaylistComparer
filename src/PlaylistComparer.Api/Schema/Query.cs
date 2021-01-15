using HotChocolate.Types;
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
            descriptor.Field<TrackResolver>(t => t.Tracks(default, default)).Type<ListType<TrackType>>()
                .Argument("idA", x => x.Type<StringType>().Description("ID of first playlist."))
                .Argument("idB", x => x.Type<StringType>().Description("ID of second playlist."));
        }
    }
}
