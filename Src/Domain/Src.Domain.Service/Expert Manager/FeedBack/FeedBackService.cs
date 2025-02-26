using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.Enums;
using Src.Domain.Core.Expert_Manager.Expert.Repository;
using Src.Domain.Core.Expert_Manager.Expert.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Service.Expert_Manager.FeedBack
{
    public class FeedBackService : IFeedBackService
    {
        private readonly IFeedBackRepository _feedBackRepository;
        public FeedBackService(IFeedBackRepository feedBackRepository)
        {
            _feedBackRepository = feedBackRepository;
        }

        public async Task<Result> ChangeStatus(int id, FeedBackStatus feedBackStatus, CancellationToken cancellationToken)
        {
            try
            {
                return await _feedBackRepository.ChangeStatus(id, feedBackStatus, cancellationToken);
            }
            catch(Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<List<FeedBackDto>?> GetAllInfo(CancellationToken cancellationToken, int expertId = 0)
        {
            try
            {
                return await _feedBackRepository.GetAllInfo(cancellationToken, expertId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
