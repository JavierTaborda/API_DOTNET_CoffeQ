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

           
            CreateMap<Payment, PaymentDTO>()
                .ForMember(dest=>dest.CustomerName, opt=>opt.MapFrom(src=>src.IdOrderNavigation!.IdCustomerNavigation.Name));
            CreateMap<PaymentDTO, Payment>();

            CreateMap<OrderDetail, OrderDetailDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.IdProductNavigation!.Name));

            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.IdCustomerNavigation!.Name))
                .ForMember(dest => dest.OrderDetailsDTO, opt => opt.MapFrom(src => src.OrderDetails));

            //DTO to Entity

            CreateMap<ProductDTO, Product>();

            CreateMap<OrderDTO, Order>()
                 .ForMember(dest => dest.IdOrder, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetailsDTO));

            CreateMap<OrderDetailDTO, OrderDetail>()
                    .ForMember(dest => dest.IdOrderDetail, opt => opt.Ignore());

            CreateMap<CustomerDTO, Customer>();



        }
    }

}
