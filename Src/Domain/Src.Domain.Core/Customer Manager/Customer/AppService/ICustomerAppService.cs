using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Src.Domain.Core.Customer_Manager.Customer.AppService
{
    public interface ICustomerAppService
    {
        public Task<CustomerDto> GetInfo(int id, CancellationToken cancellationToken);
        public Task<List<CustomerDto>> GetAllInfo(CancellationToken cancellationToken);
        public Task<Result> Update(CustomerDto objct, CancellationToken cancellationToken);
    }
}
