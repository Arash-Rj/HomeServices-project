using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Dtos;
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

        public async Task<Result> Add(HomeServiceDto objct, CancellationToken cancellationToken)
        {
            return await _homeServiceRepository.Create(objct, cancellationToken);
        }

        public async Task<Result> CreateSubCategory(SubcategoryDto subcategory, CancellationToken cancellationToken)
        {
            return await _homeServiceRepository.CreateSubCategory(subcategory, cancellationToken);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            return await _homeServiceRepository.Delete(id, cancellationToken);
        }

        public async Task<List<HomeServiceDto>?> GetAllInfo(CancellationToken cancellationToken,int id = 0)
        {
            var homeservicedtos = new List<HomeServiceDto>();
            try
            {
               homeservicedtos = await _homeServiceRepository.GetAllInfo(cancellationToken,id);
                if(homeservicedtos is null)
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return homeservicedtos;
        }

        public async Task<HomeServiceDto?> GetInfo(int id, CancellationToken cancellationToken)
        {
            var homeservicedto = new HomeServiceDto();
            try
            {
                homeservicedto = await _homeServiceRepository.GetInfo(id,cancellationToken);
                if (homeservicedto is null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return homeservicedto;
        }

        public async Task<List<SubcategoryDto>?> SubCategories(CancellationToken cancellationToken)
        {
            return await _homeServiceRepository.GetAllSubCategories(cancellationToken);
        }

        public Task<Result> Update(HomeServiceDto objct, CancellationToken cancellationToken)
        {
            return _homeServiceRepository.Update(objct, cancellationToken);
        }

        public Task<Result> Validation(Core.HomeServices_Manager.HomeServices.Entities.HomeService objct, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
