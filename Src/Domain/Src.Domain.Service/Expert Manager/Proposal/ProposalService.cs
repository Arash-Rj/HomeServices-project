using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.Repository;
using Src.Domain.Core.Expert_Manager.Expert.Service;
using Src.Domain.Core.HomeServices_Manager.HomeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Service.Expert_Manager.Proposal
{
    public class ProposalService : IProposalService
    {
        private readonly IProposalRepository _proposalRepository;
        public ProposalService(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }
        public async Task<Result> Add(CreateProposalDto objct, CancellationToken cancellationToken)
        {
            return await _proposalRepository.Create(objct, cancellationToken);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            return await _proposalRepository.Delete(id, cancellationToken);
        }

        public async Task<List<ProposalInfoDto>?> GetAllInfo(CancellationToken cancellationToken)
        {
            var proposalInfoDtos = new List<ProposalInfoDto>();
            try
            {
                proposalInfoDtos = await _proposalRepository.GetAllInfo(cancellationToken);
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
                proposalInfoDto = await _proposalRepository.GetInfo(id, cancellationToken);
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
            return await _proposalRepository.Update(objct, cancellationToken);
        }

        public Task<Result> Validation(CreateProposalDto objct, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
