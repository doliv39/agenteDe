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
    public class promocaoController : Controller
    {
        private readonly agenciaContext _context;

        public promocaoController(agenciaContext context)
        {
            _context = context;
        }

        // GET: promocao
        public async Task<IActionResult> Index()
        {
            return View(await _context.promocaos.ToListAsync());
        }

        // GET: promocao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = await _context.promocaos
                .FirstOrDefaultAsync(m => m.preco == id);
            if (promocao == null)
            {
                return NotFound();
            }

            return View(promocao);
        }

        // GET: promocao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: promocao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("preco,origem,dataOrigem,retorno,dataRetorno")] promocao promocao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promocao);
        }

        // GET: promocao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = await _context.promocaos.FindAsync(id);
            if (promocao == null)
            {
                return NotFound();
            }
            return View(promocao);
        }

        // POST: promocao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("preco,origem,dataOrigem,retorno,dataRetorno")] promocao promocao)
        {
            if (id != promocao.preco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promocao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!promocaoExists(promocao.preco))
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
            return View(promocao);
        }

        // GET: promocao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = await _context.promocaos
                .FirstOrDefaultAsync(m => m.preco == id);
            if (promocao == null)
            {
                return NotFound();
            }

            return View(promocao);
        }

        // POST: promocao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocao = await _context.promocaos.FindAsync(id);
            _context.promocaos.Remove(promocao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool promocaoExists(int id)
        {
            return _context.promocaos.Any(e => e.preco == id);
        }
    }
}
