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
                RequestDate = DateTime.Now,
                Status = ReqStatus.Pending
                };
            try
            {
                await _appDbContext.Requests.AddAsync(request, cancellationToken);
                var res = await _appDbContext.SaveChangesAsync();
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

        public async Task<AppRequest>? GetInfo(int id, CancellationToken cancellationToken)
        {
            var appRequest = new AppRequest();
            try
            {
                appRequest = await _appDbContext.Requests.Include(r => r.Customer)
                    .Include(r => r.HomeService)
                    .FirstAsync(r => r.Id.Equals(id),cancellationToken);
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return appRequest;
        }

        public async Task<List<RequestInfoDto>>? GetAllInfo(CancellationToken cancellationToken)
        {
            var requestdtos = new List<RequestInfoDto>();
            try
            {
                var requests = await _appDbContext.Requests
                    .Select(r => 
                    new {
                        r.Id , r.RequestDate , r.ExecutionDate , 
                        r.Status , r.IsActive , r.Details, 
                        r.Customer.UserName, r.Images , r.ExecutionTime ,
                        r.HomeService.Title
                    })
                    .ToListAsync(cancellationToken);

                foreach (var request in requests)
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
                        CustomerName = request.UserName,
                        HomeServiceName = request.Title,
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
                var request = await _appDbContext.Requests.FirstOrDefaultAsync(r => r.Id.Equals(objct.Id));
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

        public async Task<Result> ChangeStatus(int id, ReqStatus reqStatus, CancellationToken cancellationToken)
        {
            try
            {
                var request = await _appDbContext.Requests.FirstOrDefaultAsync(r => r.Id.Equals(id));
                if (request == null)
                    return new Result(false, "درخواستی با این ایدی پیدا نشد!");
                request.Status=reqStatus;
                if(reqStatus==ReqStatus.Success)
                {
                    request.IsActive=false;
                }
                else
                {
                    request.IsActive = true;
                }
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
