using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.AppService;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Repository;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.AppService.Services_Manager.Category
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        public CategoryAppService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<Result> Add(CancellationToken cancellationToken, string title, string? imagepath = null)
        {
            return await _categoryService.Add(cancellationToken, title, imagepath);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            return await _categoryService.Delete(id, cancellationToken);
        }

        public async Task<List<Core.HomeServices_Manager.HomeServices.Entities.Category>?> GetAllInfo(CancellationToken cancellationToken)
        {
            var categories = new List<Core.HomeServices_Manager.HomeServices.Entities.Category>();
            try
            {
                categories = await _categoryService.GetAllInfo(cancellationToken);
                if (categories is null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categories;
        }

        public async Task<Core.HomeServices_Manager.HomeServices.Entities.Category?> GetInfo(int id, CancellationToken cancellationToken)
        {
            var category = new Core.HomeServices_Manager.HomeServices.Entities.Category();
            try
            {
                category = await _categoryService.GetInfo(id, cancellationToken);
                if (category is null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return category;
        }

        public async Task<Result> Update(CancellationToken cancellationToken, string title, string? imagepath = null)
        {
            return await _categoryService.Update(cancellationToken, title, imagepath);
        }

    }
}
