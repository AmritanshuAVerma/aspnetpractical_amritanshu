using Album.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.BusinessLogic.IAlbum
{
    public interface IAlbumBL
    {
        Task<List<AlbumDto>> GetAllAlbums(CancellationToken cancellationToken);
        Task<bool> UpdateAlbum(AlbumDto albumDto, CancellationToken cancellationToken);
        Task<List<AlbumDto>> GetAlbumTrackList(List<AlbumDto> albumIds, CancellationToken cancellationToken);
    }
}
