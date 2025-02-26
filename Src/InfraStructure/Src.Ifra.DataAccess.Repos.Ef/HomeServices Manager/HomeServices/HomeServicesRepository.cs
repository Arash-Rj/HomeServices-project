using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using Src.Domain.Core.HomeServices_Manager.HomeServices;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Dtos;
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

        public async Task<Result> CreateSubCategory(SubcategoryDto subcategoryDto, CancellationToken cancellationToken)
        {
            var subCategory = new SubCategory()
            {
                Name = subcategoryDto.Name,
                ImagePath = subcategoryDto.ImagePath,
                CategoryId = subcategoryDto.CategoryId,
            };
            try
            {
                await _appDbContext.SubCategories.AddAsync(subCategory, cancellationToken);
                var res = await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "ثبت زیر مجموعه با موفقیت انجام شد.");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var service = _appDbContext.HomeServices.FirstOrDefault(x => x.Id == id);
                if (service == null)
                    return new Result(false, "سرویس خانه ای با این ایدی پیدا نشد!");
                _appDbContext.HomeServices.Remove(service);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "حذف سرویس خانه با موفقیت انجام شد.");
        }

        public async Task<List<HomeServiceDto>?> GetAllInfo(CancellationToken cancellationToken, int id = 0)
        {
            var homeservicedtos = new List<HomeServiceDto>();
            try
            {
                if (id == 0)
                {
                    var homeservices = await _appDbContext.HomeServices.Select(
                      h => new { h.Id, h.BasePrice, h.ImagePath, h.SubCategory.Name, h.IsActive, h.Title, h.Description }
                    )
                    .ToListAsync(cancellationToken);
                    foreach (var homeservice in homeservices)
                    {
                        homeservicedtos.Add(new HomeServiceDto()
                        {
                            Id = homeservice.Id,
                            BasePrice = homeservice.BasePrice,
                            ImagePath = homeservice.ImagePath,
                            Title = homeservice.Title,
                            IsActive = homeservice.IsActive,
                            SubCategoryName = homeservice.Name,
                            Description = homeservice.Description
                        });
                    }
                }
                else
                {
                    var homeservices = await _appDbContext.HomeServices.Where(h => h.SubCategoryId.Equals(id)).Select(
                         h => new { h.Id, h.BasePrice, h.ImagePath, h.SubCategory.Name, h.IsActive, h.Title }
                    )
                    .ToListAsync(cancellationToken);
                    foreach (var homeservice in homeservices)
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

        public async Task<List<SubcategoryDto>?> GetAllSubCategories(CancellationToken cancellationToken)
        {
            var subcategoryDtos = new List<SubcategoryDto>();
            try
            {
                var subcategories = await _appDbContext.SubCategories
                     .Select(s => new { s.ImagePath, s.Id, s.Category.Title, s.Name }).ToListAsync();
                foreach (var sub in subcategories)
                {
                    var subcategoryDto = new SubcategoryDto()
                    {
                        Id = sub.Id,
                        CategoryName = sub.Title,
                        ImagePath = sub.ImagePath,
                        Name = sub.Name,
                    };
                    subcategoryDtos.Add(subcategoryDto);
                }
            }
            catch(NullReferenceException ex) 
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return subcategoryDtos;
        }

        public async Task<HomeServiceDto?> GetInfo(int id, CancellationToken cancellationToken)
        {
            var homeServiceDto = new HomeServiceDto();
            try
            {
                var homeService = await _appDbContext.HomeServices.Select(p =>
                new {
                    p.Id,
                    p.Title,
                    p.Description,
                    p.BasePrice,
                    p.ImagePath,
                    p.SubCategory.Name,
                    p.IsActive
                })
                    .FirstAsync(u => u.Id.Equals(id), cancellationToken);

                #region Mapping 
                homeServiceDto.Id = homeService.Id;
                homeServiceDto.ImagePath = homeService.ImagePath;
                homeServiceDto.BasePrice = homeService.BasePrice;
                homeServiceDto.Description = homeService.Description;
                homeServiceDto.IsActive = homeService.IsActive;
                homeServiceDto.Title = homeService.Title;
                homeServiceDto.SubCategoryName = homeService.Name;
                #endregion

            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return homeServiceDto;
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
