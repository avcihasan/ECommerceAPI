using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.MessageDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Services
{
    public class MessageService : IMessageService
    {
        readonly IRepositoryManager _repositoryManager;

        public MessageService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task SendMessageAsync(SendMessageDto sendMessageDto)
        {
            var result = await _repositoryManager.MessageWriteRepository.AddAsync(new() { Body = sendMessageDto.Body, Subject = sendMessageDto.Subject, UserId = sendMessageDto.ToUserId });
            if (result)
                await _repositoryManager.SaveAsync();
        }
    }
}
