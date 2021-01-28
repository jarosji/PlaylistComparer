using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistComparer.StreamingServices.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        //public Dictionary<string, string> ExternalUrls { get; set; }
        public int? Followers { get; set; }
        public string Href { get; set; }
        public List<ImageModel> Images { get; set; }
        //public string Type { get; set; }
        public string Uri { get; set; }
    }
}