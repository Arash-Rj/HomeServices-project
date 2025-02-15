using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Repository;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Service;
using Src.Ifra.DataAccess.Repos.Ef.HomeServices_Manager.HomeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Service.HomeServices_Manager.HomeService
{
    public class HomeServicesService : IHomeServiceService
    {
        private readonly IHomeServiceRepository _homeServiceRepository;
        public HomeServicesService(IHomeServiceRepository homeServiceRepository)
        {
            _homeServiceRepository = homeServiceRepository;
        }
        public Result Add(Core.HomeServices_Manager.HomeServices.Entities.HomeService homeServiceD)
        {
            throw new NotImplementedException();
        }

        public List<Category> Categories()
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

        public Result Update(Core.HomeServices_Manager.HomeServices.Entities.HomeService homeService)
        {
            throw new NotImplementedException();
        }

        public Result Validation(Core.HomeServices_Manager.HomeServices.Entities.HomeService homeService)
        {
            throw new NotImplementedException();
        }
    }
}
