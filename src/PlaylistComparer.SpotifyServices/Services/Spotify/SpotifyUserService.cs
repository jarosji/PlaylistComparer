using PlaylistComparer.StreamingServices.Builders;
using PlaylistComparer.StreamingServices.Mappers;
using PlaylistComparer.StreamingServices.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services.Spotify
{
    public class SpotifyUserService : IUserService
    {
        private readonly IBuilder SpotifyClientBuilder;
        public SpotifyUserService(IBuilder spotifyClientBuilder)
        {
            SpotifyClientBuilder = spotifyClientBuilder;
        }
        public async Task<UserModel> GetOwner(string id)
        {
            SpotifyClient spotify = await SpotifyClientBuilder.BuildClient();

            var req = new PlaylistGetRequest()
            {
                Fields = {"owner"}
            };
            var playlist = await spotify.Playlists.Get(id, req);
            PublicUser publicUser = playlist.Owner;

            UserModel user = UserMapper.MapSpotifyUserToUserModel(publicUser);

            return user;
        }
    }
}
