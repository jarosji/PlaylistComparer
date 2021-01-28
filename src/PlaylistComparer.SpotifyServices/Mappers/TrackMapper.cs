using Google.Apis.YouTube.v3.Data;
using PlaylistComparer.StreamingServices.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistComparer.StreamingServices.Mappers
{
    public static class TrackMapper
    {
        public static List<TrackModel> MapSpotifyTrackToTrackModel(List<FullTrack> spotifyTrack)
        {
            List<TrackModel> tracks = new List<TrackModel>();
            foreach (FullTrack item in spotifyTrack)
            {
                tracks.Add(MapSpotifyTrackToTrackModel(item));
            }
            return tracks;
        }
        public static List<TrackModel> MapSpotifyTrackToTrackModel(List<PlaylistTrack<IPlayableItem>> spotifyTrack)
        {
            List<TrackModel> tracks = new List<TrackModel>();
            foreach (PlaylistTrack<IPlayableItem> item in spotifyTrack)
            {
                if (item.Track is FullTrack track)
                {
                    tracks.Add(MapSpotifyTrackToTrackModel(track));
                }
            }
            return tracks;
        }
        public static TrackModel MapSpotifyTrackToTrackModel(FullTrack spotifyTrack)
        {

            return new TrackModel()
            {
                Id = spotifyTrack.Id,
                Name = spotifyTrack.Name,
                PlayTime = spotifyTrack.DurationMs,
                Href = spotifyTrack.Href,
                Uri = spotifyTrack.Uri,
                Album = AlbumMapper.MapSpotifyAlbumToAlbumModel(spotifyTrack.Album),
                Artists = ArtistMapper.MapSpotifyArtistToArtistModel(spotifyTrack.Artists)
            };
        }

        public static List<TrackModel> MapYouTubeTrackToTrackModel(IList<PlaylistItem> youTubeTrack)
        {
            List<TrackModel> tracks = new List<TrackModel>();
            foreach (PlaylistItem item in youTubeTrack)
            {
                tracks.Add(MapYouTubeTrackToTrackModel(item));
            }
            return tracks;
        }
        public static TrackModel MapYouTubeTrackToTrackModel(PlaylistItem youTubeTrack)
        {

            return new TrackModel()
            {
                Id = youTubeTrack.Id,
                Name = youTubeTrack.Snippet.Title,
            };
        }
    }
}
