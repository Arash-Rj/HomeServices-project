using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Expert_Manager.Expert.AppService;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.Repository;
using Src.Domain.Core.Expert_Manager.Expert.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.AppService.Expert_Manager.Proposal
{
    public class ProposalAppService : IProposalAppService
    {
        private readonly IProposalService _proposalService;
        public ProposalAppService(IProposalService proposalService)
        {
            _proposalService = proposalService;
        }
        public async Task<Result> Add(CreateProposalDto objct, CancellationToken cancellationToken)
        {
            return await _proposalService.Add(objct, cancellationToken);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            return await _proposalService.Delete(id, cancellationToken);
        }

        public async Task<List<ProposalInfoDto>?> GetAllInfo(CancellationToken cancellationToken)
        {
            var proposalInfoDtos = new List<ProposalInfoDto>();
            try
            {
                proposalInfoDtos = await _proposalService.GetAllInfo(cancellationToken);
                if (proposalInfoDtos is null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return proposalInfoDtos;
        }

        public async Task<ProposalInfoDto?> GetInfo(int id, CancellationToken cancellationToken)
        {
            var proposalInfoDto = new ProposalInfoDto();
            try
            {
                proposalInfoDto = await _proposalService.GetInfo(id, cancellationToken);
                if (proposalInfoDto is null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return proposalInfoDto;
        }

        public async Task<Result> Update(ProposalInfoDto objct, CancellationToken cancellationToken)
        {
            return await _proposalService.Update(objct, cancellationToken);
        }

    }
}
