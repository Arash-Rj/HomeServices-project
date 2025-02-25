using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Dtos;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices.Repository
{
    public interface ICategoryRepository
    {
        public Task<Result> Create(CancellationToken cancellationToken, string Title, string? Image = null);
        public Task<Result> Delete(int id, CancellationToken cancellationToken);
        public Task<List<Category>> GetAll(CancellationToken cancellationToken);
        public Task<Category> Get(int id, CancellationToken cancellationToken);
        public Task<List<SubcategoryDto>?> GetSubs(int id, CancellationToken cancellationToken);
        public Task<Result> Update(CancellationToken cancellationToken,string Title, string? Image = null);
    }
}
