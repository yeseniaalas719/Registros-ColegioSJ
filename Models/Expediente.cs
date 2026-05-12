using System.ComponentModel.DataAnnotations;

namespace Registros_ColegioSJ.Models
{
    public class Expediente
    {
        public int ExpedienteId { get; set; }

        public int EstudianteId { get; set; }
        public Estudiante? Estudiante { get; set; }

        public int AsignaturaId { get; set; }
        public Asignatura? Asignatura { get; set; }

        // VALIDACION //
        [Required(ErrorMessage = "La nota final es obligatoria.")]
        [Range(0, 10, ErrorMessage = "La nota debe estar entre 0.0 y 10.0.")]
        public decimal NotaFinal { get; set; }

        public string? Observaciones { get; set; }
    }
}