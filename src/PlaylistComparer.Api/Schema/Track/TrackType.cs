using HotChocolate.Types;
using PlaylistComparer.Api.Factories;
using PlaylistComparer.StreamingServices.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Schema.Track
{
    public class TrackType : ObjectType<TrackModel>
    {
        protected override void Configure(IObjectTypeDescriptor<TrackModel> descriptor)
        {
            descriptor.Field(x => x.Album).ResolveWith<TrackResolvers>(x=>x.GetAlbum(default));
            descriptor.Field(x => x.Artists).ResolveWith<TrackResolvers>(x => x.GetArtists(default));
        }
        private class TrackResolvers
        {
            private readonly StreamingServicesFactory Factory;
            public TrackResolvers(StreamingServicesFactory factory)
            {
                Factory = factory;
            }
            public async Task<AlbumModel> GetAlbum(TrackModel track)
            {
                return await Factory.GetStramingService(track.Href).AlbumService.GetAlbum(track.Id);
            }
            public async Task<List<ArtistModel>> GetArtists(TrackModel track)
            {
                return await Factory.GetStramingService(track.Href).ArtistService.GetArtists(track.Id);
            }
        }
    }
}