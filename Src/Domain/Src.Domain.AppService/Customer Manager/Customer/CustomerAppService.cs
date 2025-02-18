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
        public async Task<List<CustomerDto>?> GetAllInfo(CancellationToken cancellationToken)
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

        public async Task<CustomerDto?> GetInfo(int id, CancellationToken cancellationToken)
        {
            var customerDto = new CustomerDto();
            try
            {
                customerDto = await _customerService.GetInfo(id, cancellationToken);
                if (customerDto is null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerDto;
        }

        public async Task<Result> Update(CustomerDto objct, CancellationToken cancellationToken)
        {
            
            return await _customerService.Update(objct, cancellationToken);
        }
    }
}
