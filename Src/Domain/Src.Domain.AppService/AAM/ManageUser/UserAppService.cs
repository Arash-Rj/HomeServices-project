using Microsoft.AspNetCore.Identity;
using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.AAM.ManageUser.AppService;
using Src.Domain.Core.AAM.ManageUser.Service;
using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.AAM.ManageUser.Enums;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Entities;

namespace Src.Domain.AppService.AAM.ManageUser.Entities
{
    public class UserAppService : IUserAppService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;
        public UserAppService(IUserService userService, SignInManager<User> signInManager,UserManager<User> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        public Task<List<UserDto>> GetAllUsers(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(int id,CancellationToken cancellationToken)
        {
            var user = new User();
            try
            {
                user = await _userService.GetById(id, cancellationToken);
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public async Task<Result> Login(string username, string password, bool rememberMe,CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == username || u.PhoneNumber == username || u.UserName == username);
            if (user != null)
            {
                //var result = await _userManager.CheckPasswordAsync(user, password);
                var signinresult = await _signInManager.PasswordSignInAsync(user, password, rememberMe, false);
                if (!signinresult.Succeeded)
                {
                    return new Result(false, "پسورد شما اشتباه است");
                }
                return new Result(true);
            }
          
            return new Result(false,"یوزر با این نام کاربری وجود ندارد."); /*result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();*/
        }

        public async Task<Result> Register(UserDto model, CancellationToken cancellationToken)
        {
            var result = new IdentityResult();
            if(RoleEnum.Admin == model.Role)
            {
                return new Result(false,"برو خودتو رنگ کن.");
            }
            else
            {
                try
                {
                    if (model.Role == RoleEnum.Customer)
                    {
                        var customer = new AppCustomer { Email = model.Email, UserName = model.UserName, IsActive = true };
                        result = await _userManager.CreateAsync(customer, model.Password);
                        await _userManager.AddToRoleAsync(customer, model.Role.ToString());
                    }
                    if (model.Role == RoleEnum.Expert)
                    {
                        var expert = new AppExpert { Email = model.Email, UserName = model.UserName, IsActive = true };
                        result = await _userManager.CreateAsync(expert, model.Password);
                        await _userManager.AddToRoleAsync(expert, model.Role.ToString());
                    }
                    if (result.Succeeded)
                    {
                        var signin = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
                        return new Result(true, "ثبت نام با موفقیت انجام شد.");
                    }
                    else
                    {
                        return new Result(false, result.Errors.First().Description);
                    }
                }
                catch (Exception ex)
                {
                    return new Result(false, result.Errors.First().Description);
                }
            }
        }

        public async Task<RoleEnum?> GetRole(int id, CancellationToken cancellationToken)
        {
            return await _userService.GetRole(id, cancellationToken);
        }

    }
}
