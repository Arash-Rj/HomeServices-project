using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.AppService;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Customer_Manager.Customer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.AppService.Customer_Manager.Customer
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        public CustomerAppService(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<List<CustomerDto>> GetAllInfo(CancellationToken cancellationToken)
        {
            var customerDtos = new List<CustomerDto>();
            try
            {
                customerDtos = await _customerService.GetAllInfo(cancellationToken);
                if (customerDtos is null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerDtos;
        }

        public Task<CustomerDto> GetInfo(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(CustomerDto objct, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
