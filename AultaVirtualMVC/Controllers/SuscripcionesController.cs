using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AulaVirtualMVC.Context;
using AulaVirtualMVC.Models;
using Microsoft.AspNetCore.Http;

namespace AulaVirtualMVC.Controllers
{
    public class SuscripcionesController : Controller
    {
        private readonly ProyectoFinalDBContext _context;

        public SuscripcionesController(ProyectoFinalDBContext context)
        {
            _context = context;
        }

        // GET: Suscripciones
        public async Task<IActionResult> Index()
        {
            var proyectoFinalDBContext = _context.Suscripciones.Include(s => s.Curso).Include(s => s.MedioPago).Include(s => s.Usuario);
            return View(await proyectoFinalDBContext.ToListAsync());
        }
        //Mis Suscripciones
        public async Task<IActionResult> MisSuscripciones()
        {
            String usuario = HttpContext.Session.GetString("usuario"); // Obtengo Session
            var proyectoFinalDBContext = _context.Suscripciones.Where(s => s.UsuarioId.ToString().Equals(usuario)).Include(s => s.Curso).Include(s => s.MedioPago).Include(s => s.Usuario);
            return View(await proyectoFinalDBContext.ToListAsync());
        }
        // GET: Suscripciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suscripcion = await _context.Suscripciones
                .Include(s => s.Curso)
                .Include(s => s.MedioPago)
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.SuscripcionId == id);
            if (suscripcion == null)
            {
                return NotFound();
            }

            return View(suscripcion);
        }

        // GET: Suscripciones/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Cursos, "ID", "Nombre");
            ViewData["MedioPagoId"] = new SelectList(_context.MediosPagos, "ID", "Nombre");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "ID", "Apellido");
            return View();
        }

        // POST: Suscripciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuscripcionId,CursoId,MedioPagoId")] Suscripcion suscripcion)
        {
            suscripcion.UsuarioId = Convert.ToInt32(HttpContext.Session.GetString("usuario"));
            if (ModelState.IsValid)
            {
                suscripcion.ValorPago = _context.Cursos.Find(suscripcion.CursoId).Valor;
                _context.Add(suscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MisSuscripciones));
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "ID", "Nombre", suscripcion.CursoId);
            ViewData["MedioPagoId"] = new SelectList(_context.MediosPagos, "ID", "Nombre", suscripcion.MedioPagoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "ID", "Apellido", suscripcion.UsuarioId);
            return View(suscripcion);
        }

        // GET: Suscripciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suscripcion = await _context.Suscripciones.FindAsync(id);
            if (suscripcion == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "ID", "Nombre", suscripcion.CursoId);
            ViewData["MedioPagoId"] = new SelectList(_context.MediosPagos, "ID", "Nombre", suscripcion.MedioPagoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "ID", "Apellido", suscripcion.UsuarioId);
            return View(suscripcion);
        }

        // POST: Suscripciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ValorPago,SuscripcionId,UsuarioId,CursoId,MedioPagoId")] Suscripcion suscripcion)
        {
            if (id != suscripcion.SuscripcionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suscripcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuscripcionExists(suscripcion.SuscripcionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "ID", "Nombre", suscripcion.CursoId);
            ViewData["MedioPagoId"] = new SelectList(_context.MediosPagos, "ID", "Nombre", suscripcion.MedioPagoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "ID", "Apellido", suscripcion.UsuarioId);
            return View(suscripcion);
        }

        // GET: Suscripciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suscripcion = await _context.Suscripciones
                .Include(s => s.Curso)
                .Include(s => s.MedioPago)
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.SuscripcionId == id);
            if (suscripcion == null)
            {
                return NotFound();
            }

            return View(suscripcion);
        }

        // POST: Suscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suscripcion = await _context.Suscripciones.FindAsync(id);
            _context.Suscripciones.Remove(suscripcion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuscripcionExists(int id)
        {
            return _context.Suscripciones.Any(e => e.SuscripcionId == id);
        }
    }
}
