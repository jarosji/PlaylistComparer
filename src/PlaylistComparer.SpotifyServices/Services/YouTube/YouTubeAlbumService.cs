using Google.Apis.YouTube.v3;
using PlaylistComparer.StreamingServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services.YouTube
{
    public class YouTubeAlbumService : IAlbumService
    {
        private readonly YouTubeService YouTubeService;
        public YouTubeAlbumService(YouTubeService youTubeService)
        {
            YouTubeService = youTubeService;
        }
        public Task<AlbumModel> GetAlbum(string id)
        {
            throw new NotImplementedException();
        }
    }
}
