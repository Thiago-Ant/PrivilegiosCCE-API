using Microsoft.EntityFrameworkCore;
using PrivilegiosAPI.Models;

namespace PrivilegiosAPI.Data
{
    public class PrivilegiosContext : DbContext
    {
        public PrivilegiosContext(DbContextOptions<PrivilegiosContext> options) : base(options)
        {

        }

        public DbSet<Miembro> Miembros => Set<Miembro>();
        public DbSet<Privilegio> Privilegios => Set<Privilegio>();
        public DbSet<Participacion> Participaciones => Set<Participacion>();
    }
}
