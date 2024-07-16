using AutoMapper;
using Ecommerce.Core.Entities.DTO;
using Ecommerce.Core.Entities;

namespace Ecommerce.API.mapping_profile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Products, ProductDTO>()
                .ForMember(To => To.Category_Name, from => from.MapFrom(x => x.Category != null ? x.Category.Name : null));
            CreateMap<Products, ProductPostDTO>()
            .ForMember(dest => dest.Category_Id, opt => opt.MapFrom(src => src.Category != null ? src.Category.Id : (int?)null));
        


    }



    }
}
