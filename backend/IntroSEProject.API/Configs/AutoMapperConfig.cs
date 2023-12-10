using AutoMapper;
using IntroSEProject.API.Models;
using IntroSEProject.Models;

namespace IntroSEProject.API.Configs
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RegisterModel, User>().ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<ItemModel, Item>().ReverseMap();
<<<<<<< HEAD
            CreateMap<LoginModel, User>().ReverseMap();
=======
            CreateMap<OrderModel, Order>().ReverseMap();
            CreateMap<SeatReservationModel, SeatReservation>().ReverseMap();
            CreateMap<OrderItemModel, OrderItem>().ReverseMap();
            CreateMap<PaymentModel, Payment>().ReverseMap();
            CreateMap<CartItemModel, CartItem>().ReverseMap();
            CreateMap<ReviewModel, Review>().ReverseMap();
>>>>>>> c7a02caaf4ad4b41415d56d31f01ff117277cf42
        }
       
    }
}
