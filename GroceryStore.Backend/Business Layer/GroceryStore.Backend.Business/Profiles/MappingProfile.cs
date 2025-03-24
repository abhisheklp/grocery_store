using AutoMapper;
using GroceryStore.Backend.Business.DTO;
using GroceryStore.Backend.Business.DTO.AccountDTO;
using GroceryStore.Backend.DAL.Entities;
using GroceryStore.Backend.DAL.Entities.AccountEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Backend.Business.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, ProductEntity>().ReverseMap();

            CreateMap<CategoryDTO, CategoryEntity>().ReverseMap();

            CreateMap<LoginDTO, LoginEntity>().ReverseMap();

            CreateMap<SignUpDTO, SignUpEntity>().ReverseMap();

            CreateMap<CartDTO, CartEntity>().ReverseMap();

            CreateMap<OrderDTO, OrderEntity>().ReverseMap();

            CreateMap<ReviewDTO, ReviewEntity>().ReverseMap();
        }
    }
}
