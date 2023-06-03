using ECommerceAPI.Application.Repositories.BasketRepositories;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories.BasketItemRepositories
{
    public interface IBasketItemReadRepository:IReadRepository<BasketItem>
    {
    }
}
