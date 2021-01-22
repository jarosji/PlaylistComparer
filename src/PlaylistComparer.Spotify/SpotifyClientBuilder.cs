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
            String accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("Spotify", "access_token");
            var refreshToken = await _httpContextAccessor.HttpContext.GetTokenAsync("Spotify", "refresh_token");

            if (accessToken != null && refreshToken != null)
            {
                var expires = await _httpContextAccessor.HttpContext.GetTokenAsync("expires_at");
                var expireDate = DateTime.Parse(expires);
                var nowDate = DateTime.UtcNow;
                var result = DateTime.Compare(expireDate, nowDate);

                if (result<=0)
                {
                    accessToken = await SpotifyToken.RefreshToken(refreshToken);
                }
                return new SpotifyClient(_spotifyClientConfig.WithToken(accessToken));
            }
            return new SpotifyClient(_spotifyClientConfig);
        }
    }
}
