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
            foreach (String id in ids)
            {
                playlists.Add(new PlaylistModel(spotify.Playlists.Get(id).Result));
            }
            foreach (PlaylistModel playlist in playlists)
            {
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
                playlist.Duplicates = tracks.GroupBy(x => x.Id).Where(x => x.Count() > 1).Sum(x => 1);
            }
            return playlists;
        }
        public async Task<bool> RenamePlaylist(String id, String name)
        {
            var spotify = await SpotifyClientBuilder.BuildClient();
            PlaylistChangeDetailsRequest change = new PlaylistChangeDetailsRequest();
            change.Name = name;
            await spotify.Playlists.ChangeDetails(id, change);
            return true;
        }
        public async Task<bool> RemoveDuplicates(String id)
        {
            var spotify = await SpotifyClientBuilder.BuildClient();
            PlaylistModel playlist = new PlaylistModel(spotify.Playlists.Get(id).Result);
            List<FullTrack> tracks = new List<FullTrack>();
            List<int> positions = new List<int>();
            foreach (PlaylistTrack<IPlayableItem> item in playlist.Tracks.Items)
            {
                if (item.Track is FullTrack track)
                {
                    tracks.Add(track);
                }
            }
            var duplicates = tracks
                .GroupBy(g => g.Id)
                .Where(g => g.Count() > 1)
                .Select((t, i) => new { Index = i, Track = t }).ToList();
            foreach (var duplicate in duplicates)
            {
                for(int i =1;i<duplicate.Track.Count();i++)
                {
                    positions.Add(tracks.IndexOf(duplicate.Track.ElementAt(i)));
                }
            }
            positions.RemoveAll(x=>x.Equals(-1));
            PlaylistRemoveItemsRequest removeItemsRequest = new PlaylistRemoveItemsRequest
            {
                Positions = positions,
                SnapshotId = playlist.SnapshotId
            };
            await spotify.Playlists.RemoveItems(id, removeItemsRequest);

            return true;
        }
    }
}