﻿using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Schema.Track
{
    public class TrackResolver
    {
        private readonly SpotifyClient SpotifyClient;

        public TrackResolver(SpotifyClient spotifyClient)
        {
            SpotifyClient = spotifyClient;
        }
        public List<FullTrack> Tracks(List<String> ids)
        {
            List<FullTrack> tracks = new List<FullTrack>();
            foreach (String id in ids)
            {
                FullPlaylist playlist = SpotifyClient.Playlists.Get(id).Result;
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
