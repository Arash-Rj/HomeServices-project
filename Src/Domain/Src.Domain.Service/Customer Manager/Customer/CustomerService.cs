using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Customer_Manager.Customer.Repository;
using Src.Domain.Core.Customer_Manager.Customer.Service;
using Src.Ifra.DataAccess.Repos.Ef.Customer_Manager.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Service.Customer_Manager.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<List<CustomerDto>> GetAllInfo(CancellationToken cancellationToken)
        {
            var customerDtos = new List<CustomerDto>();
            try
            {
                customerDtos = await _customerRepository.GetAllInfo(cancellationToken);
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
