using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Utils
{
    public class SpotifyToken
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SpotifyToken(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
    }
}
