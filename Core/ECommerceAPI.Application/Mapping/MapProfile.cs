using AutoMapper;
using ECommerceAPI.Application.DTOs.BasketItemDTOs;
using ECommerceAPI.Application.DTOs.CategoryDTOs;
using ECommerceAPI.Application.DTOs.OrderDTOs;
using ECommerceAPI.Application.DTOs.ProductDTOs;
using ECommerceAPI.Application.DTOs.RoleDTOs;
using ECommerceAPI.Application.DTOs.UserDTOs;
using ECommerceAPI.Application.Features.Commands.BasketCommands.AddItemToBasket;
using ECommerceAPI.Application.Features.Commands.BasketCommands.UpdateQuantity;
using ECommerceAPI.Application.Features.Commands.CategoryCommands.CreateCategory;
using ECommerceAPI.Application.Features.Commands.CategoryCommands.UpdateCategory;
using ECommerceAPI.Application.Features.Commands.ProductCommands.CreateProduct;
using ECommerceAPI.Application.Features.Commands.ProductCommands.UpdateProduct;
using ECommerceAPI.Application.Features.Commands.UserCommands.CreateUser;
using ECommerceAPI.Application.Features.Queries.CategoryQueries.GetAllCategories;
using ECommerceAPI.Application.Features.Queries.OrderQueries.GetAllOrders;
using ECommerceAPI.Application.Features.Queries.OrderQueries.GetByIdOrder;
using ECommerceAPI.Application.Features.Queries.ProductImageFileQueries.GetProductImages;
using ECommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts;
using ECommerceAPI.Application.Features.Queries.ProductQueries.GetByIdProduct;
using ECommerceAPI.Application.Features.Queries.RoleQueries.GetAllRoles;
using ECommerceAPI.Application.Features.Queries.RoleQueries.GetByIdRole;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Identity;

namespace ECommerceAPI.Application.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<CreateProductCommandRequest, CreateProductDto>();
            CreateMap<Product,GetAllProductsQueryResponse>();
            CreateMap<UpdateProductCommandRequest, UpdateProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, GetProductDto>();
            CreateMap<GetProductDto, GetByIdProductQueryResponse>();


            CreateMap<CreateCategoryCommandRequest, CreateCategoryDto>();
            CreateMap<Category, GetAllCategoriesQueryResponse>();
            CreateMap<UpdateCategoryCommandRequest, UpdateCategoryDto>(); 
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, GetCategoryDto>(); 
            CreateMap<GetCategoryDto, GetAllCategoriesQueryResponse>(); 

            CreateMap<CreateUserCommandRequest, CreateUserDto>();
            CreateMap<CreateUserDto, AppUser>();
            CreateMap<AppUser, UserDto>();


            CreateMap<Product, GetProductDto>(); 
            CreateMap<ProductImageFile, GetProductImagesQueryResponse>(); 

            CreateMap<AddItemToBasketCommandRequest, CreateBasketItemDto>(); 
            CreateMap<UpdateQuantityCommandRequest, UpdateBasketItemDto>(); 

            CreateMap<GetAllOrdersDto, GetAllOrdersQueryResponse>(); 
            CreateMap<Order, GetSingleOrderDto>(); 
            CreateMap<GetSingleOrderDto, GetByIdOrderQueryResponse>();

            CreateMap<AppRole, RoleDto>();
            CreateMap<RoleDto, GetByIdRoleQueryResponse>();
            CreateMap<RoleDto, GetAllRolesQueryResponse>();



        }
    }
}
