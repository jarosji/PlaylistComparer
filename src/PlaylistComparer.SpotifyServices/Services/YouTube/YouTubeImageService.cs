using Google.Apis.YouTube.v3;
using PlaylistComparer.StreamingServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services.YouTube
{
    public class YouTubeImageService : IImageService
    {
        private readonly YouTubeService YouTubeService;
        public YouTubeImageService(YouTubeService youTubeService)
        {
            YouTubeService = youTubeService;
        }
        public Task<List<ImageModel>> GetPlaylistImages(string id)
        {
            throw new NotImplementedException();
        }
    }
}
