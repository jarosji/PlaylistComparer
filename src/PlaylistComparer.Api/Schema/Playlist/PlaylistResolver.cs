using PlaylistComparer.Api.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Schema.Playlist
{
    public class PlaylistResolver
    {
        private readonly SpotifyClientBuilder SpotifyClientBuilder;
        
        public PlaylistResolver(SpotifyClientBuilder spotifyClientBuilder)
        {
            SpotifyClientBuilder = spotifyClientBuilder;
        }
        public async Task<PlaylistModel> Playlist(String id)
        {
            var spotify = await SpotifyClientBuilder.BuildClient();

            PlaylistModel playlist = new PlaylistModel(spotify.Playlists.Get(id).Result);
            List<FullTrack> tracks = new List<FullTrack>();
            foreach (PlaylistTrack<IPlayableItem> item in playlist.Tracks.Items)
            {
                if (item.Track is FullTrack track)
                {
                    tracks.Add(track);
                    playlist.PlayTime += track.DurationMs;
                    playlist.NumberOfSongs += 1;
                }
            }
            playlist.Duplicates = tracks.GroupBy(x => x.Id).Where(x=>x.Count()>1).Sum(x => 1);
            return playlist;
        }
        public async Task<List<PlaylistModel>> Playlists(List<String> ids)
        {
            var spotify = await SpotifyClientBuilder.BuildClient();
            List<PlaylistModel> playlists = new List<PlaylistModel>();
            foreach(String id in ids)
            {
                playlists.Add(new PlaylistModel(spotify.Playlists.Get(id).Result));
            }
            return playlists;
        }
        public async Task<bool> renamePlaylist(String id, String name)
        {
            var spotify = await SpotifyClientBuilder.BuildClient();
            PlaylistChangeDetailsRequest change = new PlaylistChangeDetailsRequest();
            change.Name = name;
            await spotify.Playlists.ChangeDetails(id, change);
            return true;
        }
    }
}