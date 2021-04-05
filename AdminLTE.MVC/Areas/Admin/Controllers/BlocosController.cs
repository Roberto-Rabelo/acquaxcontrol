using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models;

namespace AdminLTE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlocosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlocosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Blocos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.blocos.Include(b => b.Condominio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Blocos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blocos = await _context.blocos
                .Include(b => b.Condominio)
                .FirstOrDefaultAsync(m => m.BlocosId == id);
            if (blocos == null)
            {
                return NotFound();
            }

            return View(blocos);
        }

        // GET: Admin/Blocos/Create
        public IActionResult Create()
        {
            ViewData["CondominioId"] = new SelectList(_context.condominios.OrderBy(x => x.Nome), "CondominioId", "Nome");
            return View();
        }

        // POST: Admin/Blocos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlocosId,Bloco,Descricao,CondominioId")] Blocos blocos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blocos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CondominioId"] = new SelectList(_context.condominios, "CondominioId", "Nome", blocos.CondominioId);
            return View(blocos);
        }

        // GET: Admin/Blocos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blocos = await _context.blocos.FindAsync(id);
            if (blocos == null)
            {
                return NotFound();
            }
            ViewData["CondominioId"] = new SelectList(_context.condominios, "CondominioId", "Nome", blocos.CondominioId);
            return View(blocos);
        }

        // POST: Admin/Blocos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlocosId,Bloco,Descricao,CondominioId")] Blocos blocos)
        {
            if (id != blocos.BlocosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blocos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlocosExists(blocos.BlocosId))
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
            ViewData["CondominioId"] = new SelectList(_context.condominios, "CondominioId", "Nome", blocos.CondominioId);
            return View(blocos);
        }

        // GET: Admin/Blocos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blocos = await _context.blocos
                .Include(b => b.Condominio)
                .FirstOrDefaultAsync(m => m.BlocosId == id);
            if (blocos == null)
            {
                return NotFound();
            }

            return View(blocos);
        }

        // POST: Admin/Blocos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blocos = await _context.blocos.FindAsync(id);
            _context.blocos.Remove(blocos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlocosExists(int id)
        {
            return _context.blocos.Any(e => e.BlocosId == id);
        }
        public IActionResult filtro(int ?id)
        {

            var block = _context.apartamentos.Where(l => l.BlocosId == id);

            return View(block);
        }
    }
}
