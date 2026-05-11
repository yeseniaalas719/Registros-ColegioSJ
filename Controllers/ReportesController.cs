using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registros_ColegioSJ.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Registros_ColegioSJ.Controllers
{
    public class ReportesController : Controller
    {
        private readonly ColegioSJContext _context;

        public ReportesController(ColegioSJContext context)
        {
            _context = context;
        }

        // NOMBRE Y PROMEDIO //
        public async Task<IActionResult> PromediosEstudiantes()
        {
            //CONEXIÓN CON LINQ//
            var promedios = await _context.Estudiantes
                .AsNoTracking()
                .Select(e => new
                {
                    Estudiante = e.Nombre + " " + e.Apellido,
                    Promedio = e.Expedientes.Any() ? e.Expedientes.Average(exp => exp.NotaFinal) : 0
                })
                .ToListAsync();

            return View(promedios);
        }
    }
}