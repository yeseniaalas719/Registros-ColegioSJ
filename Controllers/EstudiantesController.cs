using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registros_ColegioSJ.Data;
using Registros_ColegioSJ.Models;

namespace Registros_ColegioSJ.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly ColegioSJContext _context;

        public EstudiantesController(ColegioSJContext context)
        {
            _context = context;
        }

        // LISTADO DE ESTUDIANTES //
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudiantes.ToListAsync());
        }

        // CREAR NUEVO ESTUDIANTE //
        public IActionResult Crear()
        {
            return View();
        }

        // CREAR //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Nombre,Apellido,FechaNacimiento,Grado")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        // EDITAR ESTUDIANTE //
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null) return NotFound();
            return View(estudiante);
        }

        // EDITAR - ACTUALIZAR //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("EstudianteId,Nombre,Apellido,FechaNacimiento,Grado")] Estudiante estudiante)
        {
            if (id != estudiante.EstudianteId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        //ELIMINAR ESTUDIANTE//
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null) return NotFound();
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}