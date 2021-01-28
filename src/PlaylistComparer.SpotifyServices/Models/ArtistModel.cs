using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistComparer.StreamingServices.Models
{
    public class ArtistModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public string Uri { get; set; }

        //public Dictionary<string, string> ExternalUrls { get; set; }
        //public string Type { get; set; }
    }
}
