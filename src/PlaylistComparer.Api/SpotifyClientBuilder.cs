using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using PlaylistComparer.Api.Utils;
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
        private readonly SpotifyToken SpotifyToken;

        public SpotifyClientBuilder(IHttpContextAccessor httpContextAccessor, SpotifyClientConfig spotifyClientConfig, SpotifyToken spotifyToken)
        {
            _httpContextAccessor = httpContextAccessor;
            _spotifyClientConfig = spotifyClientConfig;
            SpotifyToken = spotifyToken;
        }

        public async Task<SpotifyClient> BuildClient()
        {
            //var token = await _httpContextAccessor.HttpContext.GetTokenAsync("Spotify", "access_token");)
            
            var token = _httpContextAccessor.HttpContext.Request.Cookies["spotify"];
            if (token == null)
            {
                if (_httpContextAccessor.HttpContext.Request.Cookies["spotifyRefreshToken"] != null) token = await SpotifyToken.RefreshToken();
                else return new SpotifyClient(_spotifyClientConfig);
            }
            return new SpotifyClient(_spotifyClientConfig.WithToken(token));
        }
    }
}
