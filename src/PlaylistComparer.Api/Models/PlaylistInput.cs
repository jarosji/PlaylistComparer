using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Models
{
    public class PlaylistInput
    {
        public String Name { get; set; }
        public List<String> Uris { get; set; }
    }
}
