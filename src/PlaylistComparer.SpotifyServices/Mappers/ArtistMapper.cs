using PlaylistComparer.StreamingServices.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistComparer.StreamingServices.Mappers
{
    public class ArtistMapper
    {
        public static List<ArtistModel> MapSpotifyArtistToArtistModel(List<SimpleArtist> spotifyArtists)
        {
            List<ArtistModel> artists = new List<ArtistModel>();
            foreach (SimpleArtist item in spotifyArtists)
            {
                artists.Add(MapSpotifyArtistToArtistModel(item));
            }
            return artists;
        }
        public static ArtistModel MapSpotifyArtistToArtistModel(SimpleArtist spotifyArtist)
        {
            return new ArtistModel()
            {
                Id = spotifyArtist.Id,
                Name = spotifyArtist.Name,
                Href = spotifyArtist.Href,
                Uri = spotifyArtist.Uri,
            };
        }
    }
}
