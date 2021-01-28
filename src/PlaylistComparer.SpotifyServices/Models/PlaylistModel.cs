using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistComparer.StreamingServices.Models
{
    public class PlaylistModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PlayTime { get; set; }
        public int Followers { get; set; }
        public List<ImageModel> Images { get; set; }
        public List<TrackModel> Tracks { get; set; }
        public List<int> DuplicatePositions { get; set; }
        public UserModel Owner { get; set; }
        public string Href { get; set; }
        public string Uri { get; set; }

        //Spotify

        //public bool Collaborative { get; set; }
        //public Dictionary<string, string> ExternalUrls { get; set; }
        //public bool Public { get; set; }
        //public string SnapshotId { get; set; }
        //public Paging<PlaylistTrack<IPlayableItem>>? Tracks { get; set; }
        //public string Type { get; set; }

        //YouTube

        //public PlaylistContentDetails ContentDetails { get; set; }
        //public string ETag { get; set; }
        //public string Kind { get; set; }
        //public IDictionary<string, PlaylistLocalization> Localizations { get; set; }
        //public virtual PlaylistPlayer Player { get; set; }
        //public virtual PlaylistSnippet Snippet { get; set; }
        //public virtual PlaylistStatus Status { get; set; }
    }
}
