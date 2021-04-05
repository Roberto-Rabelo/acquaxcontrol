using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AdminLTE.MVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdminLTE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public class InputModel
        {

            
           
            [Display(Name = "ID")]
            public string Id { get; set; }

            
           
            [Display(Name = "Usuário")]
            public string UserName { get; set; }

            
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

         
            
            [Display(Name = "Categoria")]
            public string Categoria { get; set; }

        }
        public IActionResult Index()
        {

            return View();
        }

        public ApplicationDbContext _context { get; }

        private readonly UserManager<IdentityUser> _usermanage;

        public AdminController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _usermanage = userManager;
        }
        public IActionResult ListUser()
        {
            var users = _usermanage.Users.ToList().OrderBy(a => a.UserName);
            return View(users);
        }
        public async Task<IActionResult> Edit(string id)
        {
            var usuario = await _usermanage.FindByIdAsync(id);
            if (usuario == null)
            {
                ViewBag.ErrorMessage = "Usuário não foi encontrado";
                return View("Not found");
            }

            var model = new InputModel
            {
                Id = usuario.Id,
                Email = usuario.Email,
                UserName = usuario.UserName,
                Categoria = usuario.PhoneNumber
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InputModel model)
        {
            var usuario = await _usermanage.FindByIdAsync(model.Id);
            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var usu = _context.apartamentos.Where(u => u.IdAspNetUsers == usuario.UserName).ToList(); 
              
                usuario.Id = model.Id;
                usuario.Email = model.Email;
                usuario.UserName = model.UserName;
                await _usermanage.RemoveFromRoleAsync(usuario, usuario.PhoneNumber);
                usuario.PhoneNumber = model.Categoria;
               
                var result = await _usermanage.UpdateAsync(usuario);

                if (result.Succeeded)
                {
                    await _usermanage.AddToRoleAsync(usuario, model.Categoria);
                    
                    return RedirectToAction("ListUser");
                }
                

            }

            return View();
        }
        public IActionResult Delete()
        {
           
            return View();
        }

    }
}
