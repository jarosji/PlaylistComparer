using PlaylistComparer.StreamingServices.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistComparer.StreamingServices.Mappers
{
    public class ImageMapper
    {
        public static List<ImageModel> MapSpotifyImageToImageModel(List<Image> spotifyImage)
        {
            List<ImageModel> tracks = new List<ImageModel>();
            foreach (Image item in spotifyImage)
            {
                tracks.Add(MapSpotifyImageToImageModel(item));
            }
            return tracks;
        }
        public static ImageModel MapSpotifyImageToImageModel(Image spotifyImage)
        {

            return new ImageModel()
            {
                Height  = spotifyImage.Height,
                Width = spotifyImage.Width,
                Url = spotifyImage.Url
            };
        }
    }
}
