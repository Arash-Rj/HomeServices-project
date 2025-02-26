using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Expert_Manager.Expert.Service
{
    public interface IFeedBackService
    {
        public Task<List<FeedBackDto>?> GetAllInfo(CancellationToken cancellationToken, int expertId = 0);
        public Task<Result> ChangeStatus(int id, FeedBackStatus feedBackStatus, CancellationToken cancellationToken);
    }
}
