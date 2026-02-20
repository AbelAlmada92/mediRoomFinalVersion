namespace Api_Login.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null;

        public string Apellido { get; set; } = null;

        public int DNI { get; set; }

        public string? URLfotoPerfil { get; set; }

        public int Telefono { get; set; }

        public string Correo { get; set; }

        public string Clave { get; set; }

    }
}
