using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Customer_Manager.Customer.Repository
{
    public interface ICustomerRepository
    {
        public Task<Result> Create(UserDto objct, CancellationToken cancellationToken);
        public Task<Result> Delete(int id, CancellationToken cancellationToken);
        public Task<CustomerDto?> GetInfo(int id, CancellationToken cancellationToken);
        public Task<UpdateCustomerDto?> GetDetailedInfo(int id, CancellationToken cancellationToken);
        public Task<List<CustomerDto>?> GetAllInfo(CancellationToken cancellationToken);
        public Task<Result> Update(UpdateCustomerDto objct, CancellationToken cancellationToken);
    }
}
