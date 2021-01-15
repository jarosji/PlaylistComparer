using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Schema.Track
{
    public class TrackResolver
    {
        public List<FullTrack> Tracks(List<String> ids)
        {
            var config = SpotifyClientConfig
                .CreateDefault()
                .WithAuthenticator(new ClientCredentialsAuthenticator("c8bc902470624f89bb3a70aab0fedc0b", "9f96b0c0d4d0425cb5166bccd6189e30"));
            var spotify = new SpotifyClient(config);

            List<FullTrack> tracks = new List<FullTrack>();
            foreach (String id in ids)
            {
                FullPlaylist playlist = spotify.Playlists.Get(id).Result;
                foreach (PlaylistTrack<IPlayableItem> item in playlist.Tracks.Items)
                {
                    if (item.Track is FullTrack track)
                    {
                        tracks.Add(track);
                    }
                }
            }
            return tracks.GroupBy(x=>x.Id).Where(x=>x.Count()==ids.Count).Select(x=> x.First()).ToList();
        }
    }
}
