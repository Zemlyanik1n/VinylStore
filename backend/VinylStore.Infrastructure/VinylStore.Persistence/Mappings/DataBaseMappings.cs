using AutoMapper;
using VinylStore.Core.Models;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Mappings;

public class DataBaseMappings : Profile
{
    public DataBaseMappings()
    {
        CreateMap<Album, AlbumEntity>().ReverseMap();
        CreateMap<Cart, CartEntity>().ReverseMap();
        CreateMap<CartItem, CartItemEntity>().ReverseMap();
        CreateMap<Genre, GenreEntity>().ReverseMap();
        CreateMap<VinylPlateEntity, VinylPlate>().ReverseMap();
        CreateMap<Track, TrackEntity>().ReverseMap();
        CreateMap<DeliveryAddressEntity, DeliveryAddress>().ReverseMap();
        CreateMap<Order, OrderEntity>().ReverseMap();
        CreateMap<OrderItem, OrderItemEntity>().ReverseMap();
        CreateMap<User, UserEntity>()
            .ForMember(dest => dest.Roles, opt => opt.Ignore())
            .ReverseMap()
            .ConstructUsing(src => User.Create(
                src.Id,
                src.Email,
                src.Password
            ).Value);
    }
}