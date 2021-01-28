using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistComparer.StreamingServices.Models
{
    public class AlbumModel
    {
        public string Name { get; set; }
        //public int Popularity { get; set; }
        //public string Label { get; set; }
        public List<String> Images { get; set; }
        public string Id { get; set; }
        public string Href { get; set; }
        //public List<string> Genres { get; set; }
        public string Uri { get; set; }
        public List<string> AvailableMarkets { get; set; }
        public List<ArtistModel> Artists { get; set; }
        public string AlbumType { get; set; }

        //Spotify

        //public Paging<SimpleTrack> Tracks { get; set; }
        //public Dictionary<string, string> Restrictions { get; set; }
        //public string ReleaseDatePrecision { get; set; }
        //public string ReleaseDate { get; set; }
        //public Dictionary<string, string> ExternalUrls { get; set; }
        //public Dictionary<string, string> ExternalIds { get; set; }
        //public List<Copyright> Copyrights { get; set; }
        //public string Type { get; set; }
        
    }
}
