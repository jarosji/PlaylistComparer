using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistComparer.StreamingServices.Services
{
    public interface IService
    {
        IPlaylistService PlaylistService { get; }
        IImageService ImageService { get; }
        ITrackService TrackService { get; }
        IUserService UserService { get; }
        IAlbumService AlbumService { get; }
        IArtistService ArtistService { get; }
    }
}
