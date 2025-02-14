using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using Src.Domain.Core.Payment_Manager.Payment.Entities;
using Src.Domain.Core.Payment_Manager.Payment.Repository;
using Src.Infra.DataBase.SqlServer.Ef.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Ifra.DataAccess.Repos.Ef.Payment_Manager.Payment
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _appDbContext;
        public PaymentRepository(AppDbContext appDbContext)
        { 
            _appDbContext = appDbContext;
        }
        public async Task<Result> Create(AppPayment objct, CancellationToken cancellationToken)
        {
            try
            {
                await _appDbContext.Payments.AddAsync(objct, cancellationToken);
                var res = _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "پرداخت  با موفقیت انجام شد.");
        }

        public async Task<Result> Delete(AppPayment objct, CancellationToken cancellationToken)
        {
            try
            {
                _appDbContext.Payments.Remove(objct);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "حذف پرداخت با موفقیت انجام شد.");
        }

        public async Task<AppPayment> Get(int id, CancellationToken cancellationToken)
        {
            var payment = new AppPayment();
            try
            {
                payment = await _appDbContext.Payments.FirstAsync(u => u.Id.Equals(id), cancellationToken);
            }
            catch (Exception ex)
            {
                return payment;
            }
            return payment;
        }

        public async Task<List<AppPayment>>GetAll(CancellationToken cancellationToken)
        {
            var payments = new List<AppPayment>();
            try
            {
                payments = await _appDbContext.Payments.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return payments;
            }
            return payments;
        }

        public async Task<Result> Update(AppPayment objct, CancellationToken cancellationToken)
        {
            try
            {
                _appDbContext.Payments.Update(objct);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "تغییر پرداخت با موفقیت انجام شد.");
        }
    }
}
