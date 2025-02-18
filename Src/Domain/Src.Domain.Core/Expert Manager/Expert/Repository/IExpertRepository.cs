using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
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
        public Task<Result> Delete(int id, CancellationToken cancellationToken);
        public Task<ExpertDto?> GetInfo(int id, CancellationToken cancellationToken);
        public Task<List<ExpertDto>?>GetAllInfo(CancellationToken cancellationToken);
        public Task<Result> Update(ExpertDto objct, CancellationToken cancellationToken);
    }
}
