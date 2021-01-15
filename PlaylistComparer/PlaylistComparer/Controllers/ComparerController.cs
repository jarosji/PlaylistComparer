using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComparerController : Controller
    {
        public async Task<IActionResult> Get(String a, String b)
        {
            var config = SpotifyClientConfig
                .CreateDefault()
                .WithAuthenticator(new ClientCredentialsAuthenticator("c8bc902470624f89bb3a70aab0fedc0b", "9f96b0c0d4d0425cb5166bccd6189e30"));

            var spotify = new SpotifyClient(config);
            var playlistA = spotify.Playlists.Get(a).Result;
            var playlistB = spotify.Playlists.Get(b).Result;

            List<FullTrack> tracksA = new List<FullTrack>();
            List<FullTrack> tracksB = new List<FullTrack>();

            foreach (PlaylistTrack<IPlayableItem> item in playlistA.Tracks.Items)
            {
                if (item.Track is FullTrack track)
                {
                    tracksA.Add(track);
                }
            }

            foreach (PlaylistTrack<IPlayableItem> item in playlistB.Tracks.Items)
            {
                if (item.Track is FullTrack track)
                {
                    if(tracksA.Any(x=>x.Id.Equals(track.Id))) tracksB.Add(track);
                }
            }
            //Console.WriteLine(tracksA.Where(x => tracksB.Contains(x)));
            return Ok(tracksB.Select(x=>x.Name));
            //return Ok(tracksB.Select(x => x.Name));
        }
    }
}
