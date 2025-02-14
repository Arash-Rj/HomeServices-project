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
                var customer = _appDbContext.Users.SingleOrDefault(x => x.Id == id);
                 _appDbContext.Users.Remove(customer);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "حذف با موفقیت انجام شد.");
        }

        public async Task<CustomerDto> GetInfo(int id, CancellationToken cancellationToken)
        {
            var customer = new AppCustomer();
            var customerdto = new CustomerDto();
            try
            {
                customer = await _appDbContext.Users.OfType<AppCustomer>().FirstAsync(u => u.Id.Equals(id),cancellationToken);

                customerdto.Id = customer.Id;
                customerdto.Email = customer.Email;
                customerdto.Phone = customer.PhoneNumber;
                customerdto.Name = customer.UserName;
            }
            catch(NullReferenceException ex)
            {
                return customerdto;
            }
            return customerdto;
        }

        public async Task<List<CustomerDto>> GetAll(CancellationToken cancellationToken)
        {
            var customers = new List<AppCustomer>();
            var customerdtos = new List<CustomerDto>();
            try
            {
                customers = await _appDbContext.Users.OfType<AppCustomer>().ToListAsync(cancellationToken);
                foreach (var customer in customers)
                {
                  var customerdto =  new CustomerDto
                    {
                        Id = customer.Id,
                        Name = customer.UserName,
                        Phone = customer.PhoneNumber,
                        Email = customer.Email
                    };
                    customerdtos.Add(customerdto);
                }
            }
            catch(NullReferenceException ex)
            {
                return customerdtos;
            }
            return customerdtos;
        }

        public async Task<Result> Update(CustomerDto objct, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _appDbContext.Users.FirstOrDefaultAsync(c => c.Id == objct.Id);
                customer.UserName = objct.Name;
                customer.Email = objct.Email;
                customer.PhoneNumber = objct.Phone;
                var res =await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch(Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "تغییر مشتری با موفقیت انجام شد.");
        }
    }
}
