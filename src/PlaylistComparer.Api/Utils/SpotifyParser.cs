using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Utils
{
    public class SpotifyParser
    {
        public String parse(String uri)
        {
            String[] id = uri.Split("playlist/");
            return id.Last();
        }
    }
}
