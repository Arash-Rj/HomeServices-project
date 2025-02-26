using Src.Domain.Core.HomeServices_Manager.HomeServices;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Dtos;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Models
{
    public class DisplayServiceModels
    {
         public List<HomeServiceDto>? HomeServices { get; set; }
         public List<SubcategoryDto>? Subcategories { get; set; }
         public List<DisplayCategoryModel> Categories { get; set; } = new List<DisplayCategoryModel>();
         public List<CreateHomeServiceModel> HomeServiceModels { get; set; } = new List<CreateHomeServiceModel>();
         public CreateHomeServiceModel CreateHomeServiceModel { get; set; }
         public CreateSubCategoryModel CreateSubCategoryModel { get; set; }
         public HomeServiceDto? HomeService { get; set; }
    }
}
