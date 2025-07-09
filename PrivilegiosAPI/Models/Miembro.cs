namespace PrivilegiosAPI.Models
{
    public class Miembro
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;

        public ICollection<Participacion> Participaciones { get; set; } = new List<Participacion>();
    }
}
