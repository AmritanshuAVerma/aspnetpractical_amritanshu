using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicWebApp.Models;

namespace MusicWebApp.Data
{
    public class MusicWebAppContext : DbContext
    {
        public MusicWebAppContext (DbContextOptions<MusicWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<MusicWebApp.Models.Album> Album { get; set; } = default!;
        public DbSet<MusicWebApp.Models.Track> Track { get; set; } = default!;
    }
}
