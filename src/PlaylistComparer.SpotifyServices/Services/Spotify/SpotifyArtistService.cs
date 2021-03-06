﻿using PlaylistComparer.StreamingServices.Builders;
using PlaylistComparer.StreamingServices.Mappers;
using PlaylistComparer.StreamingServices.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services.Spotify
{
    public class SpotifyArtistService : IArtistService
    {
        private readonly IBuilder SpotifyClientBuilder;
        public SpotifyArtistService(IBuilder spotifyClientBuilder)
        {
            SpotifyClientBuilder = spotifyClientBuilder;
        }

        public async Task<List<ArtistModel>> GetArtists(string id)
        {
            SpotifyClient spotify = await SpotifyClientBuilder.BuildClient();

            var track = await spotify.Tracks.Get(id);
            List<ArtistModel> artists = ArtistMapper.MapSpotifyArtistToArtistModel(track.Artists);

            return artists;
        }
    }
}
