using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cadastro.Models;

    public class CadastoContext : DbContext
    {
        public CadastoContext (DbContextOptions<CadastoContext> options)
            : base(options)
        {
        }

        public DbSet<Cadastrado> Cadastrado { get; set; }
    }
