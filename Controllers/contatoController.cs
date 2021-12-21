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
    public class contatoController : Controller
    {
        private readonly agenciaContext _context;

        public contatoController(agenciaContext context)
        {
            _context = context;
        }

        // GET: contato
        public async Task<IActionResult> Index()
        {
            return View(await _context.contatos.ToListAsync());
        }

        // GET: contato/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.contatos
                .FirstOrDefaultAsync(m => m.area == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // GET: contato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: contato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("area,telefone")] contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        // GET: contato/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.contatos.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        // POST: contato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("area,telefone")] contato contato)
        {
            if (id != contato.area)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!contatoExists(contato.area))
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
            return View(contato);
        }

        // GET: contato/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.contatos
                .FirstOrDefaultAsync(m => m.area == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // POST: contato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var contato = await _context.contatos.FindAsync(id);
            _context.contatos.Remove(contato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool contatoExists(string id)
        {
            return _context.contatos.Any(e => e.area == id);
        }
    }
}
