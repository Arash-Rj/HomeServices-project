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
    public interface IProposalRepository
    {
        public Task<Result> Create(Proposal objct, CancellationToken cancellationToken);
        public Task<Result> Delete(Proposal objct, CancellationToken cancellationToken);
        public Task<Proposal> Get(int id, CancellationToken cancellationToken);
        public Task<List<Proposal>> GetAll(CancellationToken cancellationToken);
        public Task<Result> Update(Proposal objct, CancellationToken cancellationToken);
    }
}
