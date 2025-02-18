using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.AppService;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.AppService.Expert_Manager.Expert
{
    public class ExpertAppService : IExpertAppService
    {
        private readonly IExpertService _expertService;
        public ExpertAppService(IExpertService expertService)
        {
            _expertService = expertService;
        }
        public async Task<List<ExpertDto>?> GetAllInfo(CancellationToken cancellationToken)
        {
            var expertDto = new List<ExpertDto>();
            try
            {
                expertDto = await _expertService.GetAllInfo(cancellationToken);
                if (expertDto is null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return expertDto;
        }

        public async Task<ExpertDto?> GetInfo(int id, CancellationToken cancellationToken)
        {
            var expertDto = new ExpertDto();
            try
            {
                expertDto = await _expertService.GetInfo(id, cancellationToken);
                if (expertDto is null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return expertDto;
        }

        public async Task<Result> Update(ExpertDto objct, CancellationToken cancellationToken)
        {
            return await _expertService.Update(objct, cancellationToken);
        }
    }
}
