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
    public interface IProposalRepository
    {
        public Task<Result> Create(CreateProposalDto objct, CancellationToken cancellationToken);
        public Task<Result> Delete(int id, CancellationToken cancellationToken);
        public Task<ProposalInfoDto>? GetInfo(int id, CancellationToken cancellationToken);
        public Task<List<ProposalInfoDto>>? GetAllInfo(CancellationToken cancellationToken, int id = 0);
        public Task<Result> Update(ProposalInfoDto objct, CancellationToken cancellationToken);
    }
}
