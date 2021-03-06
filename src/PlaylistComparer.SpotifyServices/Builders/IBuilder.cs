﻿using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Builders
{
    public interface IBuilder
    {
        Task<SpotifyClient> BuildClient();
    }
}
