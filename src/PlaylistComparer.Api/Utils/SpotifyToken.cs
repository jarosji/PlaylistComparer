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
        public async Task<String> RefreshToken()
        {
            var response = await new OAuthClient().RequestToken(
                new AuthorizationCodeRefreshRequest("c8bc902470624f89bb3a70aab0fedc0b", "9f96b0c0d4d0425cb5166bccd6189e30", _httpContextAccessor.HttpContext.Request.Cookies["spotifyRefreshToken"])
            );
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddSeconds(response.ExpiresIn);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("spotify", response.AccessToken, option);
            return response.AccessToken;
        }
    }
}
