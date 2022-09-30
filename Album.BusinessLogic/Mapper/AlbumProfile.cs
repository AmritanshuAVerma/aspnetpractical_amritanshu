using Album.BusinessLogic.Model;
using Album.Service.Model;
using AutoMapper;

namespace Album.BusinessLogic.Mapper
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<AlbumDto, AlbumModel>().ReverseMap();
        }
    }
}
