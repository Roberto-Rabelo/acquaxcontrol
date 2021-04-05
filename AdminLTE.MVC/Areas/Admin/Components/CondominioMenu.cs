using AdminLTE.MVC.Areas.Admin.Repositories;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Areas.Admin.Components
{
    public class CondominioMenu : ViewComponent
    {
        private readonly CondominioRepository _condomnio;

        public CondominioMenu(CondominioRepository condominio)
        {
            _condomnio = condominio;
        }

        public IViewComponentResult Invoke()
        {
            var nomeCondominio = _condomnio.condominios.OrderBy(c => c.Nome);

                return View(nomeCondominio);
        }

    }
}
