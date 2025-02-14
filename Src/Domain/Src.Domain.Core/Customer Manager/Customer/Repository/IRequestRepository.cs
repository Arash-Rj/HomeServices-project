using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Customer_Manager.Customer.Repository
{
    public interface IRequestRepository
    {
        public Task<Result> Create(AppRequest objct, CancellationToken cancellationToken);
        public Task<Result> Delete(AppRequest objct, CancellationToken cancellationToken);
        public Task<AppRequest> Get(int id, CancellationToken cancellationToken);
        public Task<List<AppRequest>> GetAll(CancellationToken cancellationToken);
        public Task<Result> Update(AppRequest objct, CancellationToken cancellationToken);
    }
}
