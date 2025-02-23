using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.AAM.ManageUser.Enums;
using Src.Domain.Core.AAM.ManageUser.Repository;
using Src.Domain.Core.AAM.ManageUser.Service;
using Src.Infra.DataBase.SqlServer.Ef.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Service.AAM.ManageUser
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User?> GetById(int id,CancellationToken cancellationToken)
        {
            var user = new User();
            try
            {
                user = await _userRepository.GetById(id, cancellationToken);
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
            return await _userRepository.GetRole(id, cancellationToken);
        }
    }
}
