using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;

namespace AdminLTE.MVC.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class RegisterLotsModel
        {
            public List<InputModel> IdentityUser { get; set; }
        }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "As senhas não correspondem.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Categoria")]
            public string Categoria { get; set; }

            //[Required]
            public DateTime data { get; set; }

        }
        public class InputAlterarSenha
        {
            public string Password { get; set; }
            public string PasswordConfirm { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                DateTime dataAtual = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email, PhoneNumber = Input.Categoria, LockoutEnd = dataAtual};
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    var senha = Input.Password;
                    var _categ = Input.Categoria;
                    
                    
                    await _userManager.AddToRoleAsync(user, _categ);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    _logger.LogInformation(" Usuário Criado com sucesso!");



                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    //configuração do servidor SMTP
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "mail.acquaxdobrasil.com.br ";
                    smtp.UseDefaultCredentials = true;
                    smtp.EnableSsl = true;
                    //smtp.Port = 587;
                    smtp.Port = 587;
                    //sem ssl = 587
                    //com ssl = 465

                    string email = "suporte@acquaxdobrasil.com.br";
                    string senhaEmail = "acquaxdobrasil@suporte";
                    smtp.Credentials = new System.Net.NetworkCredential(email, senhaEmail);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    
                    MailMessage correio = new MailMessage();
                    correio.From = new MailAddress("suporte@acquaxdobrasil.com.br");
                    correio.To.Add(user.Email);


                    WebClient wc = new WebClient();
                    wc.Encoding = System.Text.Encoding.UTF8;
                    

                    string sTemplate = wc.DownloadString(
    "https://cs210032000caae87de.blob.core.windows.net/image/Template_cadastro_usuario.html");

                    sTemplate = sTemplate.Replace("##Login##", user.Email);
                    sTemplate = sTemplate.Replace("##Senha##", senha);
                    correio.Subject = "Login e Senha - Sistema ACQUAX ";
                    correio.Body = sTemplate;

                    correio.IsBodyHtml = true;


                    correio.Priority = MailPriority.Normal;
                   



                    smtp.Send(correio);


                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect("~/Identity/Account/Register");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
     
    }
}
