using System.ComponentModel.DataAnnotations;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Models
{
    public class CreateSubCategoryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "وارد کردن عنوان الزامی میباشد.")]
        [MaxLength(30, ErrorMessage = "توضیحات بیش از حد طولانی است.")]
        public string Title { get; set; }
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "وارد کردن عکس اجباری میباشد.")]
        public IFormFile ImageFile { get; set; }
    }
}
