using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api
{
    public class SpotifyClientBuilder
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SpotifyClientConfig _spotifyClientConfig;

        public SpotifyClientBuilder(IHttpContextAccessor httpContextAccessor, SpotifyClientConfig spotifyClientConfig)
        {
            _httpContextAccessor = httpContextAccessor;
            _spotifyClientConfig = spotifyClientConfig;
        }

        public async Task<SpotifyClient> BuildClient()
        {
            //var token = await _httpContextAccessor.HttpContext.GetTokenAsync("Spotify", "access_token");)
            
            var token = _httpContextAccessor.HttpContext.Request.Cookies["spotify"];
            if (token == null)
            {
                return new SpotifyClient(_spotifyClientConfig);
            }
            return new SpotifyClient(_spotifyClientConfig.WithToken(token));
        }
    }
}
