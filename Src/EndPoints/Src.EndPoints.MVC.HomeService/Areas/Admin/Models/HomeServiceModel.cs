using Src.Domain.Core.HomeServices_Manager.HomeServices;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Models
{
    public class HomeServiceModel
    {
         public HomeServiceDto HomeService { get; set; }
         public List<HomeServiceDto> HomeServices { get; set; }
         public CreateHomeServiceModel CreateHomeServiceModel { get; set; }
        public List<SubcategoryDto> Subcategories { get; set; }
    }
    public class CreateHomeServiceModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SubcategoryId { get; set; }
        public float BasePrice { get; set; }
        [Required(ErrorMessage ="وارد کردن توضیحات الزامی میباشد.")]
        [MaxLength(300,ErrorMessage ="توضیحات بیش از حد طولانی است.")]
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }
        public bool IsActive { get; set; }
    }
}
