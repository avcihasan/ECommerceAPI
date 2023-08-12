using ECommerceAPI.Application.DTOs.MessageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Services
{
    public interface IMessageService
    {
        Task SendMessageAsync(SendMessageDto sendMessageDto);
    }
}
