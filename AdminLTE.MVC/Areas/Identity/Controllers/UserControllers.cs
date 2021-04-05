using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace AdminLTE.MVC.Areas.Identity.Controllers
{
    public class UserControllers : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public class InputModel
        {
            [Required]
            [Display(Name = "Senha atual")]
            public string OldPassword { get; set; }
            [Required]
            [Display(Name = "Nova Senha")]
            public string NewPassword { get; set; }

        }

       

        public UserControllers(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        
        // GET: UserControllers
        public ActionResult Index()
        {

            return View();
        }

        // GET: UserControllers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserControllers/Edit/5
        public async Task<ActionResult> Edit([Bind("OldPassword,NewPassword")] InputModel model)
        {
            //var newPassword = _userManager.PasswordHasher.HashPassword(user, newpass); 
            //user.PasswordHash = newPassword; 
            //var res = await _userManager.UpdateAsync(User);


            string Id = _userManager.GetUserId(User);
           
         
            //var result = await _userManager.ChangePasswordAsync(Id,
            //                                                   model.OldPassword,
            //                                                   model.NewPassword);
            //if (result.Succeeded)
            //{

            //    return RedirectToAction("Index");
            //}
            return View();
        }

        // POST: UserControllers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserControllers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserControllers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
