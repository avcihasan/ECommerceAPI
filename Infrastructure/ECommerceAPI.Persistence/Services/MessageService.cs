using AutoMapper;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.MessageDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Services
{
    public class MessageService : IMessageService
    {
        readonly IRepositoryManager _repositoryManager;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IMapper _mapper;
        public MessageService(IRepositoryManager repositoryManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<List<MessageDto>> GetAllMessagesByUserNameAsync()
        {
            List<Message> messages = await _repositoryManager.MessageReadRepository.Table.Include(x => x.User).Where(x => x.User.UserName == _httpContextAccessor.HttpContext.User.Identity.Name).ToListAsync();
              

            return _mapper.Map<List<MessageDto>>(messages);
        }

        public async Task SendMessageAsync(SendMessageDto sendMessageDto)
        {
            var result = await _repositoryManager.MessageWriteRepository.AddAsync(new() { Body = sendMessageDto.Body, Subject = sendMessageDto.Subject, UserId = sendMessageDto.ToUserId });
            if (result)
                await _repositoryManager.SaveAsync();
        }
    }
}
