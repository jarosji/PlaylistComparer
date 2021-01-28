using PlaylistComparer.StreamingServices.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlaylistComparer.StreamingServices.Mappers
{
    public class AlbumMapper
    {
        public static AlbumModel MapSpotifyAlbumToAlbumModel(SimpleAlbum spotifyAlbum)
        {
            return new AlbumModel()
            {
                Id = spotifyAlbum.Id,
                Name = spotifyAlbum.Name,
                AlbumType = spotifyAlbum.AlbumType,
                Images = spotifyAlbum.Images.Select(x=>x.Url).ToList(),
                AvailableMarkets = spotifyAlbum.AvailableMarkets,
                //Genres = spotifyAlbum.Genres,
                Href = spotifyAlbum.Href,
                Uri = spotifyAlbum.Uri,
                //Artists = ArtistMapper.MapSpotifyArtistToArtistModel(spotifyAlbum.Artists)
                //Label = spotifyAlbum.Label,
                //Popularity = spotifyAlbum.Popularity
            };
        }

        //public static PlaylistModel MapYouTubeToPlaylistModel(Playlist youTubePlaylist)
        //{
        //}
    }
}
