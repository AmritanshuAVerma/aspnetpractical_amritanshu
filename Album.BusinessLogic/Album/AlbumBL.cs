using Album.BusinessLogic.IAlbum;
using Album.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Album.BusinessLogic.Model;
using AutoMapper;
using Album.Service.Model;

namespace Album.BusinessLogic.Album
{
    public class AlbumBL : IAlbumBL
    {
        private readonly IAlbumService albumService;
        private readonly IMapper _mapper;

        public AlbumBL(IAlbumService albumService, IMapper mapper)
        {
            this.albumService = albumService;
            this._mapper = mapper;
        }

        public async Task<List<AlbumDto>> GetAllAlbums(CancellationToken cancellationToken)
        {            
            return _mapper.Map<List<AlbumDto>>(await albumService.GetAllAlbums(cancellationToken));            
        }

        public async Task<bool> UpdateAlbum(AlbumDto albumDto, CancellationToken cancellationToken)
        {
            return await albumService.UpdateAlbum(_mapper.Map<AlbumModel>(albumDto), cancellationToken);
        }

        public async Task<List<AlbumDto>> GetAlbumTrackList(List<AlbumDto> albumDto, CancellationToken cancellationToken)
        {
            var response= await albumService.GetAlbumTrack(_mapper.Map<List<AlbumModel>>(albumDto), cancellationToken);
            var result = _mapper.Map<List<AlbumDto>>(response);
            return result;
        }
    }
}
