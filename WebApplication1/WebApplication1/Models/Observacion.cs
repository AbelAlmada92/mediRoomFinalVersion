using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Observaciones")]
    public class Observacion
    {
        [Key]
        public int IdObservacion { get; set; }

        public int IdPaciente { get; set; }

        [Required]
        public string TextoObservacion { get; set; } = string.Empty;

        public DateTime FechaObservacion { get; set; }

        public int IdMedico { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }
    }
}