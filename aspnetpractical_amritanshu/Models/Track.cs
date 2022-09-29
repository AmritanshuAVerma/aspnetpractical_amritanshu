using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace aspnetpracticalWeb.Models
{
    public class Track
    {
        
        public int TrackId { get; set; }

        public string TrackName { get; set; }

        public int AlbumId { get; set; }

        public int MediaTypeId { get; set; }
      
        public string Composer { get; set; }

        public int Milliseconds { get; set; }
       
        public decimal UnitPrice { get; set; }

        public virtual Album AlbumID { get; set; }
    
        //public virtual MediaType MediaType { get; set; }
     
    }
}