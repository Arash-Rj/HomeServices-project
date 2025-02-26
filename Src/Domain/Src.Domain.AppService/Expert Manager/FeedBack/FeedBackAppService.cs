using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Expert_Manager.Expert.AppService;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.Enums;
using Src.Domain.Core.Expert_Manager.Expert.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.AppService.Expert_Manager.FeedBack
{
    public class FeedBackAppService : IFeedBackAppService
    {
        private readonly IFeedBackService _feedBackService;
        public FeedBackAppService(IFeedBackService feedBackService) 
        {
            _feedBackService = feedBackService;
        }
        public async Task<List<FeedBackDto>?> GetAllInfo(CancellationToken cancellationToken, int expertId = 0)
        {
            try
            {
                return await _feedBackService.GetAllInfo(cancellationToken, expertId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result> ChangeStatus(int id, FeedBackStatus feedBackStatus, CancellationToken cancellationToken)
        {
            try
            {
                return await _feedBackService.ChangeStatus(id, feedBackStatus, cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}
