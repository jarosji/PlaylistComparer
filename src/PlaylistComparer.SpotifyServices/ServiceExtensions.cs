using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PlaylistComparer.StreamingServices.Builders;
using PlaylistComparer.StreamingServices.Services;
using PlaylistComparer.StreamingServices.Services.Spotify;
using PlaylistComparer.StreamingServices.Services.YouTube;
using PlaylistComparer.StreamingServices.Utils;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistComparer.StreamingServices
{
    public static class ServiceExtensions
    {
        public static void AddSpotifyServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton(SpotifyClientConfig.CreateDefault().WithAuthenticator(new ClientCredentialsAuthenticator("c8bc902470624f89bb3a70aab0fedc0b", "9f96b0c0d4d0425cb5166bccd6189e30")));
            services.AddSingleton(new YouTubeService(new BaseClientService.Initializer() { ApiKey = "AIzaSyCpHLQBrGB5mf3ZVx-s8vmyGQWOjk5gfd4" }));
            services.AddTransient<IBuilder, SpotifyClientBuilder>();

            //services.AddTransient<SpotifyService>();
            //services.AddTransient<YoutubeService>();

            //services.AddTransient<SpotifyPlaylistService>()
            //    .AddTransient<IPlaylistService, SpotifyPlaylistService>(x=>x.GetService<SpotifyPlaylistService>());
            // services.AddTransient<YouTubePlaylistService>()
            //    .AddTransient<IPlaylistService, YouTubePlaylistService>(x=>x.GetService<YouTubePlaylistService>());

            //services.AddTransient<SpotifyTrackService>()
            //    .AddTransient<ITrackService, SpotifyTrackService>(x => x.GetService<SpotifyTrackService>());
            ////services.AddTransient<YouTubePlaylistService>()
            ////   .AddTransient<ITrackService, YouTubePlaylistService>(x => x.GetService<YouTubePlaylistService>());

            //services.AddTransient<SpotifyImageService>()
            //    .AddTransient<IImageService, SpotifyImageService>(x => x.GetService<SpotifyImageService>());
        }
    }
}
