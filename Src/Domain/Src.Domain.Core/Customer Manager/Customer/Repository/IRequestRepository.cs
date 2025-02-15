using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
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
        public Task<Result> Create(CreateRequestDto objct, CancellationToken cancellationToken);
        public Task<Result> Delete(int id, CancellationToken cancellationToken);
        public Task<RequestInfoDto>? Get(int id, CancellationToken cancellationToken);
        public Task<List<RequestInfoDto>>? GetAll(CancellationToken cancellationToken);
        public Task<Result> Update(RequestInfoDto objct, CancellationToken cancellationToken);
    }
}
