using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SQLitePCL;
using static AdminLTE.MVC.Areas.Identity.Pages.Account.RegisterModel;

namespace AdminLTE.MVC.Controllers
{

    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    
    public class ValuesController : ControllerBase
    {
        public static List<string> data = new List<string>();
        private readonly ApplicationDbContext _context;

        public UserManager<IdentityUser> _userManager { get; }

        private readonly SignInManager<IdentityUser> _signInManager;

        public ValuesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET: ValuesControllers
        [HttpGet]
        public IEnumerable<Condominio> Get()
        {
            GetPokemon();
            return _context.condominios.ToList();
           
          
        }
        [HttpGet]
        [Route("pokemon")]
        public static async void GetPokemon()
        {


            string baseUrl = "https://digimon-api.vercel.app/api/digimon";
            try
            {
                using HttpClient client = new HttpClient();
                using HttpResponseMessage res = await client.GetAsync(baseUrl);
                using HttpContent content = res.Content;

                var data = await content.ReadAsStringAsync();
                
                if (content != null)
                {
                    //Now log your data object in the console
                    Console.WriteLine("data------------{0}", JObject.Parse(data)["results"]);
                }
                else
                {
                    Console.WriteLine("NO Data----------");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return ;

        }


        // POST: ValuesControllers/Create
        [HttpPost]
        [Route("")]
        [Consumes("application/json")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<HidroAutoSigfox>> Post([FromServices] ApplicationDbContext context
            , [FromBody]HidroAutoSigfox model)

        {
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR", false);
            if (ModelState.IsValid)
            {
                if(model.device == "493409")
                {
                    model.nome = "SPA";
                }
               
                if(model.device == "494538")
                {
                    model.nome = "Abastecimento Geral";
                }
                if (model.device == "435565")
                {
                    model.nome = "Piscina";
                }
                if(model.device == "439AA7")
                {
                    model.nome = "HC - Ana";
                }
                model.email = "maboe@me.com";
                model.emailConvidado = "convidado.martin@acquaxcontrol.com.br";
                DateTime dataAtual = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
                model.data = dataAtual;
                context.hidroAutoSigfox.Add(model);
                await context.SaveChangesAsync();
                return null;
            }
            else
            {
                return BadRequest(ModelState);
            }          
            
           
            
        }

        [HttpPost]
        [Route("register")]
        [Consumes("application/json")]
        public async Task<ActionResult> RegisterLotsOfPeople([FromBody]List<InputModel> model)
        {
            var successful = new List<string>();
            var failed = new List<string>();
            foreach (var toRegister in model)
            {
                DateTime dataAtual = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
                var user = new IdentityUser { UserName = toRegister.Email, Email = toRegister.Email, PhoneNumber = toRegister.Categoria, LockoutEnd = dataAtual };
                var result = await _userManager.CreateAsync(user, toRegister.Password);
                
            }

            return Ok();
           
        }


    }
}
