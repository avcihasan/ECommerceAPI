using ECommerceAPI.Application.Abstractions.Observers;
using ECommerceAPI.Application.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Observers
{
    public class ProductObserverSubject : IProductObserverSubject
    {
        readonly List<IProductObserver> _productObservers;
        public ProductObserverSubject()
        {
            _productObservers = new();
        }
        public void AddObserver(IProductObserver observer)
            => _productObservers.Add(observer);

        public void RemoveObserver(IProductObserver observer)
           => _productObservers.Remove(observer);
        public void NotifyObserver(GetProductDto productDto, decimal oldPrice)
            => _productObservers.ForEach(x => x.ChangeProductPrice(productDto, oldPrice).Wait());
    }
}
