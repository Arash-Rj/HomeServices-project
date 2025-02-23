using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
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
        public async Task<List<CustomerDto>?> GetAllInfo(CancellationToken cancellationToken)
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

        public async Task<UpdateCustomerDto?> GetDetailedInfo(int id, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetDetailedInfo(id, cancellationToken);
        }

        public async Task<CustomerDto?> GetInfo(int id, CancellationToken cancellationToken)
        {
            var customerDto = new CustomerDto();
            try
            {
                customerDto = await _customerRepository.GetInfo(id, cancellationToken);
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

        public async Task<Result> Update(UpdateCustomerDto objct, CancellationToken cancellationToken)
        {
            return await _customerRepository.Update(objct, cancellationToken);
        }
    }
}
