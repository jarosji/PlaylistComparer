using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using PlaylistComparer.StreamingServices.Utils;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Builders
{
    public class SpotifyClientBuilder : IBuilder
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
                    accessToken = await RefreshToken(refreshToken);
                }
                return new SpotifyClient(_spotifyClientConfig.WithToken(accessToken));
            }
            return new SpotifyClient(_spotifyClientConfig);
        }

        private async Task<String> RefreshToken(String refreshToken)
        {
            var response = await new OAuthClient().RequestToken(
                new AuthorizationCodeRefreshRequest("c8bc902470624f89bb3a70aab0fedc0b", "9f96b0c0d4d0425cb5166bccd6189e30", refreshToken)
            );

            var auth = await _httpContextAccessor.HttpContext.AuthenticateAsync();
            auth.Properties.UpdateTokenValue("access_token", response.AccessToken);
            await _httpContextAccessor.HttpContext.SignInAsync(auth.Principal, auth.Properties);
            return response.AccessToken;
        }
    }
}