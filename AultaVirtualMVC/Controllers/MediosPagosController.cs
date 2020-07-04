using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AulaVirtualMVC.Context;
using AulaVirtualMVC.Models;

namespace AulaVirtualMVC.Controllers
{
    public class MediosPagosController : Controller
    {
        private readonly ProyectoFinalDBContext _context;

        public MediosPagosController(ProyectoFinalDBContext context)
        {
            _context = context;
        }

        // GET: MediosPagos
        public async Task<IActionResult> Index()
        {
            return View(await _context.MediosPagos.ToListAsync());
        }

        // GET: MediosPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medioPago = await _context.MediosPagos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (medioPago == null)
            {
                return NotFound();
            }

            return View(medioPago);
        }

        // GET: MediosPagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MediosPagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,MedioPagoId")] MedioPago medioPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medioPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medioPago);
        }

        // GET: MediosPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medioPago = await _context.MediosPagos.FindAsync(id);
            if (medioPago == null)
            {
                return NotFound();
            }
            return View(medioPago);
        }

        // POST: MediosPagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nombre,MedioPagoId")] MedioPago medioPago)
        {
            if (id != medioPago.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medioPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedioPagoExists(medioPago.ID))
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
            return View(medioPago);
        }

        // GET: MediosPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medioPago = await _context.MediosPagos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (medioPago == null)
            {
                return NotFound();
            }

            return View(medioPago);
        }

        // POST: MediosPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medioPago = await _context.MediosPagos.FindAsync(id);
            _context.MediosPagos.Remove(medioPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedioPagoExists(int id)
        {
            return _context.MediosPagos.Any(e => e.ID == id);
        }
    }
}
