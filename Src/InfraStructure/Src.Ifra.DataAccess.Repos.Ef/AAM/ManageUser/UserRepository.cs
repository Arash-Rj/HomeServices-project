using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.AAM.ManageUser.Enums;
using Src.Domain.Core.AAM.ManageUser.Repository;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Infra.DataBase.SqlServer.Ef.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Src.Ifra.DataAccess.Repos.Ef.AAM.ManageUser
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<User?> GetById(int id, CancellationToken cancellationToken)
        {
            var user = new User();
            try
            {
                 user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public async Task<RoleEnum?> GetRole(int id, CancellationToken cancellationToken)
        {
            try
            {
                var identityRole = await _appDbContext.UserRoles.FirstOrDefaultAsync(r => r.UserId==id);
                var role = await _appDbContext.Roles.FirstOrDefaultAsync( r => r.Id==  identityRole.RoleId);
                if(role.Name == RoleEnum.Customer.ToString())
                {
                    return RoleEnum.Customer;
                }
                if(role.Name == RoleEnum.Expert.ToString())
                {
                    return RoleEnum.Expert;
                }
                else
                {
                    return null;
                }
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
