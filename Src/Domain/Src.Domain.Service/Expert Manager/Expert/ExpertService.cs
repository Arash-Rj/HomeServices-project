using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.Repository;
using Src.Domain.Core.Expert_Manager.Expert.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Service.Expert_Manager.Expert
{
    public class ExpertService : IExpertService
    {
        private readonly IExpertRepository _expertRepository;
        public ExpertService(IExpertRepository expertRepository)
        {
            _expertRepository = expertRepository;
        }
        public async Task<List<ExpertDto>?> GetAllInfo(CancellationToken cancellationToken)
        {
            var expertDto = new List<ExpertDto>();
            try
            {
                expertDto = await _expertRepository.GetAllInfo(cancellationToken);
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
                expertDto = await _expertRepository.GetInfo(id, cancellationToken);
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
            return await _expertRepository.Update(objct, cancellationToken); 
        }
    }
}
