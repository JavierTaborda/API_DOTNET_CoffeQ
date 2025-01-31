using API_CoffeQ.DTOs;
using API_CoffeQ.Models;
using AutoMapper;

namespace API_CoffeQ.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Payment, PaymentDTO>();
            CreateMap<PaymentDTO, Payment>();

            CreateMap<OrderDetail, OrderDetailDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.IdProductNavigation!.Name));
            CreateMap<OrderDetailDTO, OrderDetail>();

            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.IdCustomerNavigation!.Name));

            CreateMap<OrderDTO, Order>();


        }
    }

}
