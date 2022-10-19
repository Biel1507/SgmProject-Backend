using Microsoft.EntityFrameworkCore;
using SgmProject.Models;

namespace SgmProject.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions options): base(options)
        {
        }
        public DbSet<Moto> Motos { get; set; }
    }
}
