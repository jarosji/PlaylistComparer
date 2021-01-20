using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using PlaylistComparer.Api.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Schema.User
{
    public class UserResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SpotifyClientConfig _spotifyClientConfig;
        private readonly HttpClient HttpClient;
        public UserResolver(IHttpContextAccessor httpContextAccessor, SpotifyClientConfig spotifyClientConfig, HttpClient httpClient)
        {
            _httpContextAccessor = httpContextAccessor;
            _spotifyClientConfig = spotifyClientConfig;
            HttpClient = httpClient;
        }
        public async Task<bool> LoginSpotify(String url = "/")  //https://localhost:44329/graphql http://localhost:3000/auth
        {
            return true;
        }
    }
}
