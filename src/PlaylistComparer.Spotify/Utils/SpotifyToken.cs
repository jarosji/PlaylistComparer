using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Utils
{
    public class SpotifyToken
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SpotifyToken(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<String> RefreshToken(String refreshToken)
        {
            var response = await new OAuthClient().RequestToken(
                new AuthorizationCodeRefreshRequest("c8bc902470624f89bb3a70aab0fedc0b", "9f96b0c0d4d0425cb5166bccd6189e30", refreshToken)
            );

            var auth = await _httpContextAccessor.HttpContext.AuthenticateAsync();
            //auth.Properties.StoreTokens(new List<AuthenticationToken>()
            //{
            //    new AuthenticationToken()
            //    {
            //        Name = "access_token",
            //        Value = response.AccessToken
            //    },
            //    new AuthenticationToken()
            //    {
            //        Name = "refresh_token",
            //        Value = refreshToken
            //    }
            //});
            auth.Properties.UpdateTokenValue("access_token", response.AccessToken);
            await _httpContextAccessor.HttpContext.SignInAsync(auth.Principal, auth.Properties);
            return response.AccessToken;
        }
    }
}
