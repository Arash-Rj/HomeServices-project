using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Expert_Manager.Expert.Service
{
    public interface IExpertService
    {
        public Task<ExpertDto?> GetInfo(int id, CancellationToken cancellationToken);
        public Task<List<ExpertDto>?> GetAllInfo(CancellationToken cancellationToken);
        public Task<Result> Update(UpdateExpertDto objct, CancellationToken cancellationToken);
        public Task<UpdateExpertDto?> GetDetailedInfo(int id, CancellationToken cancellationToken);
    }
}
