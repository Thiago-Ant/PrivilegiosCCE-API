using Microsoft.EntityFrameworkCore.Storage.Json;
using PrivilegiosAPI.Models;

namespace PrivilegiosAPI.Data
{
    public static class DataSeeder
    {
        public static void Inicializar(PrivilegiosContext context)
        {
            if (context.Miembros.Any()) return;

            var miembros = new List<Miembro>
            {
                new() { Nombre = "Thiago", Apellido = "Antinori",},
                new() { Nombre = "Claudio", Apellido = "Antinori",},
                new() { Nombre = "Delfina", Apellido = "Antinori",}
            };

            context.Miembros.AddRange(miembros);
            context.SaveChanges();

            var privilegios = new List<Privilegio>
            {
                new() { Descripcion = "Coordinación"},
                new() { Descripcion = "Devocional"},
                new() { Descripcion = "Ofrendas"},
                new() { Descripcion = "Anuncios"}
            };

            context.Privilegios.AddRange(privilegios);
            context.SaveChanges();

            var participaciones = new List<Participacion>
            {
                new() { MiembroId = miembros[0].Id, PrivilegioId = privilegios[1].Id, Fecha = Convert.ToDateTime("2025-07-09") },
                new() { MiembroId = miembros[1].Id, PrivilegioId = privilegios[0].Id, Fecha = Convert.ToDateTime("2025-07-26")},
                new() { MiembroId = miembros[2].Id, PrivilegioId = privilegios[0].Id, Fecha = Convert.ToDateTime("2025-07-13")},
            };

            context.Participaciones.AddRange(participaciones);
            context.SaveChanges();
        }
    }
}
