using HotChocolate.Types;
using PlaylistComparer.StreamingServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlaylistComparer.Api.Factories;

namespace PlaylistComparer.Api.Schema.Playlist
{
    public class PlaylistType : ObjectType<PlaylistModel>
    {
        protected override void Configure(IObjectTypeDescriptor<PlaylistModel> descriptor)
        {
            descriptor.Field(x => x.Name).Type<StringType>();
            descriptor.Field(x => x.Tracks).ResolveWith<PlaylistResolvers>(x=>x.GetTracks(default));
            descriptor.Field(x => x.Images).ResolveWith<PlaylistResolvers>(x=>x.GetImages(default));
            descriptor.Field(x => x.Owner).ResolveWith<PlaylistResolvers>(x => x.GetOwner(default));
            //descriptor.Field(x => x.DuplicatePositions).ResolveWith<PlaylistResolvers>(x => x.GetDuplicateTracks(default));
        }
    

        private class PlaylistResolvers
        {
            private readonly StreamingServicesFactory Factory;
            public PlaylistResolvers(StreamingServicesFactory factory)
            {
                Factory = factory;
            }
            public async Task<List<TrackModel>> GetTracks(PlaylistModel playlist)
            {
                return await Factory.GetStramingService(playlist.Href).TrackService.GetTracksAsync(playlist.Id);
            }
            public async Task<UserModel> GetOwner(PlaylistModel playlist)
            {
                return await Factory.GetStramingService(playlist.Href).UserService.GetOwner(playlist.Id);
            }
            //public List<int> GetDuplicateTracks(PlaylistModel playlist)
            //{
            //    return Factory.GetStramingService(playlist.Href).TrackService.GetDuplicateTracks(playlist.Tracks);
            //}
            public async Task<List<ImageModel>> GetImages(PlaylistModel playlist)
            {
                return await Factory.GetStramingService(playlist.Href).ImageService.GetPlaylistImages(playlist.Id);
            }
        }
    }
}
