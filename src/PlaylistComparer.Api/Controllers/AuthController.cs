using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Controllers
{
    public class AuthController : Controller
    {
        [Route("{Controller}")]
        public IActionResult Get(String url = "/")
        {
            //var loginRequest = new LoginRequest(
            //  new Uri("https://localhost:44329/graphql"),
            //  "c8bc902470624f89bb3a70aab0fedc0b",
            //  LoginRequest.ResponseType.Code
            //)
            //{
            //    Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative, Scopes.PlaylistModifyPublic, Scopes.PlaylistModifyPrivate }
            //};
            //var uri = loginRequest.ToUri();
            //return Redirect(uri.ToString());

            return Challenge(new AuthenticationProperties() { RedirectUri = url });
        }
    }
}
