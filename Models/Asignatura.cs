using Registros_ColegioSJ.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registros_ColegioSJ.Models
{
    public class Asignatura
    {
        [Key]
        public int AsignaturaId { get; set; }

        [Required]
        public string NombreAsignatura { get; set; }

        public string Docente { get; set; }

        // RELACION DE ASIGNATURA CON EXPEDIENTES //
        public ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
    }
}