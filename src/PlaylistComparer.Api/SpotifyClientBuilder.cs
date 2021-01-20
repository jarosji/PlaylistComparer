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
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("Spotify", "access_token");
            var refreshToken = await _httpContextAccessor.HttpContext.GetTokenAsync("Spotify", "refresh_token");

            if (accessToken == null)
            {
                if (refreshToken != null) accessToken = await SpotifyToken.RefreshToken(refreshToken);
                else return new SpotifyClient(_spotifyClientConfig);
            }
            return new SpotifyClient(_spotifyClientConfig.WithToken(accessToken));
        }
    }
}
