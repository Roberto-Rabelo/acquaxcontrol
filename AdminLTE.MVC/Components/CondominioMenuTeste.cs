using AdminLTE.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Components
{
    public class CondominioMenuTeste : ViewComponent
    {
        private readonly ICondominio _condomnio;

        public CondominioMenuTeste(ICondominio condominios)
        {
            _condomnio = condominios;
        }

        public IViewComponentResult Invoke()
        {
            var nomeCondominio = _condomnio.condominios.OrderBy(c => c.Nome);

            return View(nomeCondominio);
        }

    }
}
