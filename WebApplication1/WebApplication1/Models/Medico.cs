using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    [Table("Medico", Schema = "dbo")]
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public int? Matricula { get; set; }
        public string? Especialidad { get; set; }

        public int? DNI { get; set; }
        public int? TelefonoMedico { get; set; }

        public string? Mail { get; set; }

        [JsonIgnore]
        public ICollection<Observacion> Observaciones { get; set; } = new List<Observacion>();
    }
}