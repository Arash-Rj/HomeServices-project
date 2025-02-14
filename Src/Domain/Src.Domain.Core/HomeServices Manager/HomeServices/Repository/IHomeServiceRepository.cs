using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices.Repository
{
    public interface IHomeServiceRepository
    {
        public Task<Result> Create(HomeService homeService,CancellationToken cancellationToken);
        public Task<Result>Update(HomeService homeService,CancellationToken cancellationToken);
        public Task<List<HomeService>> GetAllHomeService(CancellationToken cancellationToken);
        public Task<List<Category>> GetAllCategories(CancellationToken cancellationToken);
        public Task<List<SubCategory>> GetAllSubCategories(CancellationToken cancellationToken);
    }
}
