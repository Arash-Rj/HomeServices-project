using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices.AppService
{
    public interface IHomeServiceAppService
    {
        public Result Add(HomeServiceDto homeServiceDto);
        public Result Update(HomeServiceDto homeServiceDto);
        public List<HomeServiceDto> HomeServices();
        public List<Category> Categories();
        public List<SubCategory> SubCategories();
    }
}
