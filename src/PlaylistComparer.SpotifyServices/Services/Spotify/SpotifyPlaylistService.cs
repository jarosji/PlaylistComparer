using PlaylistComparer.StreamingServices.Builders;
using PlaylistComparer.StreamingServices.Models;
using PlaylistComparer.StreamingServices.Utils;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using Google.Apis.YouTube.v3.Data;
using PlaylistComparer.StreamingServices.Mappers;

namespace PlaylistComparer.StreamingServices.Services.Spotify
{
    public class SpotifyPlaylistService : IPlaylistService
    {
        private readonly IBuilder SpotifyClientBuilder;

        public SpotifyPlaylistService(IBuilder spotifyClientBuilder)
        {
            SpotifyClientBuilder = spotifyClientBuilder;
        }
        public async Task<PlaylistModel> GetPlaylistAsync(String id)
        {
            SpotifyClient spotify = await SpotifyClientBuilder.BuildClient();
            id = UrlParser.Spotify(id);

            //PlaylistGetRequest req = new PlaylistGetRequest() {
            //    Fields = { "id","name","description","playTime" }
            //};
            FullPlaylist fullPlaylist = await spotify.Playlists.Get(id);
            List<PlaylistTrack<IPlayableItem>> allPages = (List<PlaylistTrack<IPlayableItem>>) await spotify.PaginateAll(fullPlaylist.Tracks);
            fullPlaylist.Tracks.Items = allPages;

            PlaylistModel playlist = PlaylistMapper.MapSpotifyPlaylistToPlaylistModel(fullPlaylist);

            return playlist;
        }
        public async Task<List<PlaylistModel>> GetPlaylistsAsync(List<String> ids)
        {
            SpotifyClient spotify = await SpotifyClientBuilder.BuildClient();
            List<PlaylistModel> playlists = new List<PlaylistModel>();
            foreach (String id in ids)
            {
                String parsedId = UrlParser.Spotify(id);

                FullPlaylist fullPlaylist = await spotify.Playlists.Get(parsedId);
                List<PlaylistTrack<IPlayableItem>> allPages = (List<PlaylistTrack<IPlayableItem>>) await spotify.PaginateAll(fullPlaylist.Tracks);
                fullPlaylist.Tracks.Items = allPages;

                PlaylistModel playlist = PlaylistMapper.MapSpotifyPlaylistToPlaylistModel(fullPlaylist);
                playlists.Add(playlist);
            }
            return playlists;
        }
        public async Task<bool> CreatePlaylistAsync(PlaylistModel input)
        {
            SpotifyClient spotify = await SpotifyClientBuilder.BuildClient();
            List<String> uris = input.Tracks.Select(x => x.Href).ToList();

            PlaylistCreateRequest playlistCreate = new PlaylistCreateRequest(input.Name);
            FullPlaylist playlist = await spotify.Playlists.Create(spotify.UserProfile.Current().Result.Id, playlistCreate);

            PlaylistAddItemsRequest playlistAddItems = new PlaylistAddItemsRequest(uris);
            await spotify.Playlists.AddItems(playlist.Id, playlistAddItems);
            return true;
        }
        public async Task<PlaylistModel> RemoveDuplicatesAsync(String id)
        {
            SpotifyClient spotify = await SpotifyClientBuilder.BuildClient();
            id = UrlParser.Spotify(id);

            FullPlaylist fullPlaylist = await spotify.Playlists.Get(id);
            List<FullTrack> tracks = new List<FullTrack>();
            List<int> positions = new List<int>();
            foreach (PlaylistTrack<IPlayableItem> item in fullPlaylist.Tracks.Items)
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
                for (int i = 1; i < duplicate.Track.Count(); i++)
                {
                    positions.Add(tracks.IndexOf(duplicate.Track.ElementAt(i)));
                }
            }
            positions.RemoveAll(x => x.Equals(-1));
            PlaylistRemoveItemsRequest removeItemsRequest = new PlaylistRemoveItemsRequest
            {
                Positions = positions,
                SnapshotId = fullPlaylist.SnapshotId
            };
            await spotify.Playlists.RemoveItems(id, removeItemsRequest);

            return await GetPlaylistAsync(id);
        }
    }
}