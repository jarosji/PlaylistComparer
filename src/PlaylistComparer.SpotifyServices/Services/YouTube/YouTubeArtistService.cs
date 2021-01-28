using Google.Apis.YouTube.v3;
using PlaylistComparer.StreamingServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services.YouTube
{
    public class YouTubeArtistService : IArtistService
    {
        private readonly YouTubeService YouTubeService;
        public YouTubeArtistService(YouTubeService youTubeService)
        {
            YouTubeService = youTubeService;
        }

        public Task<List<ArtistModel>> GetArtists(string id)
        {
            throw new NotImplementedException();
        }
    }
}
