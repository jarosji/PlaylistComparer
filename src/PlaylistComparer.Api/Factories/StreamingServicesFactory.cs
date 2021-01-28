using Google.Apis.YouTube.v3;
using PlaylistComparer.StreamingServices.Builders;
using PlaylistComparer.StreamingServices.Services;
using PlaylistComparer.StreamingServices.Services.Spotify;
using PlaylistComparer.StreamingServices.Services.YouTube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Factories
{
    public class StreamingServicesFactory
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IBuilder SpotifyClientBuilder;
        private readonly YouTubeService YouTubeService;

        public StreamingServicesFactory(IServiceProvider serviceProvider, IBuilder spotifyClientBuilder, YouTubeService youTubeService)
        {
            this.serviceProvider = serviceProvider;
            SpotifyClientBuilder = spotifyClientBuilder;
            YouTubeService = youTubeService;
        }

        public IService GetStramingService(string userSelection)
        {
            if (userSelection.Contains("youtube"))
            {
                IPlaylistService youTubePlaylistService = new YouTubePlaylistService(YouTubeService);
                ITrackService youTubeTrackService = new YouTubeTrackService(YouTubeService);
                IImageService youTubeImageService = new YouTubeImageService(YouTubeService);
                IUserService youTubeUserService = new YouTubeUserService(YouTubeService);
                IAlbumService youTubeAlbumService = new YouTubeAlbumService(YouTubeService);
                IArtistService youTubeArtistService = new YouTubeArtistService(YouTubeService);

                var youTube = new YoutubeService(youTubePlaylistService, youTubeTrackService, youTubeImageService, youTubeUserService, youTubeAlbumService, youTubeArtistService);
                return youTube;
            }
            IPlaylistService spotifyPlaylistService = new SpotifyPlaylistService(SpotifyClientBuilder);
            ITrackService spotifyTrackService = new SpotifyTrackService(SpotifyClientBuilder);
            IImageService spotifyImageService = new SpotifyImageService(SpotifyClientBuilder);
            IUserService spotifyUserService = new SpotifyUserService(SpotifyClientBuilder);
            IAlbumService spotifyAlbumService = new SpotifyAlbumService(SpotifyClientBuilder);
            IArtistService spotifyArtistService = new SpotifyArtistService(SpotifyClientBuilder);

            var spotify = new SpotifyService(spotifyPlaylistService, spotifyTrackService, spotifyImageService, spotifyUserService, spotifyAlbumService, spotifyArtistService);
            return spotify;
        }

        //public IPlaylistService GetPlaylistService(string userSelection)
        //{
        //    if (userSelection.Contains("youtube"))
        //        return (IPlaylistService) serviceProvider.GetService(typeof(YouTubePlaylistService));

        //    return (IPlaylistService) serviceProvider.GetService(typeof(SpotifyPlaylistService));
        //}

        //public ITrackService GetTrackService(string userSelection)
        //{
        //    //if (userSelection.Contains("youtube"))
        //    //    return (IPlaylistService)serviceProvider.GetService(typeof(YouTubePlaylistService));

        //    return (ITrackService) serviceProvider.GetService(typeof(SpotifyTrackService));
        //}
        //public IImageService GetImageService(string userSelection)
        //{
        //    //if (userSelection.Contains("youtube"))
        //    //    return (IPlaylistService)serviceProvider.GetService(typeof(YouTubePlaylistService));

        //    return (IImageService)serviceProvider.GetService(typeof(SpotifyImageService));
        //}
    }
}
