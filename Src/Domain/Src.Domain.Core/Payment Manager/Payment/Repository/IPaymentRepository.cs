using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Payment_Manager.Payment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Payment_Manager.Payment.Repository
{
    public interface IPaymentRepository
    {
        public Task<Result> Create(AppPayment objct, CancellationToken cancellationToken);
        public Task<Result> Delete(AppPayment objct, CancellationToken cancellationToken);
        public Task<AppPayment> Get(int id, CancellationToken cancellationToken);
        public Task<List<AppPayment>> GetAll(CancellationToken cancellationToken);
        public Task<Result> Update(AppPayment objct, CancellationToken cancellationToken);
    }
}
