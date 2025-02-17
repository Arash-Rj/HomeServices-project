using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Expert_Manager.Expert.AppService
{
    public interface IProposalAppService
    {
        public Task<Result> Add(CreateProposalDto objct, CancellationToken cancellationToken);
        public Task<Result> Update(ProposalInfoDto objct, CancellationToken cancellationToken);
        public Task<Result> Delete(int id, CancellationToken cancellationToken);
        public Task<ProposalInfoDto?> GetInfo(int id, CancellationToken cancellationToken);
        public Task<List<ProposalInfoDto>?> GetAllInfo(CancellationToken cancellationToken);
    }
}
