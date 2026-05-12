using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Registros_ColegioSJ.Data;
using Registros_ColegioSJ.Models;

namespace Registros_ColegioSJ.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly ColegioSJContext _context;

        public CalificacionesController(ColegioSJContext context)
        {
            _context = context;
        }

        // NOTAS REGISTRADAS //
        public async Task<IActionResult> Index()
        {
            var notas = await _context.Expedientes
                .Include(e => e.Estudiante)
                .Include(e => e.Asignatura)
                .ToListAsync();
            return View(notas);
        }

        // FORMULARIO REGISTRAR NOTA //
        public IActionResult Registrar()
        {
            ViewBag.Estudiantes = new SelectList(_context.Estudiantes, "EstudianteId", "Nombre");
            ViewBag.Asignaturas = new SelectList(_context.Asignaturas, "AsignaturaId", "NombreAsignatura");
            return View();
        }

        // ALMACENAMIENTO NOTAS //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar([Bind("EstudianteId,AsignaturaId,NotaFinal,Observaciones")] Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expediente);
        }
    }
}