using Registros_ColegioSJ.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ColegioSJ.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public string Grado { get; set; }

        // RELACIÓN DE ESTUDIANTE CON EXPEDIENTES //
        public ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
    }
}
