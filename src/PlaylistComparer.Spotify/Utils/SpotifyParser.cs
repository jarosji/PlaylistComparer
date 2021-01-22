using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Utils
{
    public class SpotifyParser
    {
        public String Parse(String uri)
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
