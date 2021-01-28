using PlaylistComparer.StreamingServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services
{
    public interface IArtistService
    {
        Task<List<ArtistModel>> GetArtists(string id);
    }
}
