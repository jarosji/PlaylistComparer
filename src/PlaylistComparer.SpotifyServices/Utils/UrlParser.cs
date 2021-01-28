using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Utils
{
    public static class UrlParser
    {//https://music.youtube.com/playlist?list=PLInxvsJ9KhE7Y9EZnOE-PjhoxOIzYprsi
        public static String Spotify(String uri)
        {
            if (!String.IsNullOrEmpty(uri))
            {
                String[] id = uri.Split("playlist/");
                return id.Last();
            }
            return "";
        }

        public static String Youtube(String uri)
        {
            if (!String.IsNullOrEmpty(uri))
            {
                String[] id = uri.Split("list=");
                return id.Last();
            }
            return "";
        }
    }
}
