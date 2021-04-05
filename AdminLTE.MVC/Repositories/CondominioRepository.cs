using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Repositories
{
    public class CondominioRepository : ICondominio
    {
        private readonly ApplicationDbContext _context;

        //referencia contextto para ter acesso ao banco de dados 
        public CondominioRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        // retornando condominios + blocos duas tabelas 
        public IEnumerable<Condominio> condominios => _context.condominios.Include(c => c.Bloco); 

        public Condominio GetBlocosById(int CondominioId)
        {
            return _context.condominios.FirstOrDefault(c => c.CondominioId == CondominioId);
        }
    }
}
