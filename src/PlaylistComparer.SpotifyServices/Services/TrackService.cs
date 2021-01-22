using PlaylistComparer.Spotify.Builders;
using PlaylistComparer.Spotify.Utils;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.Spotify.Services
{
    public class TrackService : ITrackService
    {
        private readonly IBuilder SpotifyClientBuilder;

        public TrackService(IBuilder spotifyClientBuilder)
        {
            SpotifyClientBuilder = spotifyClientBuilder;
        }
        public async Task<List<FullTrack>> GetCommonTracksAsync(List<String> ids)
        {
            var spotify = await SpotifyClientBuilder.BuildClient();
            List<FullTrack> tracks = new List<FullTrack>();
            foreach (String id in ids)
            {
                String parsedId = SpotifyParser.Parse(id);
                FullPlaylist playlist = await spotify.Playlists.Get(parsedId);
                List<PlaylistTrack<IPlayableItem>> allPages = (List<PlaylistTrack<IPlayableItem>>)await spotify.PaginateAll(playlist.Tracks);
                playlist.Tracks.Items = allPages;

                foreach (PlaylistTrack<IPlayableItem> item in playlist.Tracks.Items)
                {
                    if (item.Track is FullTrack track)
                    {
                        tracks.Add(track);
                    }
                }
            }

            return tracks.GroupBy(x => x.Id)
                .Where(x => x.Count() == ids.Count)
                .Select(x => x.First())
                .ToList();
        }
    }
}
