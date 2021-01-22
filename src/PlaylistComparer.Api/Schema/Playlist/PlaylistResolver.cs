using PlaylistComparer.Spotify.Models;
using PlaylistComparer.Spotify.Services;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Spotify.Schema.Playlist
{
    public class PlaylistResolver
    {
        private readonly IPlaylistService PlaylistService;

        public PlaylistResolver(IPlaylistService playlistService)
        {
            PlaylistService = playlistService;
        }
        public async Task<PlaylistModel> Playlist(String id)
        {
            return await PlaylistService.GetPlaylistAsync(id);
        }
        public async Task<List<PlaylistModel>> Playlists(List<String> ids)
        {
            return await PlaylistService.GetPlaylistsAsync(ids);
        }

        public async Task<PlaylistModel> RemoveDuplicates(String id)
        {
            return await PlaylistService.RemoveDuplicatesAsync(id);
        }
        public async Task<bool> CreatePlaylist(PlaylistInput input)
        {
            await PlaylistService.CreatePlaylistAsync(input);
            return true;
        }
    }
}