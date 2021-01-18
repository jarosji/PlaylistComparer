﻿using PlaylistComparer.Api;
using PlaylistComparer.Api.Models;
using PlaylistComparer.Api.Utils;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Schema.Track
{
    public class TrackResolver
    {
        private readonly SpotifyClientBuilder SpotifyClientBuilder;
        private readonly SpotifyParser SpotifyParser;

        public TrackResolver(SpotifyClientBuilder spotifyClientBuilder, SpotifyParser spotifyParser)
        {
            SpotifyClientBuilder = spotifyClientBuilder;
            SpotifyParser = spotifyParser;
        }
        public async Task<List<FullTrack>> Tracks(List<String> ids)
        {
            var spotify = await SpotifyClientBuilder.BuildClient();
            List<FullTrack> tracks = new List<FullTrack>();
            foreach (String id in ids)
            {
                String parsedId = SpotifyParser.parse(id);
                FullPlaylist playlist = await spotify.Playlists.Get(parsedId);
                foreach (PlaylistTrack<IPlayableItem> item in playlist.Tracks.Items)
                {
                    if (item.Track is FullTrack track)
                    {
                        tracks.Add(track);
                    }
                }
            }

            return tracks.GroupBy(x=>x.Id)
                .Where(x=>x.Count()==ids.Count)
                .Select(x=> x.First())
                .ToList();
        }
    }
}
