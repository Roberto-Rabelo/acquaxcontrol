using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models;
using Microsoft.AspNetCore.Identity;

namespace AdminLTE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CondominiosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public CondominiosController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: Admin/Condominios
        public async Task<IActionResult> Index()
        {
         
            return View(await _context.condominios.ToListAsync());
        }

        // GET: Admin/Condominios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condominio = await _context.condominios
                .FirstOrDefaultAsync(m => m.CondominioId == id);

           

            if (condominio == null)
            {
                return NotFound();
            }

            return View(condominio);

            
        }

        // GET: Admin/Condominios/Create
        public IActionResult Create()
        {
            var users = _userManager.Users.Where(a => a.PhoneNumber == "Sindico");
            ViewData["Sindico"] = new SelectList(users);
            return View();
        }

        // POST: Admin/Condominios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CondominioId,Nome,Endereco,Numero,Bairro,Estado,FotoPath,Sindico")] Condominio condominio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condominio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condominio);
        }

        // GET: Admin/Condominios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var users = _userManager.Users.Where(c => c.PhoneNumber == "Sindico");
            ViewData["sindico"] = new SelectList(users);
            if (id == null)
            {
                return NotFound();
            }

            var condominio = await _context.condominios.FindAsync(id);
            var block = _context.blocos.Where(l => l.CondominioId == id);

            if (condominio == null)
            {
                return NotFound();
            }
            return View(condominio);
        }

        // POST: Admin/Condominios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CondominioId,Nome,Endereco,Numero,Bairro,Estado,FotoPath,Sindico")] Condominio condominio)
        {

            if (id != condominio.CondominioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condominio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondominioExists(condominio.CondominioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(condominio);
        }

        // GET: Admin/Condominios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
          
            if (id == null)
            {
                return NotFound();
            }

            var condominio = await _context.condominios
                .FirstOrDefaultAsync(m => m.CondominioId == id);
            if (condominio == null)
            {
                return NotFound();
            }

            return View(condominio);
        }

        // POST: Admin/Condominios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var condominio = await _context.condominios.FindAsync(id);
            _context.condominios.Remove(condominio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondominioExists(int id)
        {
            return _context.condominios.Any(e => e.CondominioId == id);
        }

        public IActionResult filtro(int? Id)
        {

            var block = _context.blocos.Where(l => l.CondominioId == Id);

            return View(block);
        }
    }
}
