using AdminLTE.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Areas.Admin.Repositories
{
    public interface ICondominio
    {
        IEnumerable<Condominio> condominios { get; }

        Condominio GetBlocosById(int CondominioId);
    }
}
