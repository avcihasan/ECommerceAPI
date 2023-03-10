using AutoMapper;
using ECommerceAPI.Application.DTOs.ProductDTOs;
using ECommerceAPI.Application.Features.Commands.CategoryCommands.CreateCategory;
using ECommerceAPI.Application.Features.Commands.CategoryCommands.UpdateCategory;
using ECommerceAPI.Application.Features.Commands.ProductCommands.CreateProduct;
using ECommerceAPI.Application.Features.Commands.ProductCommands.UpdateProduct;
using ECommerceAPI.Application.Features.Commands.UserCommands.CreateUser;
using ECommerceAPI.Application.Features.Queries.CategoryQueries.GetAllCategories;
using ECommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts;
using ECommerceAPI.Application.Features.Queries.ProductQueries.GetByIdProduct;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Identity;

namespace ECommerceAPI.Application.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<CreateProductCommandRequest, Product>();
            CreateMap<Product,GetByIdProductQueryResponse>();
            CreateMap<Product,GetAllProductsQueryResponse>();
            CreateMap<UpdateProductCommandRequest, Product>();


            CreateMap<CreateCategoryCommandRequest,Category>();
            CreateMap<Category, GetAllCategoriesQueryResponse>();
            CreateMap<UpdateCategoryCommandRequest, Category>();

            CreateMap<CreateUserCommandRequest, AppUser>();


            CreateMap<Product, GetProductDto>();

            
            

        }
    }
}
