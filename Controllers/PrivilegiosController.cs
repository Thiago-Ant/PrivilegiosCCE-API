using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrivilegiosAPI.Data;

namespace PrivilegiosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrivilegiosController : ControllerBase
    {
        private readonly PrivilegiosContext _context;

        public PrivilegiosController(PrivilegiosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrivilegios(string nombre, string apellido)
        {
            var miembro = await _context.Miembros
                .Include(m => m.Participaciones)
                    .ThenInclude(p => p.Privilegio)
                .FirstOrDefaultAsync(m =>
                    m.Nombre.ToLower() == nombre.ToLower() &&
                    m.Apellido.ToLower() == apellido.ToLower());

            if (miembro == null)
            {
                return NotFound("Miembro no encontrado.");
            }

            var hoy = DateTime.Today;
            var inicioMes = new DateTime(hoy.Year, hoy.Month, 1);
            var finMes = inicioMes.AddMonths(1).AddDays(-1);

            var resultado = miembro.Participaciones
                .Where(p => p.Fecha >= inicioMes && p.Fecha <= finMes)
                .Select(p => new
                {
                    Fecha = p.Fecha.ToString("dd/MM/yyyy"),
                    Privilegio = p.Privilegio.Descripcion,
                    Estado = p.Fecha < hoy ? "Pasado" : "Próximo"
                })
                .OrderBy(p => p.Fecha)
                .ToList();

            return Ok(resultado);
        }
    }
}
