using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Repository;
using Src.Infra.DataBase.SqlServer.Ef.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Ifra.DataAccess.Repos.Ef.HomeServices_Manager.HomeServices
{
    public class HomeServicesRepository : IHomeServiceRepository
    {
        private readonly AppDbContext _appDbContext;
        public HomeServicesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Result> Create(HomeServiceDto homeServicedto, CancellationToken cancellationToken)
        {
            var homeservice = new HomeService() 
            {
                Title = homeServicedto.Title,
                Description = homeServicedto.Description,
                BasePrice = homeServicedto.BasePrice,
                IsActive = true,
                ImagePath = homeServicedto.ImagePath,
                SubCategoryId = homeServicedto.SubcategoryId,
                Views = 1
            };
            try
            {
                await _appDbContext.HomeServices.AddAsync(homeservice, cancellationToken);
                var res = await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "ثبت سرویس خانه با موفقیت انجام شد.");
        }

        public async Task<List<HomeServiceDto>>? GetAllInfo(CancellationToken cancellationToken)
        {
            var homeservicedtos = new List<HomeServiceDto>();
            try
            {
               var homeservices = await _appDbContext.HomeServices.Select(
                    h => new {h.Id, h.BasePrice, h.ImagePath , h.SubCategory.Name , h.IsActive ,h.Title }
                    )
                    .ToListAsync(cancellationToken);
                foreach ( var homeservice in homeservices )
                {
                    homeservicedtos.Add(new HomeServiceDto() 
                    {
                        Id = homeservice.Id,
                        BasePrice = homeservice.BasePrice,
                        ImagePath = homeservice.ImagePath,
                        Title = homeservice.Title,
                        IsActive = homeservice.IsActive,
                        SubCategoryName = homeservice.Name,                   
                    });
                }
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return homeservicedtos;
        }

        public async Task<List<SubCategory>> GetAllSubCategories(CancellationToken cancellationToken)
        {
            var subcategories = new List<SubCategory>();
            try
            {
                subcategories = await _appDbContext.SubCategories.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return subcategories;
            }
            return subcategories;
        }

        public async Task<Result> Update(HomeServiceDto homeServicedto, CancellationToken cancellationToken)
        {
            try
            {
                var homeservice = await _appDbContext.HomeServices.FirstOrDefaultAsync(h => h.Id == homeServicedto.Id);
                if (homeservice is null)
                {
                    return new Result(false, "سرویس خانه ای با این ایدی یافت نشد!");
                }
                #region Mapping
                homeservice.BasePrice = homeServicedto.BasePrice;
                homeservice.ImagePath = homeServicedto.ImagePath;
                homeservice.Title = homeServicedto.Title;
                homeservice.Description = homeServicedto.Description;
                homeservice.IsActive = homeServicedto.IsActive;
                #endregion
                _appDbContext.HomeServices.Update(homeservice);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "تغییر سرویس خانه با موفقیت انجام شد.");
        }
    }
}
