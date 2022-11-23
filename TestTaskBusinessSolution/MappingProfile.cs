using AutoMapper;
using TestTaskBusinessSolution.BLL.DTO;
using TestTaskBusinessSolution.DAL.Entities;
using TestTaskBusinessSolution.Models;

namespace TestTaskBusinessSolution
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, OrderViewModel>();
            CreateMap<ItemDTO, ItemViewModel>();
            CreateMap<Item, ItemDTO>();
            CreateMap<CreateItemViewModel, CreateItemDTO>();
            CreateMap<CreateItemDTO, Item>();
            CreateMap<ItemDTO, Item>();
            CreateMap<ItemViewModel, ItemDTO>();
            CreateMap<Provider, ProviderDTO>();
            CreateMap<OrderCreateViewModel, OrderDTO>()
                .ForMember(dest => dest.ProviderId, opt => opt.MapFrom(src => src.SelectedProvider));
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderViewModel, OrderDTO>();
        }
    }
}
