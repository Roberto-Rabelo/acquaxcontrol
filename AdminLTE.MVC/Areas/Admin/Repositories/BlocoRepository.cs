using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Areas.Admin.Repositories
{
    public class BlocoRepository : IBloco
    {
        private readonly ApplicationDbContext _context;

        //referencia contextto para ter acesso ao banco de dados 
        public BlocoRepository(ApplicationDbContext contexto)
        {
            _context = contexto; 
        }
        public IEnumerable<Blocos> blocos => _context.blocos;

      
    }
}
