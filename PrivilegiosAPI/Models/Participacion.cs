namespace PrivilegiosAPI.Models
{
    public class Participacion
    {
        public int Id { get; set; }
        public int MiembroId { get; set; }
        public Miembro Miembro { get; set; } = null!;

        public int PrivilegioId { get; set; }
        public Privilegio Privilegio { get; set; } = null!;

        public DateTime Fecha { get; set; }
    }
}