using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Repository;
using Src.Domain.Core.Expert_Manager.Expert.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Src.Infra.DataBase.SqlServer.Ef.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Src.Ifra.DataAccess.Repos.Ef.Expert_Manager.Proposal
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProposalRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Result> Create(Domain.Core.Expert_Manager.Expert.Entities.Proposal objct, CancellationToken cancellationToken)
        {
            try
            {
                await _appDbContext.Proposals.AddAsync(objct, cancellationToken);
                var res = _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "ثبت پیشنهاد با موفقیت انجام شد.");
        }

        public async Task<Result> Delete(Domain.Core.Expert_Manager.Expert.Entities.Proposal objct, CancellationToken cancellationToken)
        {
            try
            {
                _appDbContext.Proposals.Remove(objct);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "حذف پیشنهاد با موفقیت انجام شد.");
        }

        public async Task<Domain.Core.Expert_Manager.Expert.Entities.Proposal> Get(int id, CancellationToken cancellationToken)
        {
            var proposal = new Domain.Core.Expert_Manager.Expert.Entities.Proposal();
            try
            {
                proposal = await _appDbContext.Proposals.FirstAsync(u => u.Id.Equals(id), cancellationToken);
            }
            catch (Exception ex)
            {
                return proposal;
            }
            return proposal;
        }

        public async Task<List<Domain.Core.Expert_Manager.Expert.Entities.Proposal>> GetAll(CancellationToken cancellationToken)
        {
            var proposals = new List<Domain.Core.Expert_Manager.Expert.Entities.Proposal>();
            try
            {
                proposals = await _appDbContext.Proposals.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return proposals;
            }
            return proposals;
        }

        public async Task<Result> Update(Domain.Core.Expert_Manager.Expert.Entities.Proposal objct, CancellationToken cancellationToken)
        {
            try
            {
                _appDbContext.Proposals.Update(objct);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "تغییر پیشنهاد با موفقیت انجام شد.");
        }
    }
}
