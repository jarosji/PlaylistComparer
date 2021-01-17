using Microsoft.AspNetCore.Http;
using PlaylistComparer.Api.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Schema.User
{
    public class UserResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> LoginSpotify(String code)
        {
            var response = await new OAuthClient().RequestToken(
                new AuthorizationCodeTokenRequest("c8bc902470624f89bb3a70aab0fedc0b", "9f96b0c0d4d0425cb5166bccd6189e30", code, new Uri("https://localhost:44329/graphql"))
            );
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(1);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("spotify", response.AccessToken, option);
            return true;
        }
    }
}
