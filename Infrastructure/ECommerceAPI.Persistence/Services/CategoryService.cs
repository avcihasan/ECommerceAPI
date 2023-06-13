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
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateCategoryAsync(CreateCategoryDto category)
        {
            bool result = await _unitOfWork.CategoryWriteRepository.AddAsync(_mapper.Map<Category>(category));
            if (result)
                await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<List<GetCategoryDto>> GetAllCategoriesAsync()
            => _mapper.Map<List<GetCategoryDto>>(await _unitOfWork.CategoryReadRepository.GetAll().ToListAsync());

        public async Task<bool> RemoveCategoryByIdAsync(string id)
        {
            bool result = await _unitOfWork.CategoryWriteRepository.RemoveByIdAsync(id);
            if (result)
                await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDto category)
        {
            bool result =  _unitOfWork.CategoryWriteRepository.Update(_mapper.Map<Category>(category));
            if (result)
                await _unitOfWork.SaveAsync();
            return result;
        }
    }
}
