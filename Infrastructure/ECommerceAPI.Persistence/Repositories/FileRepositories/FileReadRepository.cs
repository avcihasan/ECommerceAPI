using ECommerceAPI.Application.Repositories.FileRepositories;
using ECommerceAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories.FileRepositories
{
    public class FileReadRepository : ReadRepository<ECommerceAPI.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
