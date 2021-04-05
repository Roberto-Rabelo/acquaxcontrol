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
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace AdminLTE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AguaApartamentosController : Controller
    {
 

        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AguaApartamentosController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        // GET: Admin/AguaApartamentos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.aguaApartamentos.Include(a => a.Apartamento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/AguaApartamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aguaApartamento = await _context.aguaApartamentos
                .Include(a => a.Apartamento)
                .FirstOrDefaultAsync(m => m.AguaApartamentoId == id);
            if (aguaApartamento == null)
            {
                return NotFound();
            }

            return View(aguaApartamento);
        }

        // GET: Admin/AguaApartamentos/Create
        public IActionResult Create()
        {
            ViewData["ApartamentoId"] = new SelectList(_context.apartamentos, "ApartamentoId", "Nome");
           
            return View();
        }

        // POST: Admin/AguaApartamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AguaApartamentoId,dt_leitura_atual,dt_leitura_anterior,dt_leitura_proxima,bloco,Unidade,mes_anterior,mes_atual,volume_consumido,vlr_agua,vlr_esgoto,area_comum,total_unidade,FotoPath,ApartamentoId")] AguaApartamento aguaApartamento, IFormFile files)
        {
            if (ModelState.IsValid)
            {
                string blobstorageconnection = _configuration.GetConnectionString("blobstorage");
          

                byte[] dataFiles;
                // Retrieve storage account from connection string.
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
                // Create the blob client.
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                // Retrieve a reference to a container.
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("image");

                BlobContainerPermissions permissions = new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                };
                string systemFileName = files.FileName;
                await cloudBlobContainer.SetPermissionsAsync(permissions);
                await using (var target = new MemoryStream())
                {
                    files.CopyTo(target);
                    dataFiles = target.ToArray();
                }
                // This also does not make a service call; it only creates a local object.
                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(systemFileName);
                await cloudBlockBlob.UploadFromByteArrayAsync(dataFiles, 0, dataFiles.Length);

                
                aguaApartamento.FotoPath = cloudBlockBlob.StorageUri.PrimaryUri.OriginalString;
                
                _context.Add(aguaApartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApartamentoId"] = new SelectList(_context.apartamentos, "ApartamentoId", "Nome", aguaApartamento.ApartamentoId);
            return View(aguaApartamento);
        }
        // GET: Admin/AguaApartamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aguaApartamento = await _context.aguaApartamentos.FindAsync(id);
            if (aguaApartamento == null)
            {
                return NotFound();
            }
            ViewData["ApartamentoId"] = new SelectList(_context.apartamentos, "ApartamentoId", "Nome", aguaApartamento.ApartamentoId);
            return View(aguaApartamento);
        }

        // POST: Admin/AguaApartamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AguaApartamentoId,dt_leitura_atual,dt_leitura_anterior,dt_leitura_proxima,bloco,Unidade,mes_anterior,mes_atual,volume_consumido,vlr_agua,vlr_esgoto,area_comum,total_unidade,FotoPath,ApartamentoId")] AguaApartamento aguaApartamento)
        {
            if (id != aguaApartamento.AguaApartamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aguaApartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AguaApartamentoExists(aguaApartamento.AguaApartamentoId))
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
            ViewData["ApartamentoId"] = new SelectList(_context.apartamentos, "ApartamentoId", "Nome", aguaApartamento.ApartamentoId);
            return View(aguaApartamento);
        }

        // GET: Admin/AguaApartamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aguaApartamento = await _context.aguaApartamentos
                .Include(a => a.Apartamento)
                .FirstOrDefaultAsync(m => m.AguaApartamentoId == id);
            if (aguaApartamento == null)
            {
                return NotFound();
            }

            return View(aguaApartamento);
        }

        // POST: Admin/AguaApartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aguaApartamento = await _context.aguaApartamentos.FindAsync(id);
            _context.aguaApartamentos.Remove(aguaApartamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AguaApartamentoExists(int id)
        {
            return _context.aguaApartamentos.Any(e => e.AguaApartamentoId == id);
        }
    }
}
