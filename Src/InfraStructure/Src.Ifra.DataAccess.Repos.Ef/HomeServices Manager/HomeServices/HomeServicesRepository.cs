using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.Base.Entities;
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
        public async Task<Result> Create(HomeService homeService, CancellationToken cancellationToken)
        {
            try
            {
                await _appDbContext.HomeServices.AddAsync(homeService, cancellationToken);
                var res = _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "ثبت سرویس خانه با موفقیت انجام شد.");
        }

        public async Task<List<Domain.Core.HomeServices_Manager.HomeServices.Entities.Category>> GetAllCategories(CancellationToken cancellationToken)
        {
            var categoreis = new List<Domain.Core.HomeServices_Manager.HomeServices.Entities.Category>();
            try
            {
                categoreis = await _appDbContext.Categories.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return categoreis;
            }
            return categoreis;
        }

        public async Task<List<HomeService>> GetAllHomeService(CancellationToken cancellationToken)
        {
            var homeservices = new List<HomeService>();
            try
            {
                homeservices = await _appDbContext.HomeServices.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return homeservices;
            }
            return homeservices;
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

        public async Task<Result> Update(HomeService homeService, CancellationToken cancellationToken)
        {
            try
            {
                _appDbContext.HomeServices.Update(homeService);
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
