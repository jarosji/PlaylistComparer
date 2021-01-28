using HotChocolate.Types;
using PlaylistComparer.Api.Schema.Track;
using PlaylistComparer.StreamingServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Schema.Playlist
{
    public class PlaylistInputType : InputObjectType<PlaylistModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<PlaylistModel> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Description);
            descriptor.Field(x => x.Tracks).Type<ListType<TrackInputType>>();
        }
    }
}
