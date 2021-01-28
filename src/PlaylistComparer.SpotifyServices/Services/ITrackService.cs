using PlaylistComparer.StreamingServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services
{
    public interface ITrackService
    {
        Task<List<TrackModel>> GetTracksAsync(String ids);
        List<int> GetDuplicateTracks(List<TrackModel> tracks);
        Task<List<TrackModel>> GetCommonTracksAsync(List<String> ids);
        Task<List<TrackModel>> GetTopTracksAsync();
    }
}
