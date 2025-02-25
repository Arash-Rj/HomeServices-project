using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Dtos;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices.Service
{
    public interface IHomeServiceService
    {
        public Task<Result> Add(HomeServiceDto objct,CancellationToken cancellationToken);
        public Task<Result> Update(HomeServiceDto objct, CancellationToken cancellationToken);
        public Task<Result> Delete(int id, CancellationToken cancellationToken);
        public Task<HomeServiceDto?> GetInfo(int id, CancellationToken cancellationToken);
        public Task<Result> Validation(HomeService objct, CancellationToken cancellationToken);
        public Task<List<HomeServiceDto>?> GetAllInfo(CancellationToken cancellationToken);
        public Task<List<SubcategoryDto>?> SubCategories(CancellationToken cancellationToken);
    }
}
