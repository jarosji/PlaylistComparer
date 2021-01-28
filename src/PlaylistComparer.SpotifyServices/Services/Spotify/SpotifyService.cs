using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistComparer.StreamingServices.Services.Spotify
{
    public class SpotifyService : IService
    {
        public IPlaylistService PlaylistService { get; }
        public ITrackService TrackService { get; }
        public IImageService ImageService { get; }
        public IUserService UserService { get; }
        public IAlbumService AlbumService { get; }
        public IArtistService ArtistService { get; }
        public SpotifyService(IPlaylistService playlistService, ITrackService trackService, IImageService imageService, IUserService userService, IAlbumService albumService, IArtistService artistService)
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
