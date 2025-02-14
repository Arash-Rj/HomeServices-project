using Microsoft.AspNetCore.Identity;
using Src.Domain.Core.AAM.ManageUser.Entities;
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
        Task<int> GetCount();
        Task<List<UserDto>> GetAllUsers();
        Task<Result> Register(UserDto model, CancellationToken cancellationToken);
        Task<UserDto> GetUserById(int id);
        Task<bool> Update(UserDto model, CancellationToken cancellationToken);
        Task<Result> Login(string username, string password, bool rememberMe,CancellationToken cancellationToken);
    }
}
