using System.ComponentModel.DataAnnotations;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Models
{
    public class AdminLoginModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن نام کاربری اجباری میباشد.")]
        public string UserName { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "وارد کردن رمز عبور اجباری میباشد.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
