using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;


namespace AdminLTE.MVC.Controllers
{
    public class HomeController : Controller
    {
        public class InputModel
        {
            [Required]
            [Display(Name = "Senha atual")]
            public string OldPassword { get; set; }
            [Required]
            [Display(Name = "Nova Senha")]
            public string NewPassword { get; set; }

        }
        public class InputRecuperacaoSenha
        {
            
            public string Email { get; set; }
          
        }

        private readonly ILogger<HomeController> _logger;

        public ApplicationDbContext _context { get; }

        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.IsInRole("Member"))
            {
                var ListFiltra = _context.apartamentos.Where(l => l.IdAspNetUsers == User.Identity.Name).Include(a => a.Blocos).ThenInclude(d => d.Condominio);
             
                return View(ListFiltra);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Estados()
        {
            return View();
        }
        public IActionResult agua()
        {
            return View();
        }
        public IActionResult Energia()
        {
            return View();
        }
        public IActionResult Gas()
        {
            return View();
        }
       
        public async Task<IActionResult> AlterarSenha([Bind("OldPassword,NewPassword")] InputModel model)
        {
            //var newPassword = _userManager.PasswordHasher.HashPassword(user, newpass); 
            //user.PasswordHash = newPassword; 
            //var res = await _userManager.UpdateAsync(User);

            // var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var Id = _userManager.GetUserId(User);


                var usuario = _context.Users.Find(Id);
                //IdentityUser u = usuario.Id;
                var result = await _userManager.ChangePasswordAsync(usuario,
                                                                   model.OldPassword,
                                                                   model.NewPassword);

                if (result.Succeeded)
                {

                   return RedirectToAction("Index");
                }
            }


            return View();

        }
        [AllowAnonymous]
        public async Task<IActionResult> RecuperarSenha([Bind("Email")] InputRecuperacaoSenha model)
        {
            //var newPassword = _userManager.PasswordHasher.HashPassword(user, newpass); 
            //user.PasswordHash = newPassword; 
            //var res = await _userManager.UpdateAsync(User);

            // var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
           
            
       
            if (model.Email == null)
            {
                
                ViewBag.Erro = "Ocorreu o erro XPTO";
                return View();
            }
            else
            {
                var emailuser = model.Email;
                IdentityUser user = await _context.Users.FirstOrDefaultAsync(a => a.UserName == emailuser);
                //var usuario = _context.Users.Find(user);
                //IdentityUser u = usuario.Id;
                string novaSenha = "NovaSenha@123";
                 await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user,novaSenha);

                //configuração do servidor SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.acquaxdobrasil.com.br ";
                smtp.Port = 587; //porta sem SSl trocar quando certificado por inserido 
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string email = "suporte@acquaxdobrasil.com.br";
                string senhaEmail = "acquaxdobrasil@suporte";
                smtp.Credentials = new System.Net.NetworkCredential(email, senhaEmail);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage correio = new MailMessage();
                correio.From = new MailAddress("suporte@acquaxdobrasil.com.br");
                correio.To.Add(emailuser);

                correio.Subject = "Recuperação de senha - Sistema ACQUAX ";
                correio.Body = "<h3>Bem-vindo, novamente " + emailuser + "</h3>"  +
                    "<p> Aqui estar sua nova senha para que continue acompanhando suas  medições" + "<br>"+
                    "<strong>Sua nova senha:  </strong>" + novaSenha + " " + "<br>" +
                    "Qualquer problema favor nos contatar!" +
                    "<h5>Obs.: É recomendado alteração da senha</h5>" +
"</p>";

                correio.IsBodyHtml = true;


                correio.Priority = MailPriority.Normal;




                smtp.Send(correio);
                ModelState.AddModelError("", "Sua senha foi resetada e verifique seu email ");
                return View();

            }


          

  

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
