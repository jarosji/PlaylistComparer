using HotChocolate.Types;
using PlaylistComparer.StreamingServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Schema.Track
{
    public class TrackInputType : InputObjectType<TrackModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<TrackModel> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Href);
        }
    }
}
