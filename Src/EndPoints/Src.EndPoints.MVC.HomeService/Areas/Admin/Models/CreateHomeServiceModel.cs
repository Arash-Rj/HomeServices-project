using System.ComponentModel.DataAnnotations;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Models
{
    public class CreateHomeServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "وارد کردن عنوان الزامی میباشد.")]
        [MaxLength(30, ErrorMessage = "توضیحات بیش از حد طولانی است.")]
        public string Title { get; set; }

        public int SubcategoryId { get; set; }
        public string? SubcategoryName { get; set; }

        [Required(ErrorMessage = "وارد کردن قیمت پایه الزامی میباشد.")]
        public float BasePrice { get; set; }

        [Required(ErrorMessage = "وارد کردن توضیحات الزامی میباشد.")]
        [MaxLength(300, ErrorMessage = "توضیحات بیش از حد طولانی است.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "وارد کردن عکس اجباری میباشد.")]
        public IFormFile? ImageFile { get; set; }
        public bool IsActive { get; set; }
        public string? ImagePath { get; set; }
    }
}
