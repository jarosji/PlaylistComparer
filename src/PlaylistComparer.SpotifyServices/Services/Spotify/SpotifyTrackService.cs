using PlaylistComparer.StreamingServices.Builders;
using PlaylistComparer.StreamingServices.Models;
using PlaylistComparer.StreamingServices.Mappers;
using PlaylistComparer.StreamingServices.Utils;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services.Spotify
{
    public class SpotifyTrackService : ITrackService
    {
        private readonly IBuilder SpotifyClientBuilder;

        public SpotifyTrackService(IBuilder spotifyClientBuilder)
        {
            SpotifyClientBuilder = spotifyClientBuilder;
        }
        public async Task<List<TrackModel>> GetTracksAsync(String id)
        {
            var spotify = await SpotifyClientBuilder.BuildClient();
            
            String parsedId = UrlParser.Spotify(id);
            var playlistItems = await spotify.Playlists.GetItems(parsedId);
            List<PlaylistTrack<IPlayableItem>> allPages = (List<PlaylistTrack<IPlayableItem>>)await spotify.PaginateAll(playlistItems);

            List<TrackModel> tracks = TrackMapper.MapSpotifyTrackToTrackModel(allPages).ToList();

            return tracks;
        }
        public List<int> GetDuplicateTracks(List<TrackModel> tracks)
        {
            List<int> positions = new List<int>();
            var duplicates = tracks
                .GroupBy(g => g.Id)
                .Where(g => g.Count() > 1)
                .Select((t, i) => new { Index = i, Track = t }).ToList();
            foreach (var duplicate in duplicates)
            {
                for (int i = 1; i < duplicate.Track.Count(); i++)
                {
                    positions.Add(tracks.IndexOf(duplicate.Track.ElementAt(i)));
                }
            }
            return positions;
        }
        public async Task<List<TrackModel>> GetCommonTracksAsync(List<String> ids)
        {
            var spotify = await SpotifyClientBuilder.BuildClient();
            List<TrackModel> tracks = new List<TrackModel>();
            foreach (String id in ids)
            {
                String parsedId = UrlParser.Spotify(id);
                FullPlaylist playlist = await spotify.Playlists.Get(parsedId);
                List<PlaylistTrack<IPlayableItem>> allPages = (List<PlaylistTrack<IPlayableItem>>) await spotify.PaginateAll(playlist.Tracks);

                tracks = tracks.Concat(TrackMapper.MapSpotifyTrackToTrackModel(allPages)).ToList();
            }

            tracks = tracks.GroupBy(x => x.Id)
                .Where(x => x.Count() > 1)
                .Select(x => x.First())
                .ToList();
            
            return tracks;
        }

        public async Task<List<TrackModel>> GetTopTracksAsync()
        {
            var spotify = await SpotifyClientBuilder.BuildClient();

            var page = await spotify.Personalization.GetTopTracks(new PersonalizationTopRequest() { TimeRangeParam = PersonalizationTopRequest.TimeRange.LongTerm});
            //Probably better way - linqAsync package in Nuget.
            var allPages = await spotify.Paginate(page).ToListAsync();
            List<TrackModel> tracks = TrackMapper.MapSpotifyTrackToTrackModel(allPages);

            return tracks;
        }
    }
}
