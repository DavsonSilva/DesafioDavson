namespace DesafioDavson.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
