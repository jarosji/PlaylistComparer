using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Schema.Playlist
{
    public class PlaylistResolver
    {
        private readonly SpotifyClient SpotifyClient;
        public PlaylistResolver(SpotifyClient spotifyClient)
        {
            SpotifyClient = spotifyClient;
        }
        public FullPlaylist Playlist(String id)
        {
            FullPlaylist playlist = SpotifyClient.Playlists.Get(id).Result;
            return playlist;
        }
        public List<FullPlaylist> Playlists(List<String> ids)
        {
            List<FullPlaylist> playlists = new List<FullPlaylist>();
            foreach(String id in ids)
            {
                playlists.Add(SpotifyClient.Playlists.Get(id).Result);
            }
            return playlists;
        }
    }
}
