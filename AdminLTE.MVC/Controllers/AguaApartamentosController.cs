using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections;

namespace AdminLTE.MVC.Controllers
{
    public class AguaApartamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserManager<IdentityUser> _userManager { get; }

        public AguaApartamentosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        // GET: AguaApartamentos
        public ActionResult Index()
        {
            if ((User.IsInRole("Member")) || (User.IsInRole("Provisorio")))
            {
                //CONVIDADOOO
                if (User.Identity.Name == "convidado.martin@acquaxcontrol.com.br" || User.Identity.Name == "maboe@me.com")
                {
                   
                    var hidroAutomatico = _context.hidroAutoSigfox.Where(u => u.email == "maboe@me.com");
                    var teste = hidroAutomatico.Take(4).OrderByDescending(dt => dt.HidroAutoSigfoxId);
                    if (teste.Count() == 4)
                    {
                        CultureInfo.CurrentCulture = new CultureInfo("pt-BR", false);
                        //data dos device
                        var data493409 = new List<string>();
                        var data494538 = new List<string>();
                        var data435565 = new List<string>();
                        var data439AA7 = new List<string>();
                        //consumo dos device
                        var consumo493409 = new int();
                        var consumo494538 = new int();
                        var consumo435565 = new int();
                        var consumo439AA7 = new int();
                        //total hidrometro
                        var total_493409 = new double();
                        var total_494538 = new double();
                        var total_435565 = new double();
                        var total_439AA7 = new double();

                        //numero hidrometro 
                        var Hidrometro493409 = new List<int>();
                        var Hidrometro494538 = new List<int>();
                        var Hidrometro435565 = new List<int>();
                        var Hidrometro439AA7 = new List<int>();

                      

                        var hidroAutomaticoGrafico = _context.hidroAutoSigfox.Where(u => u.email == "maboe@me.com");
                        var testeGrafico = hidroAutomaticoGrafico.Take(4).OrderByDescending(dt => dt.HidroAutoSigfoxId);

                        var NumeroHidrometro = _context.hidrometro.OrderByDescending(d => d.HidrometroId);
                        foreach (var item in testeGrafico)
                        {
                            if (item.device == "493409")
                            {
                                data493409.Add(item.data.ToString("HH:mm"));
                                consumo493409 =item.counter01;
                            }
                            if (item.device == "494538")
                            {
                                data494538.Add(item.data.ToString("HH:mm"));
                                consumo494538 = item.counter01;
                            }
                            if (item.device == "435565")
                            {
                                data435565.Add(item.data.ToString("HH:mm"));
                                consumo435565 = item.counter01;
                            }
                            if (item.device == "439AA7")
                            {
                                data439AA7.Add(item.data.ToString("HH:mm"));
                                consumo439AA7 = item.counter01;
                            }
                        }
                        
                        foreach (var item in NumeroHidrometro)
                        {
                            if (item.Device == "493409")
                            {
                                var Num_hidro493409 = item.NumeroHidrometro;
                                
                                 total_493409 = Num_hidro493409 + (consumo493409 * 0.001);
                            }
                            if (item.Device == "494538")
                            {
                                var Num_hidro494538 = item.NumeroHidrometro;
                                 total_494538 = Num_hidro494538 + (consumo494538 * 0.001) + 65.120 + 65.503;
                            }
                            if (item.Device == "435565")
                            {
                                var Num_hidro435565 = item.NumeroHidrometro;
                                total_435565 = Num_hidro435565 + (consumo435565 * 0.001);
                            }
                            if (item.Device == "439AA7")
                            {
                                var Num_hidro439AA7 = item.NumeroHidrometro;
                                total_439AA7 = Num_hidro439AA7 + (consumo439AA7 * 0.001);
                            }
                        }
                        
                        //numeração hidrometro
                        ViewBag.total_493409 = total_493409;
                        ViewBag.total_494538 = total_494538;
                        ViewBag.total_435565 = total_435565;
                        ViewBag.total_439AA7 = total_439AA7;



                        ViewBag.data493409 = data493409;
                        ViewBag.consumo493409 = consumo493409;
                        ViewBag.data494538 = data494538;
                        ViewBag.consumo494538 = consumo494538;
                        ViewBag.data435565 = data435565;
                        ViewBag.consumo494538 = consumo494538;
                        return View("HidroAutomatico", teste);
                    }
                }else {
                    var ListFiltra = _context.apartamentos.Where(l => l.IdAspNetUsers == User.Identity.Name).Include(a => a.Blocos).ThenInclude(d => d.Condominio).FirstOrDefault();
                    if (ListFiltra == null)
                    {
                        var semapartamento = User.Identity.Name;
                        return View("SemConta", semapartamento);
                    }
                    return View(ListFiltra);
                }
                
            }

            if (User.IsInRole("Sindico"))
            {
                var login = User.Identity.Name;
                var TotalUnidade = new List<Double>();
                var dataCondominio = new List<DateTime>();
                var vol_condominio = new List<Double>();
                var teste = (from c in _context.condominios
                             join b in _context.blocos on c.CondominioId equals b.CondominioId
                             join a in _context.apartamentos on b.BlocosId equals a.BlocosId
                             join ap in _context.aguaApartamentos on a.ApartamentoId equals ap.ApartamentoId

                             where c.Sindico == login
                             orderby ap.dt_leitura_atual
                             select ap).ToList();
                //string nomeCondominio = _context.apartamentos.Where(d => d.ApartamentoId == id).Include(b => b.Blocos).ThenInclude(c => c.Condominio).FirstOrDefault().Blocos.Condominio.Nome;
                foreach (var item in teste.OrderBy(d=> d.dt_leitura_atual))
                {
                    TotalUnidade.Add(item.total_unidade_condominio);
                    dataCondominio.Add(item.dt_leitura_atual.Date);
                    vol_condominio.Add(item.total_unidade_condominio);
                }

                ViewBag.data = dataCondominio.Distinct();
                ViewBag.TotalCondominio = TotalUnidade.Distinct();
                ViewBag.vol_condominio = vol_condominio.Distinct();
                return View("ApartamentoCondominio",teste.OrderByDescending(dt => dt.dt_leitura_atual));
            }
            if (User.IsInRole("Admin"))
            {
               
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            if (User.IsInRole("Engenharia"))
            {
                return RedirectToAction("Index", "OrdemservicoVistorias");
            }
            var ListFiltra1 = _context.apartamentos.Where(l => l.IdAspNetUsers == User.Identity.Name).Include(a => a.Blocos).ThenInclude(d => d.Condominio).FirstOrDefault();
            return View(ListFiltra1);
        }

        public IActionResult ApartamentoPessoa()
        {
            


            var ListFiltra = _context.apartamentos.Where(l => l.IdAspNetUsers == User.Identity.Name).Include(a => a.Blocos).ThenInclude(d => d.Condominio);
            //var ListFiltra = _context.apartamentos.Where(l => l.IdAspNetUsers == User.Identity.Name);

            


            return View(ListFiltra);
        }
        public IActionResult CondominioIndex()
        {



            var condominiosIndex = _context.condominios.Where(l => l.Sindico == User.Identity.Name).Include(p => p.Apartamentos);
            //var ListFiltra = _context.apartamentos.Where(l => l.IdAspNetUsers == User.Identity.Name);




            return View(condominiosIndex);
        }
        public IActionResult ApartamentoCondominio() //FILTRA TODOS 
        {
            //var ListFiltra = _context.aguaApartamentos.Where(a => a.)
            // var ListFiltra = _context.aguaApartamentos.Include(a => a.Apartamento).ThenInclude(b => b.Blocos).ThenInclude(c => c.Condominio.Sindico == User.Identity.Name);
            //IEnumerable<AguaApartamento>  condominioList = _context.Database.ExecuteSqlCommand("select * from condominio c, Bloco b, Apartamento a, AguaApartamento d where sindico = 'acquax@gmail.com' and c.CondominioId = b.CondominioId and b.BlocosId = a.BlocosId and a.ApartamentoId = d.ApartamentoId");
            //var studentName = _context.Database.ExecuteSqlCommand(@"select * from condominio c, Bloco b, Apartamento a, AguaApartamento d where sindico = 'acquax@gmail.com' and c.CondominioId = b.CondominioId and b.BlocosId = a.BlocosId and a.ApartamentoId = d.ApartamentoId");
            //var ListFiltra = _context.apartamentos.Where(l => l.IdAspNetUsers == User.Identity.Name);
            var login = User.Identity.Name;
            var TotalUnidade = new List<Double>();
            var dataCondominio = new List<DateTime>();
            var vol_condominio = new List<Double>();
            var teste = (from c in _context.condominios 
                         join b in _context.blocos on c.CondominioId equals b.CondominioId
                         join a in _context.apartamentos on b.BlocosId equals a.BlocosId
                         join ap in _context.aguaApartamentos on a.ApartamentoId equals ap.ApartamentoId
                         
                         where c.Sindico ==login orderby ap.dt_leitura_atual
                         select ap).ToList();
            //string nomeCondominio = _context.apartamentos.Where(d => d.ApartamentoId == id).Include(b => b.Blocos).ThenInclude(c => c.Condominio).FirstOrDefault().Blocos.Condominio.Nome;
            foreach (var item in teste)
            {
                TotalUnidade.Add(item.total_unidade_condominio);
                dataCondominio.Add(item.dt_leitura_atual.Date);
                vol_condominio.Add(item.total_unidade_condominio);              
            }

            ViewBag.data = dataCondominio.Distinct();
            ViewBag.TotalCondominio = TotalUnidade.Distinct();
            ViewBag.vol_condominio = vol_condominio.Distinct();
            //ViewBag.nome = nomeCondominio;
            return View(teste.OrderByDescending(dt => dt.dt_leitura_atual));
        }

        // GET: AguaApartamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aguaApartamento = await _context.aguaApartamentos
                .Include(a => a.Apartamento)
                .FirstOrDefaultAsync(m => m.ApartamentoId == id);
            if (aguaApartamento == null)
            {
                return NotFound();
            }

            return View(aguaApartamento);
        }

