using Google.Apis.YouTube.v3.Data;
using PlaylistComparer.StreamingServices.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlaylistComparer.StreamingServices.Mappers
{
    public static class PlaylistMapper
    {
        public static PlaylistModel MapSpotifyPlaylistToPlaylistModel(FullPlaylist spotifyPlaylist)
        {
            PlaylistModel playlist = new PlaylistModel()
            {
                Id = spotifyPlaylist.Id,
                Name = spotifyPlaylist.Name,
                Description = spotifyPlaylist.Description,
                //Images = spotifyPlaylist.Images.Select(x => x.Url).ToList(),
                //Tracks = TrackMapper.MapSpotifyTrackToTrackModel(spotifyPlaylist.Tracks.Items),
                //Owner = UserMapper.MapSpotifyUserToUserModel(spotifyPlaylist.Owner),
                Followers = spotifyPlaylist.Followers.Total,
                Href = spotifyPlaylist.Href,
                Uri = spotifyPlaylist.Uri
            };
            //playlist.PlayTime = playlist.Tracks.Sum(x => x.PlayTime);
            return playlist;
        }

        public static PlaylistModel MapYouTubeToPlaylistModel(Playlist youTubePlaylist)
        {
            return new PlaylistModel()
            {
                Id = youTubePlaylist.Id,
                Name = youTubePlaylist.Snippet.Title,
                Description = youTubePlaylist.Snippet.Description,
                Href = "https://music.youtube.com/playlist?list=" + youTubePlaylist.Id,
                //Images = youTubePlaylist.Snippet,
                //Tracks = TrackMapper.MapSpotifyTrackToTrackModel(youTubePlaylist)
            };
        }
    }
}
