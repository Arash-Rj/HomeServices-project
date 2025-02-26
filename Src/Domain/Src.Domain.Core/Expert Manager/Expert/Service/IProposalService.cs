using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;

namespace Src.Domain.Core.Expert_Manager.Expert.Service
{
    public interface IProposalService
    {
        public Task<Result> Add(CreateProposalDto objct, CancellationToken cancellationToken);
        public Task<Result> Update(ProposalInfoDto objct, CancellationToken cancellationToken);
        public Task<Result> Delete(int id, CancellationToken cancellationToken);
        public Task<ProposalInfoDto?> GetInfo(int id, CancellationToken cancellationToken);
        public Task<Result> Validation(CreateProposalDto objct, CancellationToken cancellationToken);
        public Task<List<ProposalInfoDto>?> GetAllInfo(CancellationToken cancellationToken, int id = 0);
    }
}
