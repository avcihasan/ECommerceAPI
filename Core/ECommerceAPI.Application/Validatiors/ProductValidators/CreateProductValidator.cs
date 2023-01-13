using ECommerceAPI.Application.Features.Commands.ProductCommands.CreateProduct;
using ECommerceAPI.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validatiors.ProductValidators
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ürün adı giriniz !")
                .MaximumLength(150)
                .MinimumLength(3)
                .WithMessage("Ürün Adını 3 ile 150 karakter arası giriniz");

            RuleFor(p=>p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ürün fiyatı giriniz !")
                .Must(price=>price>=0)
                .WithMessage("Ürün fiyatı negatif olamaz !");

            RuleFor(p => p.Quantity)
               .NotEmpty()
               .NotNull()
               .WithMessage("Ürün adeti giriniz !")
               .Must(price => price >= 0)
               .WithMessage("Ürün adeti negatif olamaz !");

 
              

        }
    }
}
