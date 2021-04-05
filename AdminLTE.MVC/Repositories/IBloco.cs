using AdminLTE.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Repositories
{
    public interface IBloco
    {
        IEnumerable<Blocos> blocos { get; }

       

    }
}
