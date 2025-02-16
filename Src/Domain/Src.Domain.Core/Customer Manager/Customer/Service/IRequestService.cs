using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Customer_Manager.Customer.Service
{
    public interface IRequestService
    {
        public Task<Result> Add(CreateRequestDto objct, CancellationToken cancellationToken);
        public Task<Result> Update(RequestInfoDto objct, CancellationToken cancellationToken);
        public Task<Result> Delete(int id, CancellationToken cancellationToken);
        public Task<AppRequest?> GetInfo(int id, CancellationToken cancellationToken);
        public Task<Result> Validation(CreateRequestDto objct, CancellationToken cancellationToken);
        public Task<List<RequestInfoDto>?> GetAllInfo(CancellationToken cancellationToken);
    }
}
