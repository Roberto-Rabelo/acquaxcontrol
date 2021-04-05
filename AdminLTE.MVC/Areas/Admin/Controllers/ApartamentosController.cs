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
    public class ApartamentosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ApartamentosController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
    

        // GET: Admin/Apartamentos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.apartamentos.Include(a => a.Blocos);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Apartamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.apartamentos
                .Include(a => a.Blocos)
                .FirstOrDefaultAsync(m => m.ApartamentoId == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            return View(apartamento);
        }

        // GET: Admin/Apartamentos/Create
        public IActionResult Create()
        {
            DateTime data = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
           
            var teste = (from c in _userManager.Users
                        where c.LockoutEnd >= data.Date select c).ToList();

            ViewData["BlocosId"] = new SelectList(_context.blocos, "BlocosId", "Bloco");
            var users = _userManager.Users.OrderBy(e => e.LockoutEnd).OrderBy(e => e.UserName);
            ViewData["Id"] = new SelectList(teste.OrderByDescending(e => e.UserName));
            //ViewData["Id"] = new SelectList(teste.OrderBy(e => e.UserName).Take(240));
        return View();
        }
        public IActionResult CreateHard()
        {
            DateTime data = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

            var teste = (from c in _userManager.Users
                         orderby c.LockoutEnd
                         select c).ToList();

            ViewData["BlocosId"] = new SelectList(_context.blocos, "BlocosId", "Bloco");
            var users = _userManager.Users.OrderBy(e => e.LockoutEnd).OrderBy(e => e.UserName);
            ViewData["Id"] = new SelectList(teste.OrderBy(e => e.UserName).Take(5000));
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHard([Bind("ApartamentoId,Nome,apartamentos,IdAspNetUsers,BlocosId")] Apartamento apartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CreateHard));
            }
            ViewData["BlocosId"] = new SelectList(_context.blocos, "BlocosId", "Bloco", apartamento.BlocosId);
            //var users = AspNetUserManager.Users<>;
            //ViewData["Id"] = users;
            return View(CreateHard());
        }
        // POST: Admin/Apartamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApartamentoId,Nome,apartamentos,IdAspNetUsers,BlocosId")] Apartamento apartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            ViewData["BlocosId"] = new SelectList(_context.blocos, "BlocosId", "Bloco", apartamento.BlocosId);
            //var users = AspNetUserManager.Users<>;
            //ViewData["Id"] = users;
            return View(apartamento);
        }

        // GET: Admin/Apartamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var users = _userManager.Users;
            ViewData["Id"] = new SelectList(users);
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.apartamentos.FindAsync(id);
            if (apartamento == null)
            {
                return NotFound();
            }
            ViewData["BlocosId"] = new SelectList(_context.blocos, "BlocosId", "Bloco", apartamento.BlocosId);
            return View(apartamento);
        }

        // POST: Admin/Apartamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApartamentoId,Nome,apartamentos,IdAspNetUsers,BlocosId")] Apartamento apartamento)
        {
            if (id != apartamento.ApartamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartamentoExists(apartamento.ApartamentoId))
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
            ViewData["BlocosId"] = new SelectList(_context.blocos, "BlocosId", "Bloco", apartamento.BlocosId);
            return View(apartamento);
        }

        // GET: Admin/Apartamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.apartamentos
                .Include(a => a.Blocos)
                .FirstOrDefaultAsync(m => m.ApartamentoId == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            return View(apartamento);
        }

        // POST: Admin/Apartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartamento = await _context.apartamentos.FindAsync(id);
            _context.apartamentos.Remove(apartamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartamentoExists(int id)
        {
            return _context.apartamentos.Any(e => e.ApartamentoId == id);
        }
        public IActionResult filtro(int? id)
        {
            var block = _context.aguaApartamentos.Where(l => l.ApartamentoId == id);

            return View(block);
        }
    }
    
}
