using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
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
        public async Task<Result> Create(AppRequest objct, CancellationToken cancellationToken)
        {
            try
            {
                await _appDbContext.Requests.AddAsync(objct, cancellationToken);
                var res = _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "ثبت سفارش با موفقیت انجام شد.");
        }

        public async Task<Result> Delete(AppRequest objct, CancellationToken cancellationToken)
        {
            try
            {
                _appDbContext.Requests.Remove(objct);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "حذف سفارش با موفقیت انجام شد.");
        }

        public async Task<AppRequest> Get(int id, CancellationToken cancellationToken)
        {
            var appRequest = new AppRequest();
            try
            {
                appRequest = await _appDbContext.Requests.FirstAsync(r => r.Id.Equals(id),cancellationToken);
            }
            catch (Exception ex)
            {
                return appRequest;
            }
            return appRequest;
        }

        public async Task <List<AppRequest>> GetAll(CancellationToken cancellationToken)
        {
            var appRequests = new List<AppRequest>();
            try
            {
                appRequests = await _appDbContext.Requests.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return appRequests;
            }
            return appRequests;
        }

        public async Task<Result> Update(AppRequest objct, CancellationToken cancellationToken)
        {
            try
            {
                _appDbContext.Requests.Update(objct);
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
