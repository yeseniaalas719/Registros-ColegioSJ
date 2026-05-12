using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registros_ColegioSJ.Data;
using Registros_ColegioSJ.Models;

namespace Registros_ColegioSJ.Controllers
{
    public class AsignaturasController : Controller
    {
        private readonly ColegioSJContext _context;

        public AsignaturasController(ColegioSJContext context)
        {
            _context = context;
        }

        // LISTADO DE ASIGNATURAS //
        public async Task<IActionResult> Index()
        {
            return View(await _context.Asignaturas.ToListAsync());
        }

        // CREAR //
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("NombreAsignatura,Docente")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asignatura);
        }

        // ELIMINAR //
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null) return NotFound();
            var asignatura = await _context.Asignaturas.FindAsync(id);
            if (asignatura != null)
            {
                _context.Asignaturas.Remove(asignatura);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}