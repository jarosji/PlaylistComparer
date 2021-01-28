using PlaylistComparer.StreamingServices.Services.Spotify;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistComparer.StreamingServices.Services.YouTube
{
    public class YoutubeService : IService
    {
        public IPlaylistService PlaylistService { get; }
        public IImageService ImageService { get; }
        public ITrackService TrackService { get; }
        public IUserService UserService { get; }
        public IAlbumService AlbumService { get; }
        public IArtistService ArtistService { get; }
        public YoutubeService(IPlaylistService playlistService, ITrackService trackService, IImageService imageService, IUserService userService, IAlbumService albumService, IArtistService artistService)
        {
            PlaylistService = playlistService;
            TrackService = trackService;
            ImageService = imageService;
            UserService = userService;
            AlbumService = albumService;
            ArtistService = artistService;
        }
    }
}
