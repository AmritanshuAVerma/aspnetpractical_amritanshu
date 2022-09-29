using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aspnetpracticalWeb.Models;

namespace aspnetpracticalWeb.Data
{
    public class aspnetpracticalWebContext : DbContext
    {
        public aspnetpracticalWebContext (DbContextOptions<aspnetpracticalWebContext> options)
            : base(options)
        {
        }

        public DbSet<aspnetpracticalWeb.Models.Album> Album { get; set; } = default!;
    }
}
