using Microsoft.AspNetCore.Identity;
using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.AAM.ManageUser.Enums;
using Src.Domain.Core.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.AAM.ManageUser.AppService
{
    public interface IUserAppService
    {
        Task<int> GetCount(CancellationToken cancellationToken);
        Task<List<UserDto>> GetAllUsers(CancellationToken cancellationToken);
        Task<Result> Register(UserDto model, CancellationToken cancellationToken);
        Task<User> GetById(int id, CancellationToken cancellationToken);
        //Task<Result> Update(UserUpdateDto model, CancellationToken cancellationToken);
        Task<Result> Login(string username, string password, bool rememberMe,CancellationToken cancellationToken);
        public Task<RoleEnum?> GetRole(int id, CancellationToken cancellationToken);
    }
}
