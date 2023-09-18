using AutoMapper;
using Pets.Domain.ViewModels;
using Pets.Repository.Entities;

namespace Pets.Domain.Mapper
{
    /// <summary>
    /// Mapper Profile
    /// </summary>
    public class MapperProfile : Profile
    {
        /// <summary>
        /// Class
        /// </summary>
        public MapperProfile()
        {
            CreateMap<PetViewModel, Pet>().ReverseMap();
        }
    }
}
