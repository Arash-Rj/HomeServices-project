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

namespace Src.Ifra.DataAccess.Repos.Ef.HomeServices_Manager.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Result> Create(CancellationToken cancellationToken, string Title, string? Image = null)
        {
            var category = new Domain.Core.HomeServices_Manager.HomeServices.Entities.Category()
            {
                Title = Title,
                ImagePath = Image
            };
            try
            {
                await _appDbContext.Categories.AddAsync(category, cancellationToken);
                var res = await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "ثبت دسته بندی با موفقیت انجام شد.");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var category = _appDbContext.Categories.FirstOrDefault(x => x.Id == id);
                if (category == null)
                    return new Result(false, "دسته بندی با این ایدی پیدا نشد!");
                _appDbContext.Categories.Remove(category);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "حذف دسته بندی با موفقیت انجام شد.");
        }

        public async Task<Domain.Core.HomeServices_Manager.HomeServices.Entities.Category>? Get(int id, CancellationToken cancellationToken)
        {
            var category = new Domain.Core.HomeServices_Manager.HomeServices.Entities.Category();
            try
            {
                category = await _appDbContext.Categories.FirstAsync(c => c.Id == id , cancellationToken);
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            return category;
        }

        public async Task<List<Domain.Core.HomeServices_Manager.HomeServices.Entities.Category>>? GetAll(CancellationToken cancellationToken)
        {
            var categories = new List<Domain.Core.HomeServices_Manager.HomeServices.Entities.Category>();
            try
            {
                categories = await _appDbContext.Categories.ToListAsync();
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            return categories;
        }

        public async Task<Result> Update(CancellationToken cancellationToken, string Title, string? Image = null)
        {
            try
            {
                var category = _appDbContext.Categories.FirstOrDefault(x => x.Title == Title);
                if (category == null)
                    return new Result(false, "دسته بندی با این ایدی پیدا نشد!");
                _appDbContext.Categories.Remove(category);
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "تغییر دسته بندی با موفقیت انجام شد.");
        }
    }
}