        // GET: AguaApartamentos/Create
        public IActionResult Create()
        {
            ViewData["ApartamentoId"] = new SelectList(_context.apartamentos, "ApartamentoId", "Nome");
            return View();
        }

        // POST: AguaApartamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AguaApartamentoId,dt_leitura_atual,dt_leitura_anterior,dt_leitura_proxima,bloco,Unidade,mes_anterior,mes_atual,volume_consumido,vlr_agua,vlr_esgoto,area_comum,total_unidade,FotoPath,ApartamentoId")] AguaApartamento aguaApartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aguaApartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApartamentoId"] = new SelectList(_context.apartamentos, "ApartamentoId", "Nome", aguaApartamento.ApartamentoId);
            
            return View(aguaApartamento);
        }

        // GET: AguaApartamentos/Edit/5
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

        // POST: AguaApartamentos/Edit/5
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

        // GET: AguaApartamentos/Delete/5
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

        // POST: AguaApartamentos/Delete/5
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
        public IActionResult filtro(int?id)
            
        {
            var dataConsumo = new List<string>();
            var valorConsumo = new List<Double>();
            
            var ListFiltra = _context.aguaApartamentos.Where(l => l.ApartamentoId == id).Include(a => a.Apartamento);
            string nomeCondominio = _context.apartamentos.Where(d => d.ApartamentoId == id).Include(b => b.Blocos).ThenInclude(c => c.Condominio).FirstOrDefault().Blocos.Condominio.Nome;
          
            foreach (var item in ListFiltra)
            {
                if (item.dt_leitura_anterior == null){
                   
                    valorConsumo.Add(item.volume_consumido);
                }
                else
                {
                    dataConsumo.Add(item.dt_leitura_atual.ToString("dd-MM-yy"));
                    valorConsumo.Add(item.volume_consumido);
                }
                
                
            }
            //var block = _context.aguaApartamentos.Where(l => l.ApartamentoId == id);


            ViewBag.Data = dataConsumo;
            ViewBag.valor = valorConsumo;
            ViewBag.nome = nomeCondominio;
            TempData["nomeCond"] = nomeCondominio;

            return View(ListFiltra.OrderByDescending(dt => dt.dt_leitura_atual));
        }
        public async Task<IActionResult> filtroDetails(int ? id, double ? volume, double ? valorConta)
        {
            var s = await _context.aguaApartamentos.Where(v => v.total_unidade_condominio == volume).ToListAsync();
           
            double totalVolume = 0;
          foreach (var item in s)
            {
                totalVolume = totalVolume+ item.volume_consumido;
            }
            
            var block = await  _context.aguaApartamentos.Include(a => a.Apartamento).FirstOrDefaultAsync(m => m.AguaApartamentoId == id);
            
            var totalAC = block.total_unidade_condominio - totalVolume;
            var totalAC_cond = block.total_unidade_condominio;
            ViewBag.TotalAC = totalAC;
            ViewBag.TotalVolConsumido = totalVolume;
            ViewBag.totalAC_cond = totalAC_cond;
            ViewBag.nomeCondominio = TempData["nomeCond"];
            return View(block);
        }
    }
}
