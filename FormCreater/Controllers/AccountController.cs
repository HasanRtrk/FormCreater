using FormCreater.Identity;
using FormCreater.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FormCreater.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Lütfen tekrar deneyin.");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: true, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Form");
            }
            ModelState.AddModelError("", "Şifre veya kullanıcı adı hatalı.");
            return View(model);
        }



        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new User()
            {
                UserName = model.UserName,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
               
                return RedirectToAction("Login", "Account");
            }
            else
            {
                result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
            }
            return View(model);
        }
        public async Task<IActionResult> logout(RegisterModel model)
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
    }
}
