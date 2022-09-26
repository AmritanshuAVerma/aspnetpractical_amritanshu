using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlbumAPI.Model;

namespace AlbumAPI.Data
{
    public class AlbumAPIContext : DbContext
    {
        public AlbumAPIContext (DbContextOptions<AlbumAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AlbumAPI.Model.AlbumModel> AlbumModel { get; set; } = default!;
    }
}
