using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.AppService;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.AppService.Services_Manager.Service
{
    public class HomeServiceAppService : IHomeServiceAppService
    {
        public Result Add(HomeServiceDto homeServiceDto)
        {
            throw new NotImplementedException();
        }

        public List<Core.HomeServices_Manager.HomeServices.Entities.Category> Categories()
        {
            throw new NotImplementedException();
        }

        public List<HomeServiceDto> HomeServices()
        {
            throw new NotImplementedException();
        }

        public List<SubCategory> SubCategories()
        {
            throw new NotImplementedException();
        }

        public Result Update(HomeServiceDto homeServiceDto)
        {
            throw new NotImplementedException();
        }
    }
}
