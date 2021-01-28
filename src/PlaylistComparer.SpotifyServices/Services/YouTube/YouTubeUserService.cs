using Google.Apis.YouTube.v3;
using PlaylistComparer.StreamingServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services.YouTube
{
    public class YouTubeUserService : IUserService
    {
        private readonly YouTubeService YouTubeService;
        public YouTubeUserService(YouTubeService youTubeService)
        {
            YouTubeService = youTubeService;
        }

        public Task<UserModel> GetOwner(string id)
        {
            throw new NotImplementedException();
        }
    }
}
