using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
        public string TelefonoMedico { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
    }
}