using BinhDinhFoodWeb.Models;
using BinhDinhFood.Models;
namespace BinhDinhFoodWeb.Intefaces
{
    public interface IUserRepository
    {
        public CookieUserItem Register(RegisterViewModel model);
        public CookieUserItem Validate(LoginViewModel model);
        public Task<bool> HaveAccount(ForgotViewModel model);
        public Task<bool> HaveAccount(string userName,string password);
        public Task ResetPassWord(ResetViewModel model);
        public string CreateResetPasswordLink(string customerUserName);
        public Task ChangeInforUser(ChangeInforViewModel model,int id);
        public Task ChangePasswordUser(ChangePasswordViewModel model,int id);
        public ChangeInforViewModel GetUserInfor(int id);
    }
}

