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
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using System.Globalization;
using Framework;
using Src.Domain.Core.Expert_Manager.Expert.Enums;
using Azure.Core;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Microsoft.VisualBasic;

namespace Src.Ifra.DataAccess.Repos.Ef.Expert_Manager.Proposal
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProposalRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Result> Create(CreateProposalDto objct, CancellationToken cancellationToken)
        {
            var proposal = new Domain.Core.Expert_Manager.Expert.Entities.Proposal()
            {
                ExpertId = objct.ExpertId,
                RequestId = objct.RequestId,
                Description = objct.Description,
                Price = objct.Price,
                DueDate = objct.DueDate,
                DueTime = objct.DueTime,
                ProposalDate = DateTime.Now,
                Status = ProposalStatus.Pending
            };
            try
            {
                await _appDbContext.Proposals.AddAsync(proposal, cancellationToken);
                var res = await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "ثبت پیشنهاد با موفقیت انجام شد.");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var proposal = _appDbContext.Proposals.FirstOrDefault(x => x.Id == id);
                if (proposal == null)
                    return new Result(false, "پیشنهادی با این ایدی پیدا نشد!");
                _appDbContext.Proposals.Remove(proposal);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "حذف پیشنهاد با موفقیت انجام شد.");
        }

        public async Task<ProposalInfoDto>? GetInfo(int id, CancellationToken cancellationToken)
        {
            var proposalinfo = new ProposalInfoDto();
            try
            {
                var proposal = await _appDbContext.Proposals.Select(p => 
                new {
                    p.Id , p.Request.HomeService.Title , p.Description ,
                    p.Price , p.DueDate , p.Expert.UserName , p.ProposalDate , p.Status
                })
                    .FirstAsync(u => u.Id.Equals(id), cancellationToken);

                #region Mapping 
                proposalinfo.Id = proposal.Id;
                proposalinfo.ExpertName = proposal.UserName;
                proposalinfo.Price = proposal.Price;
                proposalinfo.Description = proposal.Description;
                proposalinfo.DueDate = proposal.DueDate;
                proposalinfo.DueTime = proposalinfo.DueTime;
                proposalinfo.ProposalDate = proposal.ProposalDate;
                proposalinfo.HomeServiceName = proposalinfo.HomeServiceName;
                proposalinfo.Status = proposalinfo.Status;
                #endregion

            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return proposalinfo;
        }

        public async Task<List<ProposalInfoDto>>? GetAllInfo(CancellationToken cancellationToken)
        {
            var proposaldtos = new List<ProposalInfoDto>();
            try
            {
                var proposals = await _appDbContext.Proposals.Select(p =>
                               new
                               {
                                   p.Id,
                                   p.Request.HomeService.Title,
                                   p.Description,
                                   p.Price,
                                   p.DueDate,
                                   p.DueTime,
                                   p.Expert.UserName,
                                   p.ProposalDate,
                                   p.Status
                               })
                     .ToListAsync(cancellationToken);
                foreach (var proposal in proposals)
                {
                    proposaldtos.Add(
                               new ProposalInfoDto
                               {
                                   Id = proposal.Id,
                                   Description = proposal.Description,
                                   DueDate = proposal.DueDate,
                                   DueTime = proposal.DueTime,
                                   ProposalDate = proposal.ProposalDate,
                                   ExpertName = proposal.UserName,
                                   Price = proposal.Price,
                                   HomeServiceName = proposal.Title,
                                   Status = proposal.Status,
                               });
                }
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            return proposaldtos;
        }

        public async Task<Result> Update(ProposalInfoDto objct, CancellationToken cancellationToken)
        {
            try
            {
                var proposal = _appDbContext.Proposals.FirstOrDefault(r => r.Id.Equals(objct.Id));
                if (proposal == null)
                    return new Result(false, "پیشنهادی با این ایدی پیدا نشد!");

                #region mapping
                proposal.Status = objct.Status;
                proposal.DueDate = objct.DueDate;
                proposal.ProposalDate = objct.ProposalDate;
                proposal.Description = objct.Description;
                proposal.Price = objct.Price;
                #endregion

                _appDbContext.Proposals.Update(proposal);
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
