using PlaylistComparer.StreamingServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services
{
    public interface IAlbumService
    {
        Task<AlbumModel> GetAlbum(string id);
    }
}
