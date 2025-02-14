using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Expert_Manager.Expert.Repository
{
    public interface IExpertRepository
    {
        public Task<Result> Create(AppExpert objct, CancellationToken cancellationToken);
        public Task<Result> Delete(AppExpert objct, CancellationToken cancellationToken);
        public Task<AppExpert> Get(int id, CancellationToken cancellationToken);
        public Task<List<AppExpert>>GetAll(CancellationToken cancellationToken);
        public Task<Result> Update(AppExpert objct, CancellationToken cancellationToken);
    }
}
