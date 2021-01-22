using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.Spotify.Services
{
    public interface ITrackService
    {
        public Task<List<FullTrack>> GetCommonTracksAsync(List<String> ids);
    }
}
