using PlaylistComparer.StreamingServices.Builders;
using PlaylistComparer.StreamingServices.Mappers;
using PlaylistComparer.StreamingServices.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services.Spotify
{
    public class SpotifyAlbumService : IAlbumService
    {
        private readonly IBuilder SpotifyClientBuilder;
        public SpotifyAlbumService(IBuilder spotifyClientBuilder)
        {
            SpotifyClientBuilder = spotifyClientBuilder;
        }
        public async Task<AlbumModel> GetAlbum(String id)
        {
            SpotifyClient spotify = await SpotifyClientBuilder.BuildClient();

            var track = await spotify.Tracks.Get(id);
            SimpleAlbum simpleAlbum = track.Album;

            AlbumModel album = AlbumMapper.MapSpotifyAlbumToAlbumModel(simpleAlbum);
            return album;
        }
    }
}
