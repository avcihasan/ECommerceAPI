﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProdcutImageFileCommands.ChangeShowcaseProductImage
{
    public class ChangeShowcaseProductImageRequest:IRequest<ChangeShowcaseProductImageResponse>
    {
        public string ProductId { get; set; }
        public string ImageId { get; set; }
    }
}
