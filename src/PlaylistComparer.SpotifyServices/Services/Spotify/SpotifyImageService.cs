using PlaylistComparer.StreamingServices.Builders;
using PlaylistComparer.StreamingServices.Models;
using PlaylistComparer.StreamingServices.Mappers;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services.Spotify
{
    public class SpotifyImageService : IImageService
    {
        private readonly IBuilder SpotifyClientBuilder;
        public SpotifyImageService(IBuilder spotifyClientBuilder)
        {
            SpotifyClientBuilder = spotifyClientBuilder;
        }

        public async Task<List<ImageModel>> GetPlaylistImages(string id)
        {
            SpotifyClient spotify = await SpotifyClientBuilder.BuildClient();
            List<Image> covers = await spotify.Playlists.GetCovers(id);
            List<ImageModel> images = ImageMapper.MapSpotifyImageToImageModel(covers);

            return images;
        }
    }
}
