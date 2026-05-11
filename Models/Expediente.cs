using System.ComponentModel.DataAnnotations;

namespace Registros_ColegioSJ.Models
{
    public class Expediente
    {
        [Key]
        public int ExpedienteId { get; set; }

        [Required]
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }

        [Required]
        public int AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }

        public decimal NotaFinal { get; set; }
        public string Observaciones { get; set; }
    }
}