using HotChocolate.Types;
using PlaylistComparer.Api.Factories;
using PlaylistComparer.StreamingServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Schema.Track
{
    [ExtendObjectType(Name = "RootQuery")]
    public class TrackQueries
    {
        private readonly StreamingServicesFactory Factory;
        public TrackQueries(StreamingServicesFactory factory)
        {
            Factory = factory;
        }
        public async Task<List<TrackModel>> GetCommonTracks(List<String> urls)
        {
            return await Factory.GetStramingService("Spotify").TrackService.GetCommonTracksAsync(urls);
        }
    }
}
