using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Principal;

namespace BlazorAppCuentasBancarias.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options)
        : base(options)
        {
        }

        public DbSet<CuentaBancaria> CuentasBancarias { get; set; }
    }
}
