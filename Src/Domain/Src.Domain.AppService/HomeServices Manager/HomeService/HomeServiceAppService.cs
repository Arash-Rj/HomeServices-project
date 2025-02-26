using Microsoft.IdentityModel.Tokens;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices;
using Src.Domain.Core.HomeServices_Manager.HomeServices.AppService;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Dtos;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Service;
using Src.Domain.Service.Services_Manager.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.AppService.Services_Manager.Service
{
    public class HomeServiceAppService : IHomeServiceAppService
    {
        private readonly IHomeServiceService _homeServiceService;
        public HomeServiceAppService(IHomeServiceService homeServiceService)
        {          
            _homeServiceService = homeServiceService;
        }
        public async Task<Result> Add(HomeServiceDto homeServiceDto, CancellationToken cancellationToken)
        {
            return await _homeServiceService.Add(homeServiceDto, cancellationToken);
        }

        public async Task<Result> CreateSubCategory(SubcategoryDto subcategory, CancellationToken cancellationToken)
        {
            return await _homeServiceService.CreateSubCategory(subcategory, cancellationToken);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            return await _homeServiceService.Delete(id, cancellationToken);
        }

        public async Task<List<HomeServiceDto>?> GetAllInfo(CancellationToken cancellationToken, int id = 0)
        {
            var homeservicedtos = new List<HomeServiceDto>();
            try
            {
                homeservicedtos = await _homeServiceService.GetAllInfo(cancellationToken,id);
                foreach(var hom in homeservicedtos)
                {
                   hom.ImagePath = "Images/HomeServices/" +hom.ImagePath;
                }
            }
            catch (Exception ex)
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
                homeservicedto = await _homeServiceService.GetInfo(id, cancellationToken);
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
            var subs = new List<SubcategoryDto>();
            try
            {
                subs = await _homeServiceService.SubCategories(cancellationToken);
                foreach (var sub in subs)
                {
                    if(sub.ImagePath is not null)
                    {
                        if (!sub.ImagePath.Contains("Images/Sub-Categories/"))
                        {
                            sub.ImagePath = "Images/Sub-Categories/" + sub.ImagePath;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return subs;
        }

        public async Task<Result> Update(HomeServiceDto homeServiceDto, CancellationToken cancellationToken)
        {
            return await _homeServiceService.Update(homeServiceDto, cancellationToken);
        }
    }
}
