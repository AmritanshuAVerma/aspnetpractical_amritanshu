using AlbumAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumAPI.Services.Interfaces
{
    public interface IAlbumService
    {
        Task<List<AlbumDto>> GetAlbums(CancellationToken cancellationToken);
    }
}
