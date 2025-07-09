namespace PrivilegiosAPI.Models
{
    public class Privilegio
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;

        public ICollection<Participacion> Participaciones { get; set; } = new List<Participacion>();
    }
}
