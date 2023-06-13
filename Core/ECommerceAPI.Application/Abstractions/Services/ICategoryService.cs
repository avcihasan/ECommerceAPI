using ECommerceAPI.Application.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<List<GetCategoryDto>> GetAllCategoriesAsync();
        Task<bool> CreateCategoryAsync(CreateCategoryDto category);
        Task<bool> RemoveCategoryByIdAsync(string id);
        Task<bool> UpdateCategoryAsync(UpdateCategoryDto category);
    }
}
