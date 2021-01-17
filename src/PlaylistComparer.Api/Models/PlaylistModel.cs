using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Models
{
    public class PlaylistModel : FullPlaylist
    {
        public PlaylistModel(FullPlaylist playlist)
        {
            Collaborative = playlist.Collaborative;
            Description = playlist.Description;
            ExternalUrls = playlist.ExternalUrls;
            Followers = playlist.Followers;
            Href = playlist.Href;
            Id = playlist.Id;
            Images = playlist.Images;
            Name = playlist.Name;
            Owner = playlist.Owner;
            Public = playlist.@Public;
            SnapshotId = playlist.SnapshotId;
            Tracks = playlist.Tracks;
            Type = playlist.Type;
            Uri = playlist.Uri;
        }
        public int NumberOfSongs { get; set; }
        public int PlayTime { get; set; }
        public int Duplicates { get; set; }
    }
}
