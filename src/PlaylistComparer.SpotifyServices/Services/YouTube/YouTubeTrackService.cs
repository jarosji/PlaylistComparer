using Google.Apis.YouTube.v3;
using PlaylistComparer.StreamingServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services.YouTube
{
    public class YouTubeTrackService : ITrackService
    {
        private readonly YouTubeService YouTubeService;
        public YouTubeTrackService(YouTubeService youTubeService)
        {
            YouTubeService = youTubeService;
        }
        public Task<List<TrackModel>> GetCommonTracksAsync(List<string> ids)
        {
            throw new NotImplementedException();
        }

        public List<int> GetDuplicateTracks(List<TrackModel> tracks)
        {
            throw new NotImplementedException();
        }

        public Task<List<TrackModel>> GetTopTracksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<TrackModel>> GetTracksAsync(string ids)
        {
            throw new NotImplementedException();
        }
    }
}
