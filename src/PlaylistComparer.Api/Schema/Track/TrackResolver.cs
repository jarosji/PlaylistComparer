using PlaylistComparer.Spotify;
using PlaylistComparer.Spotify.Services;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Schema.Track
{
    public class TrackResolver
    {
        private readonly ITrackService TrackService;

        public TrackResolver(ITrackService trackService)
        {
            TrackService = trackService;
        }

        public async Task<List<FullTrack>> Tracks(List<String> ids)
        {
            return await TrackService.GetCommonTracksAsync(ids);
        }
    }
}
