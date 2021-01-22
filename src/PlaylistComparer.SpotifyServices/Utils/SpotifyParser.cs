using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Spotify.Utils
{
    public static class SpotifyParser
    {
        public static String Parse(String uri)
        {
            if (!String.IsNullOrEmpty(uri))
            {
                String[] id = uri.Split("playlist/");
                return id.Last();
            }
            return "";
        }
    }
}
