using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    [Table("Paciente", Schema = "dbo")]
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }

        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public int DNI { get; set; }
        public int NLegajo { get; set; }

        public string? ObraSocial { get; set; }

        public string SexoBio { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public string GrupoSanguineo { get; set; } = string.Empty;
        public string MedicacionPrescripta { get; set; } = string.Empty;
        public string Domicilio { get; set; } = string.Empty;

        public int? TelefonoPaciente { get; set; }
        //nav
        [JsonIgnore]
        public ICollection<Observacion> Observaciones { get; set; } = new List<Observacion>();
    }
}