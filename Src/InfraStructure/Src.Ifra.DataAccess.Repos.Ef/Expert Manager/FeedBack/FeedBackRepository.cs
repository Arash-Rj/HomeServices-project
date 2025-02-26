using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.Enums;
using Src.Domain.Core.Expert_Manager.Expert.Repository;
using Src.Infra.DataBase.SqlServer.Ef.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Ifra.DataAccess.Repos.Ef.Expert_Manager.FeedBack
{
    public class FeedBackRepository : IFeedBackRepository
    {
        private readonly AppDbContext _appDbContext;
        public FeedBackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result> ChangeStatus(int id, FeedBackStatus feedBackStatus, CancellationToken cancellationToken)
        {
            try
            {
                var feedback = await _appDbContext.FeedBacks.FirstOrDefaultAsync(r => r.Id.Equals(id));
                if (feedback == null)
                    return new Result(false, "بازخوردی با این ایدی پیدا نشد!");

                #region mapping
                feedback.Status = feedBackStatus;
                #endregion

                _appDbContext.FeedBacks.Update(feedback);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "تغییر وضعیت بازخورد با موفقیت انجام شد.");
        }

        public async Task<List<FeedBackDto>?> GetAllInfo(CancellationToken cancellationToken, int expertId = 0)
        {
            var feedBackDtos = new List<FeedBackDto>();
            try
            {
                if (expertId == 0)
                {
                    var feedBacks = await _appDbContext.FeedBacks.Select(p =>
                                    new
                                    {
                                        p.Id,
                                        p.Description,
                                        p.Customer.UserName,
                                        p.Expert.NormalizedUserName,
                                        p.Status,
                                        p.Score,
                                    })
                          .ToListAsync(cancellationToken);
                    foreach (var feedback in feedBacks)
                    {
                        feedBackDtos.Add(
                                   new FeedBackDto
                                   {
                                       Id = feedback.Id,
                                       Description = feedback.Description,
                                       Score = feedback.Score,
                                       Status = feedback.Status,
                                       CustomerName = feedback.UserName,
                                       ExpertName = feedback.NormalizedUserName.ToLower(),
                                   });
                    }
                }
                else
                {
                    var feedBacks = await _appDbContext.FeedBacks.Where(p => p.ExpertId.Equals(expertId)).Select(p =>
                                   new
                                   {
                                       p.Id,
                                       p.Description,
                                       p.Customer.UserName,
                                       p.Expert.NormalizedUserName,
                                       p.Status,
                                       p.Score,
                                   })
                         .ToListAsync(cancellationToken);
                    foreach (var feedback in feedBacks)
                    {
                        feedBackDtos.Add(
                                   new FeedBackDto
                                   {
                                       Id = feedback.Id,
                                       Description = feedback.Description,
                                       Score = feedback.Score,
                                       Status = feedback.Status,
                                       CustomerName = feedback.UserName,
                                       ExpertName = feedback.NormalizedUserName.ToLower(),
                                   });
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return feedBackDtos;
        }
    }
}
