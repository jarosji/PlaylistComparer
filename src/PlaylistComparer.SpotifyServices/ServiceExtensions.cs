using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PlaylistComparer.Spotify.Builders;
using PlaylistComparer.Spotify.Services;
using PlaylistComparer.Spotify.Utils;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistComparer.Spotify
{
    public static class ServiceExtensions
    {
        public static void AddSpotifyServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton(SpotifyClientConfig.CreateDefault().WithAuthenticator(new ClientCredentialsAuthenticator("c8bc902470624f89bb3a70aab0fedc0b", "9f96b0c0d4d0425cb5166bccd6189e30")));
            services.AddTransient<IBuilder, SpotifyClientBuilder>();

            services.AddTransient<ITrackService, TrackService>();
            services.AddTransient<IPlaylistService, PlaylistService>();
        }
    }
}
