using ECommerceAPI.Application.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProdcutImageFileCommands.ChangeShowcaseProductImage
{
    public class ChangeShowcaseProductImageHandler : IRequestHandler<ChangeShowcaseProductImageRequest, ChangeShowcaseProductImageResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public ChangeShowcaseProductImageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task<ChangeShowcaseProductImageResponse> Handle(ChangeShowcaseProductImageRequest request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.ProductImageFileReadRepository.GetAll()
                .Include(x => x.Products)
                .SelectMany(p => p.Products, (pif, p) => new
                {
                    pif,
                    p
                });
            var data = await query.FirstOrDefaultAsync(x => x.p.Id == Guid.Parse(request.ProductId) && x.pif.ShowCase == true);
            if (data!=null)
                data.pif.ShowCase = false;

            var image = await query.FirstOrDefaultAsync(x => x.pif.Id == Guid.Parse(request.ImageId));
            if(image!=null)
                image.pif.ShowCase = true;

            await _unitOfWork.SaveAsync();

            return new();
        }
    }
}
