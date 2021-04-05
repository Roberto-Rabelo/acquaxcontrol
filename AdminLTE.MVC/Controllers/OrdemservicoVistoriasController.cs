using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace AdminLTE.MVC.Controllers
{
    public class OrdemservicoVistoriasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public OrdemservicoVistoriasController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        //public async Task<IActionResult> Assinatura()
        //{
        //    return View();
        //}

        // GET: OrdemservicoVistorias
        public async Task<IActionResult> Index()
        {
            ViewBag.NumVistoriaAltoConsumo = _context.OrdemservicoVistorias.Where(s => s.status == "A fazer").Count();
            ViewBag.NumVistoriaGeral = _context.OrdemServicoGeral.Where(s => s.status == "A fazer").Count();
            ViewBag.NumVistoriaGeralFeito = _context.OrdemservicoVistorias.Where(s => s.status == "Feito").Count();
            ViewBag.NumVistoriaAltoConsumoFeito = _context.OrdemServicoGeral.Where(s => s.status == "Feito").Count();
            return View(await _context.OrdemservicoVistorias.ToListAsync());
        }
        public async Task<IActionResult> SelectOrdemServico()
        {
            //ViewBag.NumVistoria = _context.OrdemservicoVistorias.Count();
            return View();
        }
        public async Task<IActionResult> ListAltoConsumo()
        {
                var applicationDbContext = _context.OrdemservicoVistorias.Where(s => s.status == "A fazer").Include(a => a.Condominio);
                return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> ListVistoriaGeral()
        {
            var applicationDbContext = _context.OrdemServicoGeral.Where(s => s.status == "A fazer").Include(a => a.Condominio);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> ListVistoriaFeitas()
        {
            var ListVistorialGeral = _context.OrdemServicoGeral.Where(s => s.status == "Feito").Include(a => a.Condominio);
            var ListVistorialAltoCosumo = _context.OrdemservicoVistorias.Where(s => s.status == "Feito").Include(a => a.Condominio);
            ViewBag.ViewListVistorialGeral = ListVistorialGeral;
            ViewBag.ViewListVistorialAltoConsumo = ListVistorialAltoCosumo;
            //await ListVistorialAltoCosumo.ToListAsync(), await ListVistorialGeral.ToListAsync()
            return View();
        }

        private IActionResult View(List<OrdemservicoVistoria> lists1, List<OrdemVistoriaGeral> lists2)
        {
            throw new NotImplementedException();
        }

        // GET: OrdemservicoVistorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemservicoVistoria = await _context.OrdemservicoVistorias
                .FirstOrDefaultAsync(m => m.OrdemservicoVistoriaId == id);
            if (ordemservicoVistoria == null)
            {
                return NotFound();
            }

            return View(ordemservicoVistoria);
        }
        public async Task<IActionResult> filtroDetailsAltoConsumo(int? id)
        {

            var block =  await _context.OrdemservicoVistorias.Include(c => c.Condominio).Where(x => x.OrdemservicoVistoriaId == id).FirstOrDefaultAsync();

        
            return View(block);
        }
        public async Task<IActionResult> filtroDetailsGeral(int? id)
        {

            var block = await _context.OrdemServicoGeral.Include(c => c.Condominio).Where(x => x.OrdemVistoriaGeralId == id).FirstOrDefaultAsync();


            return View(block);
        }
        // GET: OrdemservicoVistorias/Create
        public IActionResult CreateAltoConsumo()
        {
            ViewData["Nome"] = new SelectList(_context.condominios.OrderBy(x => x.Nome), "CondominioId", "Nome");
            return View();
        }

        // POST: OrdemservicoVistorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAltoConsumo([Bind("OrdemservicoVistoriaId,dt_solicitacao,dt_execucao,condominioNovo,endereco,bairro,emailCliente,hidrometroVencido,baixaVazao,torneiraCozinha,torneiraTanque,torneiraLavabo,descargaLavabo,chuveiroBanheiro01,torneiraBanheiro01,descargaBanheiro01,chuveiroBanheiro02,torneiraBanheiro02,descargaBanheiro02,chuveiroBanheiro03,torneiraBanheiro03,descargaBanheiro03,chuveiroBanheiro04,torneiraBanheiro04,descargaBanheiro04,FotoPath,observacao,IdAspNetUsers,assinaturaCliente,condominioId,FotoPath1,FotoPath3,FotoPath4,bloco, unidade, documento,nomeCliente, tipoVistoria, status")] OrdemservicoVistoria ordemservicoVistoria, IFormFile files_Fotopath, IFormFile files_Fotopath1, IFormFile files_Fotopath2, IFormFile files_Fotopath3)
        {

            ViewData["CondominioId"] = new SelectList(_context.condominios.OrderBy(x => x.Nome), "CondominioId", "Nome", ordemservicoVistoria.condominioId);
            ordemservicoVistoria.IdAspNetUsers = User.Identity.Name;
            ordemservicoVistoria.tipoVistoria = "Alto Consumo-Troca";
                _context.Add(ordemservicoVistoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
          
            
            return View();
        }
        // GET: OrdemservicoVistorias/Create
        public IActionResult CreateVistoriaGeral()
        {
            ViewData["Nome"] = new SelectList(_context.condominios.OrderBy(x => x.Nome), "CondominioId", "Nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVistoriaGeral([Bind("OrdemVistoriaGeralId,dt_solicitacao,dt_execucao,dt_agendada,condominioNovo,endereco,bairro,emailCliente,FotoPath,observacao,IdAspNetUsers,assinaturaCliente,condominioId,bloco, unidade, documento,nomeCliente,tipoVistoria,valor,formaPagamento,pago,status")] OrdemVistoriaGeral ordemVistoriaGeral, IFormFile files_Fotopath)
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
            if (ModelState.IsValid)
            {
                ordemVistoriaGeral.IdAspNetUsers = User.Identity.Name;
                // Foto 01 
                if (files_Fotopath == null)
                {
                    ordemVistoriaGeral.FotoPath01 = null;
                }
                else
                {
                    string systemFileName = files_Fotopath.FileName;
                    await cloudBlobContainer.SetPermissionsAsync(permissions);
                    await using (var target = new MemoryStream())
                    {
                        files_Fotopath.CopyTo(target);
                        dataFiles = target.ToArray();
                    }
                    // This also does not make a service call; it only creates a local object.
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(systemFileName);
                    await cloudBlockBlob.UploadFromByteArrayAsync(dataFiles, 0, dataFiles.Length);


                    ordemVistoriaGeral.FotoPath01 = cloudBlockBlob.StorageUri.PrimaryUri.OriginalString;
                }
                ordemVistoriaGeral.tipoVistoria = "Vistoria Geral";


                _context.Add(ordemVistoriaGeral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CondominioId"] = new SelectList(_context.condominios.OrderBy(x => x.Nome), "CondominioId", "Nome", ordemVistoriaGeral.condominioId);

            return View();
        }
        // GET: OrdemservicoVistorias/Edit/5
        public async Task<IActionResult> EditVistoriaAltoConsumo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["Nome"] = new SelectList(_context.condominios.OrderBy(x => x.Nome), "CondominioId", "Nome");
            var ordemservicoVistoria = await _context.OrdemservicoVistorias.FindAsync(id);
            if (ordemservicoVistoria == null)

            {
                return NotFound();
            }
            return View(ordemservicoVistoria);
        }
        // GET: EditVistoriaGeral/Edit/5
        public async Task<IActionResult> EditVistoriaGeral(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["Nome"] = new SelectList(_context.condominios.OrderBy(x => x.Nome), "CondominioId", "Nome");
            var ordemServicoGeral = await _context.OrdemServicoGeral.FindAsync(id);
            if (ordemServicoGeral == null)

            {
                return NotFound();
            }
            return View(ordemServicoGeral);
        }
        // EDIT DE VISTORIA DE ALTO CONSUMO 
        // POST: OrdemservicoVistorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVistoriaAltoConsumo(int id, [Bind("OrdemservicoVistoriaId,dt_solicitacao,dt_execucao,condominioNovo,endereco,bairro,emailCliente,hidrometroVencido,baixaVazao,torneiraCozinha,torneiraTanque,torneiraLavabo,descargaLavabo,chuveiroBanheiro01,torneiraBanheiro01,descargaBanheiro01,chuveiroBanheiro02,torneiraBanheiro02,descargaBanheiro02,chuveiroBanheiro03,torneiraBanheiro03,descargaBanheiro03,chuveiroBanheiro04,torneiraBanheiro04,descargaBanheiro04,FotoPath,observacao,IdAspNetUsers,assinaturaCliente,condominioId,FotoPath1,FotoPath3,FotoPath4,bloco, unidade, documento,nomeCliente, tipoVistoria,status,conclusao")] OrdemservicoVistoria ordemservicoVistoria, IFormFile files_Fotopath, IFormFile files_Fotopath1, IFormFile files_Fotopath2, IFormFile files_Fotopath3)
        {
            ordemservicoVistoria.OrdemservicoVistoriaId = id;
            if (id != ordemservicoVistoria.OrdemservicoVistoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
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
                    if (ModelState.IsValid)
                    {
                        ordemservicoVistoria.IdAspNetUsers = User.Identity.Name;
                        // Foto 01 
                        if (files_Fotopath == null)
                        {
                            ordemservicoVistoria.FotoPath = null;
                        }
                        else
                        {
                            string systemFileName = files_Fotopath.FileName;
                            await cloudBlobContainer.SetPermissionsAsync(permissions);
                            await using (var target = new MemoryStream())
                            {
                                files_Fotopath.CopyTo(target);
                                dataFiles = target.ToArray();
                            }
                            // This also does not make a service call; it only creates a local object.
                            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(systemFileName);
                            await cloudBlockBlob.UploadFromByteArrayAsync(dataFiles, 0, dataFiles.Length);


                            ordemservicoVistoria.FotoPath = cloudBlockBlob.StorageUri.PrimaryUri.OriginalString;
                        }
                        // Foto 02
                        if (files_Fotopath1 == null)
                        {
                            ordemservicoVistoria.FotoPath1 = null;
                        }
                        else
                        {
                            string systemFileName = files_Fotopath1.FileName;
                            await cloudBlobContainer.SetPermissionsAsync(permissions);
                            await using (var target = new MemoryStream())
                            {
                                files_Fotopath1.CopyTo(target);
                                dataFiles = target.ToArray();
                            }
                            // This also does not make a service call; it only creates a local object.
                            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(systemFileName);
                            await cloudBlockBlob.UploadFromByteArrayAsync(dataFiles, 0, dataFiles.Length);


                            ordemservicoVistoria.FotoPath1 = cloudBlockBlob.StorageUri.PrimaryUri.OriginalString;
                        }

                        // Foto 03
                        if (files_Fotopath2 == null)
                        {
                            ordemservicoVistoria.FotoPath3 = null;
                        }
                        else
                        {
                            string systemFileName = files_Fotopath2.FileName;
                            await cloudBlobContainer.SetPermissionsAsync(permissions);
                            await using (var target = new MemoryStream())
                            {
                                files_Fotopath2.CopyTo(target);
                                dataFiles = target.ToArray();
                            }
                            // This also does not make a service call; it only creates a local object.
                            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(systemFileName);
                            await cloudBlockBlob.UploadFromByteArrayAsync(dataFiles, 0, dataFiles.Length);


                            ordemservicoVistoria.FotoPath3 = cloudBlockBlob.StorageUri.PrimaryUri.OriginalString;
                        }

                        // Foto 04
                        if (files_Fotopath3 == null)
                        {
                            ordemservicoVistoria.FotoPath4 = null;
                        }
                        else
                        {
                            string systemFileName = files_Fotopath3.FileName;
                            await cloudBlobContainer.SetPermissionsAsync(permissions);
                            await using (var target = new MemoryStream())
                            {
                                files_Fotopath3.CopyTo(target);
                                dataFiles = target.ToArray();
                            }
                            // This also does not make a service call; it only creates a local object.
                            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(systemFileName);
                            await cloudBlockBlob.UploadFromByteArrayAsync(dataFiles, 0, dataFiles.Length);


                            ordemservicoVistoria.FotoPath4 = cloudBlockBlob.StorageUri.PrimaryUri.OriginalString;
                        }
                    }
                    ordemservicoVistoria.tipoVistoria = "Alto Consumo-Troca";
                    _context.Update(ordemservicoVistoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdemservicoVistoriaExists(ordemservicoVistoria.OrdemservicoVistoriaId))
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
            return View(ordemservicoVistoria);
        }
        //POST EDIT  VISOTRIA GERAL 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVistoriaGeral(int id, [Bind("OrdemVistoriaGeralId,dt_solicitacao,dt_execucao,dt_agendada,condominioNovo,endereco,bairro,emailCliente,FotoPath,observacao,IdAspNetUsers,assinaturaCliente,condominioId,bloco, unidade, documento,nomeCliente,tipoVistoria,valor,formaPagamento,pago,status")] OrdemVistoriaGeral ordemVistoriaGeral, IFormFile files_Fotopath)
        {
            ordemVistoriaGeral.OrdemVistoriaGeralId = id;
            if (id != ordemVistoriaGeral.OrdemVistoriaGeralId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
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
                    if (ModelState.IsValid)
                    {
                        ordemVistoriaGeral.IdAspNetUsers = User.Identity.Name;
                        // Foto 01 
                        if (files_Fotopath == null)
                        {
                            ordemVistoriaGeral.FotoPath01 = null;
                        }
                        else
                        {
                            string systemFileName = files_Fotopath.FileName;
                            await cloudBlobContainer.SetPermissionsAsync(permissions);
                            await using (var target = new MemoryStream())
                            {
                                files_Fotopath.CopyTo(target);
                                dataFiles = target.ToArray();
                            }
                            // This also does not make a service call; it only creates a local object.
                            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(systemFileName);
                            await cloudBlockBlob.UploadFromByteArrayAsync(dataFiles, 0, dataFiles.Length);


                            ordemVistoriaGeral.FotoPath01 = cloudBlockBlob.StorageUri.PrimaryUri.OriginalString;
                        }
                      
                    }
                    ordemVistoriaGeral.tipoVistoria = "Vistoria Geral";
                    _context.Update(ordemVistoriaGeral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdemservicoVistoriaExists(ordemVistoriaGeral.OrdemVistoriaGeralId))
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
            return View(ordemVistoriaGeral);
        }

        // GET: OrdemservicoVistorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemservicoVistoria = await _context.OrdemservicoVistorias
                .FirstOrDefaultAsync(m => m.OrdemservicoVistoriaId == id);
            if (ordemservicoVistoria == null)
            {
                return NotFound();
            }

            return View(ordemservicoVistoria);
        }

        // POST: OrdemservicoVistorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordemservicoVistoria = await _context.OrdemservicoVistorias.FindAsync(id);
            _context.OrdemservicoVistorias.Remove(ordemservicoVistoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdemservicoVistoriaExists(int id)
        {
            return _context.OrdemservicoVistorias.Any(e => e.OrdemservicoVistoriaId == id);
        }
    }
}
