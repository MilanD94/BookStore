using AutoMapper;

namespace BookStore.Application.Categories.Common
{
    public class CategoryProfileMapper : Profile
    {
        public CategoryProfileMapper()
        {
            CreateMap<Models.Category, DTOs.CategoryRepresentation>();
        }
    }
}
