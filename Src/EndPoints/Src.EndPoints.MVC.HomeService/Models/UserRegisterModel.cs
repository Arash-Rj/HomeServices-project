using Microsoft.Identity.Client;
using Src.Domain.Core.AAM.ManageUser.Enums;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Src.EndPoints.MVC.HomeService.Models
{
    public class UserRegisterModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن نام کاربری اجباری میباشد.")]
        public string UserName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "وارد کردن ایمیل اجباری میباشد.")]
        public string Email { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "وارد کردن رمز عبور اجباری میباشد.")]
        public string Password { get; set; }
        [Display(Name ="نقش")]
        [Required(ErrorMessage ="وارد کردن نقش اجباری میباشد.")]
        public RoleEnum Role { get; set; }
        //public IFormFile? ProfileImgFile { get; set; }

        //public string? ImagePath { get; set; }
    }
}
