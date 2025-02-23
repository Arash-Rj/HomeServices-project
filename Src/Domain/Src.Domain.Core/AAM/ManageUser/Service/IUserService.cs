using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.AAM.ManageUser.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.AAM.ManageUser.Service
{
    public interface IUserService
    {
        public Task<User?> GetById(int id,CancellationToken cancellationToken);
        public Task<RoleEnum?> GetRole(int id, CancellationToken cancellationToken);
    }
}
