using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Repository;
using Src.Domain.Core.Customer_Manager.Customer.Service;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Service.Customer_Manager.Request
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public async Task<Result> Add(CreateRequestDto objct, CancellationToken cancellationToken)
        {
            return await _requestRepository.Create(objct, cancellationToken);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            return await _requestRepository.Delete(id, cancellationToken);
        }

        public async Task<List<RequestInfoDto>?> GetAllInfo(CancellationToken cancellationToken)
        {
            var requestInfoDtos = new List<RequestInfoDto>();
            try
            {
                requestInfoDtos = await _requestRepository.GetAllInfo(cancellationToken);
                if (requestInfoDtos is null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return requestInfoDtos;
        }

        public async Task<AppRequest?> GetInfo(int id, CancellationToken cancellationToken)
        {
            var requestInfo = new AppRequest();
            try
            {
                requestInfo = await _requestRepository.GetInfo(id, cancellationToken);
                if (requestInfo is null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return requestInfo;
        }

        public async Task<Result> Update(RequestInfoDto objct, CancellationToken cancellationToken)
        {
            return await _requestRepository.Update(objct, cancellationToken);
        }

        public async Task<Result> Validation(CreateRequestDto objct, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
