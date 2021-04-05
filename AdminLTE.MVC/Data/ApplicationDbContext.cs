using System;
using System.Collections.Generic;
using System.Text;
using AdminLTE.MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminLTE.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Condominio> condominios { get; set; }
        public DbSet<AguaCondominio> aguaCondominios { get; set; }
        public DbSet<Apartamento> apartamentos { get; set; }
        public DbSet<AguaApartamento> aguaApartamentos { get; set; }
        public DbSet<HidroAutoSigfox> hidroAutoSigfox { get; set; }
        public DbSet<Blocos> blocos { get; set; }
        public DbSet<Hidrometro> hidrometro { get; set; }

        public DbSet<OrdemservicoVistoria> OrdemservicoVistorias { get; set; }

        public DbSet<OrdemVistoriaGeral> OrdemServicoGeral { get; set; }
    }
}
