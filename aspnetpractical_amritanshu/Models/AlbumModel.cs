﻿using System.Configuration;

namespace aspnetpractical_amritanshu.Models
{
    public class AlbumModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Artist { get; set; }

        public DateTime PublishedDate { get; set; }

        public int Price { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
