using Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Enums;
using Src.Domain.Core.Customer_Manager.Customer.Repository;
using Src.Infra.DataBase.SqlServer.Ef.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Ifra.DataAccess.Repos.Ef.Customer_Manager.Request
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _appDbContext;
        public RequestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Result> Create(CreateRequestDto objct, CancellationToken cancellationToken)
        {
           var request = 
                new AppRequest()
                {
                Details = objct.Details,
                ExecutionDate = objct.ExecutionDate,
                ExecutionTime = objct.ExecutionTime,
                CustomerId = objct.CustomerId,
                HomeServiceId = objct.HomeServiceId,
                Images = objct.Images,
                IsActive = true,
                RequestDate =PersianDateExtensionMethods.ToPersianString(DateTime.UtcNow),
                Status = ReqStatus.Pending
                };
            try
            {
                await _appDbContext.Requests.AddAsync(request, cancellationToken);
                var res = _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "ثبت سفارش با موفقیت انجام شد.");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var request = _appDbContext.Requests.FirstOrDefault(x => x.Id == id);
                if (request == null)
                    return new Result(false, "درخواستی با این ایدی پیدا نشد!");
                _appDbContext.Requests.Remove(request);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "حذف سفارش با موفقیت انجام شد.");
        }

        public async Task<RequestInfoDto>? Get(int id, CancellationToken cancellationToken)
        {
            var appRequest = new AppRequest();
            var requestdto = new RequestInfoDto();
            try
            {
                appRequest = await _appDbContext.Requests.FirstAsync(r => r.Id.Equals(id),cancellationToken);

                #region Mapping
                requestdto.Id = appRequest.Id;
                requestdto.ExecutionDate = appRequest.ExecutionDate;
                requestdto.ExecutionTime = appRequest.ExecutionTime;
                requestdto.Status = appRequest.Status;
                requestdto.Details = appRequest.Details;
                requestdto.Images = appRequest.Images;
                #endregion

            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return requestdto;
        }

        public async Task<List<RequestInfoDto>>? GetAll(CancellationToken cancellationToken)
        {
            var appRequests = new List<AppRequest>();
            var requestdtos = new List<RequestInfoDto>();
            try
            {
                appRequests = await _appDbContext.Requests.ToListAsync(cancellationToken);
                foreach (var request in appRequests)
                {
                   requestdtos.Add(
                     new RequestInfoDto
                     {
                        Id = request.Id,
                        Details = request.Details,
                        ExecutionDate = request.ExecutionDate,
                        ExecutionTime = request.ExecutionTime,
                        IsActive = request.IsActive,
                        Status = request.Status,
                        Images = request.Images,
                     });
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
            return requestdtos;
        }

        public async Task<Result> Update(RequestInfoDto objct, CancellationToken cancellationToken)
        {
            
            try
            {
                var request = _appDbContext.Requests.FirstOrDefault(r => r.Id.Equals(objct.Id));
                if (request == null)
                    return new Result(false, "درخواستی با این ایدی پیدا نشد!");

                #region mapping
                request.Status = objct.Status;
                request.ExecutionDate = objct.ExecutionDate;
                request.ExecutionTime = objct.ExecutionTime;
                request.Details = objct.Details;
                request.IsActive = objct.IsActive;
                request.Images = objct.Images;
                #endregion

                _appDbContext.Requests.Update(request);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "تغییر سفارش با موفقیت انجام شد.");
        }
    }
}
