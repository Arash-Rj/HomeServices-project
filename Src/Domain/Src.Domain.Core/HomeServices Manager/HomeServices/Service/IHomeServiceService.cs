using Src.Domain.Core.Base.Entities;
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
        public Result Add(HomeService homeServiceD);
        public Result Update(HomeService homeService);
        public Result Validation(HomeService homeService);
        public List<HomeServiceDto> HomeServices();
        public List<Category> Categories();
        public List<SubCategory> SubCategories();
    }
}
