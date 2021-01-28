using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using PlaylistComparer.StreamingServices.Models;
using PlaylistComparer.StreamingServices.Mappers;
using PlaylistComparer.StreamingServices.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistComparer.StreamingServices.Services.YouTube
{
    public class YouTubePlaylistService : IPlaylistService
    {
        private readonly YouTubeService YouTubeService;
        public YouTubePlaylistService(YouTubeService youTubeService)
        {
            YouTubeService = youTubeService;
        }

        public async Task<PlaylistModel> GetPlaylistAsync(string id)
        {
            id = UrlParser.Youtube(id);
            PlaylistsResource res = YouTubeService.Playlists;

            var req = res.List(part: "snippet");
            req.Id = id;
            PlaylistListResponse playlistResponse = await req.ExecuteAsync();

            var tracks = YouTubeService.PlaylistItems.List(part: "snippet");
            tracks.PlaylistId = id;
            var tracksResponse = await tracks.ExecuteAsync();

            PlaylistModel playlist = PlaylistMapper.MapYouTubeToPlaylistModel(playlistResponse.Items[0]);
            playlist.Tracks = TrackMapper.MapYouTubeTrackToTrackModel(tracksResponse.Items);

            return playlist;
        }

        public async Task<List<PlaylistModel>> GetPlaylistsAsync(List<string> ids)
        {
            for(int i = 0; i < ids.Count(); i++)
            {
                ids[i] = UrlParser.Youtube(ids[i]) + ",";
            }
            List<PlaylistModel> playlists = new List<PlaylistModel>();
            
            PlaylistsResource res = YouTubeService.Playlists;
            var req = res.List(part: "snippet");
            req.Id = ids;
            PlaylistListResponse playlistResponse = await req.ExecuteAsync();

            foreach(Playlist item in playlistResponse.Items)
            {
                PlaylistModel playlist = PlaylistMapper.MapYouTubeToPlaylistModel(item);
                playlists.Add(playlist);
            }

            return playlists;
        }

        public Task<bool> CreatePlaylistAsync(PlaylistModel input)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistModel> RemoveDuplicatesAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
