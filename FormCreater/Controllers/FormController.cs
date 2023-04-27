using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FormCreater.Identity;
using FormCreater.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FormCreater.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        private IFormService _formService;
        private UserManager<FormCreater.Identity.User> _userManager;

        public FormController(UserManager<Identity.User> userManager, IFormService formService)
        {
            _userManager = userManager;
            _formService = formService;
        }

        public IActionResult Index()
        {
            var values = _formService.GetForms();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AddForm(string formName, string formDesc, string userName, string firstColumn, string secondColumn, string thirdColumn)
        {
            var f = new Form();
            bool value = false;
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                f.UserId = user.Id;
                f.CreatedBy = user.UserName;
                f.CreatedAt = DateTime.Now;
                f.FormName = formName;
                f.Description = formDesc;
                f.FirstColumn = firstColumn;
                f.SecondColumn = secondColumn;
                f.ThirdColumn = thirdColumn;
                _formService.AddForm(f);
                value = true;
            }
            catch (Exception)
            {
                value = false;
            }
            return this.Json(value);
        }


        public JsonResult DeleteForm(Form model)
        {
            bool value = false;
            try
            {
                _formService.DeleteForm(model);
                value = true;
            }
            catch (Exception)
            {
                value = false;
            }
            return Json(value);
        }

        public IActionResult FormDetail(int id)
        {
            var values = _formService.GetById(id);
            return View(values);
        }




    }
}
