using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistComparer.StreamingServices.Models
{
    public class TrackModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int PlayTime { get; set; }
        public string Href { get; set; }
        public string Uri { get; set; }
        public List<ArtistModel> Artists { get; set; }
        public AlbumModel Album { get; set; }


        //public int TrackNumber { get; set; }
        //public string PreviewUrl { get; set; }
        //public int Popularity { get; set; }
        //public Dictionary<string, string> Restrictions { get; set; }
        //public LinkedTrack LinkedFrom { get; set; }
        //public bool IsPlayable { get; set; }
        //public Dictionary<string, string> ExternalUrls { get; set; }
        //public Dictionary<string, string> ExternalIds { get; set; }
        //public bool Explicit { get; set; }
        //public int DiscNumber { get; set; }
        //public List<string> AvailableMarkets { get; set; }
        //public string Href { get; set; }
        //public bool IsLocal { get; set; }
    }
}
