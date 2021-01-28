using PlaylistComparer.StreamingServices.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlaylistComparer.StreamingServices.Mappers
{
    public class UserMapper
    {
        public static UserModel MapSpotifyUserToUserModel(PublicUser spotifyUser)
        {

            return new UserModel()
            {
                Id = spotifyUser.Id,
                Name = spotifyUser.DisplayName,
                Href = spotifyUser.Href,
                Uri = spotifyUser.Uri,
                Followers = spotifyUser.Followers?.Total,
                //Images = spotifyUser.Images?.Select(x=>x.Url).ToList(),
            };
        }
        public static UserModel MapSpotifyUserToUserModel(PrivateUser spotifyUser)
        {

            return new UserModel()
            {
                Id = spotifyUser.Id,
                Name = spotifyUser.DisplayName,
                Href = spotifyUser.Href,
                Uri = spotifyUser.Uri,
                Followers = spotifyUser.Followers?.Total,
                //Images = spotifyUser.Images?.Select(x=>x.Url).ToList(),
            };
        }
    }
}
