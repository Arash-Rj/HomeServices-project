using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.AppService;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Enums;
using Src.Domain.Core.Customer_Manager.Customer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.AppService.Customer_Manager.Request
{
    public class RequestAppService : IRequestAppService
    {
        private readonly IRequestService _requestService;
        public RequestAppService(IRequestService requestService)
        {
            _requestService = requestService;
        }
        public async Task<Result> Add(CreateRequestDto objct, CancellationToken cancellationToken)
        {
           return await _requestService.Add(objct, cancellationToken);
        }

        public async Task<Result> ChangeStatus(int id, ReqStatus reqStatus, CancellationToken cancellationToken)
        {
            try
            {
                return await _requestService.ChangeStatus(id, reqStatus, cancellationToken);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            return await _requestService.Delete(id, cancellationToken);
        }

        public async Task<List<RequestInfoDto>?> GetAllInfo(CancellationToken cancellationToken)
        {
            var requestInfoDtos = new List<RequestInfoDto>();
            try
            {
                requestInfoDtos = await _requestService.GetAllInfo(cancellationToken);
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
                requestInfo = await _requestService.GetInfo(id, cancellationToken);
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
            return await _requestService.Update(objct, cancellationToken);
        }
    }
}
