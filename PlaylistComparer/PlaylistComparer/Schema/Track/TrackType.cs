using HotChocolate.Types;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Schema.Track
{
    public class TrackType : ObjectType<FullTrack>
    {
        protected override void Configure(IObjectTypeDescriptor<FullTrack> descriptor)
        {
           //descriptor.Field(x => x.Id).Type<IdType>();
        }
    }
}
