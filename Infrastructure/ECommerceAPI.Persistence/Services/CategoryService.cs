using AutoMapper;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.CategoryDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        readonly IRepositoryManager _repositoryManager;
        readonly IMapper _mapper;

        public CategoryService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<bool> CreateCategoryAsync(CreateCategoryDto category)
        {
            bool result = await _repositoryManager.CategoryWriteRepository.AddAsync(_mapper.Map<Category>(category));
            if (result)
                await _repositoryManager.SaveAsync();
            return result;
        }

        public async Task<List<GetCategoryDto>> GetAllCategoriesAsync()
            => _mapper.Map<List<GetCategoryDto>>(await _repositoryManager.CategoryReadRepository.GetAll().ToListAsync());

        public async Task<bool> RemoveCategoryByIdAsync(string id)
        {
            bool result = await _repositoryManager.CategoryWriteRepository.RemoveByIdAsync(id);
            if (result)
                await _repositoryManager.SaveAsync();
            return result;
        }

        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDto category)
        {
            bool result =  _repositoryManager.CategoryWriteRepository.Update(_mapper.Map<Category>(category));
            if (result)
                await _repositoryManager.SaveAsync();
            return result;
        }
    }
}
