using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Customer_Manager.Customer.Repository
{
    public interface ICustomerRepository
    {
        public Task<Result> Create(AppCustomer objct, CancellationToken cancellationToken);
        public Task<Result> Delete(AppCustomer objct, CancellationToken cancellationToken);
        public Task<AppCustomer> Get(int id, CancellationToken cancellationToken);
        public Task<List<AppCustomer>> GetAll(CancellationToken cancellationToken);
        public Task<Result> Update(AppCustomer objct, CancellationToken cancellationToken);
    }
}
