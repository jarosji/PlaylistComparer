using PlaylistComparer.Spotify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.Spotify.Services
{
    public interface IPlaylistService
    {
        Task<PlaylistModel> GetPlaylistAsync(String id);
        Task<List<PlaylistModel>> GetPlaylistsAsync(List<String> ids);
        Task<PlaylistModel> RemoveDuplicatesAsync(String id);
        Task<bool> CreatePlaylistAsync(PlaylistInput input);
    }
}
