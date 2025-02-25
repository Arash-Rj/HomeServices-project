using Microsoft.AspNetCore.Http;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Dtos;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices.AppService
{
    public interface ICategoryAppService
    {
        public Task<Result> Add(CancellationToken cancellationToken, string title, string? imagepath = null);
        public Task<Result> Update(CancellationToken cancellationToken, string title, string? imagepath = null);
        public Task<Result> Delete(int id, CancellationToken cancellationToken);
        public Task<Category?> GetInfo(int id, CancellationToken cancellationToken);
        public Task<List<Category>?> GetAllInfo(CancellationToken cancellationToken);
        public Task<List<SubcategoryDto>?> GetSubs(int id, CancellationToken cancellationToken);
    }
}
