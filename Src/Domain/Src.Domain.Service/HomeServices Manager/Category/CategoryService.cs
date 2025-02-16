using Microsoft.Data.SqlClient;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Repository;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Service.Services_Manager.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result> Add(CancellationToken cancellationToken,string title,string? imagepath=null)
        {
            return await _categoryRepository.Create(cancellationToken,title,imagepath);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            return await _categoryRepository.Delete(id,cancellationToken);
        }

        public async Task<List<Core.HomeServices_Manager.HomeServices.Entities.Category>?> GetAllInfo(CancellationToken cancellationToken)
        {
            var categories = new List<Core.HomeServices_Manager.HomeServices.Entities.Category>();
            try
            {
                categories = await _categoryRepository.GetAll(cancellationToken);
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
                category = await _categoryRepository.Get(id,cancellationToken);
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
            return await _categoryRepository.Update(cancellationToken, title, imagepath);
        }

        public async Task<Result> Validation(Core.HomeServices_Manager.HomeServices.Entities.Category objct, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
