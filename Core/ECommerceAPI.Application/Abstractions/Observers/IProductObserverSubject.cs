using ECommerceAPI.Application.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Observers
{
    public interface IProductObserverSubject
    {
        void AddObserver(IProductObserver observer);
        void RemoveObserver(IProductObserver observer);
        void NotifyObserver(GetProductDto productDto, decimal oldPrice);
    }
}
