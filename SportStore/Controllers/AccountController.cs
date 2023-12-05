using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Tree;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> usiManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> usiMng, SignInManager<IdentityUser> signMng)
        {
            usiManager = usiMng;
            signInManager = signMng;
        }
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                Name = string.Empty,
                Password = string.Empty,
                ReturnUrl = returnUrl,
            });
        }
    }
}
