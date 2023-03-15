using ECommerceAPI.Application.UnitOfWorks;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.RemoveByIdProduct
{
    public class RemoveByIdProductCommandHandler : IRequestHandler<RemoveByIdProductCommandRequest, RemoveByIdProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveByIdProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveByIdProductCommandResponse> Handle(RemoveByIdProductCommandRequest request, CancellationToken cancellationToken)
        {
         
            await _unitOfWork.ProductWriteRepository.RemoveByIdAsync(request.Id);
           
            await _unitOfWork.SaveAsync();
            return new();
        }
    }
}
