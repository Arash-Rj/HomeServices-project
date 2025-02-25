using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Repository;
using Src.Infra.DataBase.SqlServer.Ef.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Ifra.DataAccess.Repos.Ef.Customer_Manager.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Result> Create(UserDto objct, CancellationToken cancellationToken)
        {
            var passwordHasher = new PasswordHasher<User>();
            var customer = new AppCustomer()
                           {
                              UserName = objct.UserName,
                              Email = objct.Email,
                           };
            customer.PasswordHash= passwordHasher.HashPassword(customer, objct.Password);
            try
            {
                await _appDbContext.Users.AddAsync(customer, cancellationToken);
                var res = await _appDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return new Result(false,ex.Message);
            }
            return new Result(true,"ثبت نام با موفقیت انجام شد.");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _appDbContext.AppCustomers.SingleOrDefault(x => x.Id == id);
                if (customer == null)
                    return new Result(false, "مشتری با این ایدی پیدا نشد!");
                customer.IsActive = false;
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "حذف با موفقیت انجام شد.");
        }

        public async Task<CustomerDto?> GetInfo(int id, CancellationToken cancellationToken)
        {
            var customerdto = new CustomerDto();
            try
            {
               var customer = await _appDbContext.AppCustomers
                    .Select(e => new { e.Id, e.UserName, e.PhoneNumber, e.Email, e.Requests.Count, e.Province })
                    .FirstAsync(u => u.Id.Equals(id),cancellationToken);
                customerdto.Id = customer.Id;
                customerdto.Email = customer.Email;
                customerdto.Phone = customer.PhoneNumber;
                customerdto.Name = customer.UserName;
                customerdto.Province = customer.Province;
            }
            catch(NullReferenceException ex)
            {
                return customerdto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerdto;
        }

        public async Task<List<CustomerDto>?> GetAllInfo(CancellationToken cancellationToken)
        {
            var customerdtos = new List<CustomerDto>();
            try
            {
               var customers = await _appDbContext.AppCustomers.Where(c => c.IsActive == true)
                    .Select(e => new { e.Id, e.UserName, e.PhoneNumber, e.Email, e.Requests.Count, e.Province, e.ImagePath })
                    .ToListAsync(cancellationToken);
                foreach (var customer in customers)
                {
                  var customerdto =  new CustomerDto
                    {
                        Id = customer.Id,
                        Name = customer.UserName,
                        Phone = customer.PhoneNumber,
                        Email = customer.Email,
                        RequestCount = customer.Count,
                        Province = customer.Province,
                        ImagePath = customer.ImagePath
                    };
                    customerdtos.Add(customerdto);
                }
            }
            catch(NullReferenceException ex)
            {
                return customerdtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerdtos;
        }

        public async Task<Result> Update(UpdateCustomerDto objct, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _appDbContext.AppCustomers.FirstOrDefaultAsync(c => c.Id == objct.Id);
                if (customer == null)
                    return new Result(false, "مشتری با این ایدی پیدا نشد!");
                customer.UserName = objct.Name;
                customer.Email = objct.Email;
                customer.PhoneNumber = objct.Phone;
                customer.Province = objct.Province;
                customer.Address = objct.Address;
                customer.CardNumber = objct.CardNumber;
                customer.IsActive = objct.IsActive;
                var res =await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch(Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "تغییر مشتری با موفقیت انجام شد.");
        }

        public async Task<UpdateCustomerDto?> GetDetailedInfo(int id, CancellationToken cancellationToken)
        {
            var updateCustomerdto = new UpdateCustomerDto();
            try
            {
                var customer = await _appDbContext.AppCustomers
                     .Select(e => new { e.Id, e.UserName, e.PhoneNumber, e.Email, e.IsActive , e.Address, e.Province , e.CardNumber, e.ImagePath })
                     .FirstOrDefaultAsync(u => u.Id.Equals(id), cancellationToken);
                updateCustomerdto.Id = customer.Id;
                updateCustomerdto.Email = customer.Email;
                updateCustomerdto.Phone = customer.PhoneNumber;
                updateCustomerdto.Name = customer.UserName;
                updateCustomerdto.Province = customer.Province;
                updateCustomerdto.Address = customer.Address;
                updateCustomerdto.IsActive = customer.IsActive;
                updateCustomerdto.CardNumber = customer.CardNumber;
                updateCustomerdto.ImagePath = customer.ImagePath;
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return updateCustomerdto;
        }
    }
}
