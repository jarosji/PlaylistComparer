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
            return Challenge(new AuthenticationProperties() { RedirectUri = url });
        }
    }
}