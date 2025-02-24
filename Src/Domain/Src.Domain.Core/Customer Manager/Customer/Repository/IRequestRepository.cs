using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Src.Domain.Core.Customer_Manager.Customer.Repository
{
    public interface IRequestRepository
    {
        public Task<Result> Create(CreateRequestDto objct, CancellationToken cancellationToken);
        public Task<Result> Delete(int id, CancellationToken cancellationToken);
        public Task<AppRequest>? GetInfo(int id, CancellationToken cancellationToken);
        public Task<List<RequestInfoDto>>? GetAllInfo(CancellationToken cancellationToken);
        public Task<Result> Update(RequestInfoDto objct, CancellationToken cancellationToken);
        public Task<Result> ChangeStatus(int id,ReqStatus reqStatus, CancellationToken cancellationToken);
    }
}
