using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Repository;
using Src.Infra.DataBase.SqlServer.Ef.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Ifra.DataAccess.Repos.Ef.Expert_Manager.Expert
{
    public class ExpertRepository : IExpertRepository
    {
        private readonly AppDbContext _appDbContext;
        public ExpertRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Result> Create(AppExpert objct, CancellationToken cancellationToken)
        {
            try
            {
                await _appDbContext.Users.AddAsync(objct, cancellationToken);
                var res = _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "ثبت نام با موفقیت انجام شد.");
        }

        public async Task<Result> Delete(AppExpert objct, CancellationToken cancellationToken)
        {
            try
            {
                _appDbContext.Users.Remove(objct);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "حذف با موفقیت انجام شد.");
        }

        public async Task<AppExpert> Get(int id, CancellationToken cancellationToken)
        {
            var customer = new AppExpert();
            try
            {
                customer = await _appDbContext.Users.OfType<AppExpert>().FirstAsync(u => u.Id.Equals(id), cancellationToken);
            }
            catch (Exception ex)
            {
                return customer;
            }
            return customer;
        }

        public async Task<List<AppExpert>> GetAll(CancellationToken cancellationToken)
        {
            var users = new List<AppExpert>();
            try
            {
                users = await _appDbContext.Users.OfType<AppExpert>().ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return users;
            }
            return users;
        }

        public async Task<Result> Update(AppExpert objct, CancellationToken cancellationToken)
        {
            try
            {
                _appDbContext.Users.Update(objct);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "تغییر کارشناس با موفقیت انجام شد.");
        }
    }
}
