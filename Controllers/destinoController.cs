using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agencia.Models;
using Agencia.data;

namespace Agencia.Controllers
{
    public class destinoController : Controller
    {
        private readonly agenciaContext _context;

        public destinoController(agenciaContext context)
        {
            _context = context;
        }

        // GET: destino
        public async Task<IActionResult> Index()
        {
            return View(await _context.destinos.ToListAsync());
        }

        // GET: destino/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.destinos
                .FirstOrDefaultAsync(m => m.id == id);
            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }

        // GET: destino/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: destino/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,sobrenome,origem,dataOrigem,retorno,dataRetorno")] destino destino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destino);
        }

        // GET: destino/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.destinos.FindAsync(id);
            if (destino == null)
            {
                return NotFound();
            }
            return View(destino);
        }

        // POST: destino/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,sobrenome,origem,dataOrigem,retorno,dataRetorno")] destino destino)
        {
            if (id != destino.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!destinoExists(destino.id))
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
            return View(destino);
        }

        // GET: destino/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.destinos
                .FirstOrDefaultAsync(m => m.id == id);
            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }

        // POST: destino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destino = await _context.destinos.FindAsync(id);
            _context.destinos.Remove(destino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool destinoExists(int id)
        {
            return _context.destinos.Any(e => e.id == id);
        }
    }
}
