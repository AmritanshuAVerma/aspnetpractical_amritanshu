using Microsoft.AspNetCore.Mvc.Formatters;
using MusicWebApp.Models;

namespace MusicWebApp.Models
{
    public class Track
    {
        
        public int TrackId { get; set; }

        public string TrackName { get; set; }

        public int AlbumId { get; set; }

     
    }
}