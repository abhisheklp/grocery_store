using AutoMapper;
using GroceryStore.Backend.Business.DTO;
using GroceryStore.Backend.Business.DTO.AccountDTO;
using GroceryStore.Backend.Presentation.Models;
using GroceryStore.Backend.Presentation.Models.AccountModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Presentation.Web_Profiles
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<ProductModel, ProductDTO>().ReverseMap();

            CreateMap<CategoryModel, CategoryDTO>().ReverseMap();

            CreateMap<LoginModel, LoginDTO>().ReverseMap();

            CreateMap<SignUpModel, SignUpDTO>().ReverseMap();

            CreateMap<CartModel, CartDTO>().ReverseMap();

            CreateMap<OrderModel, OrderDTO>().ReverseMap();

            CreateMap<ReviewModel, ReviewDTO>().ReverseMap();
        }
    }
}
