using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EscolaDeIdiomas.Data;
using EscolaDeIdiomas.Domain;

namespace EscolaDeIdiomas.Web.Controllers
{
    public class AlunoTurmaController : Controller
    {
        private readonly EscolaDeIdiomasContext _context;

        public AlunoTurmaController(EscolaDeIdiomasContext context)
        {
            _context = context;
        }

        // GET: AlunoTurma
        public async Task<IActionResult> Index()
        {
            var escolaDeIdiomasContext = _context.AlunoTurmas.Include(a => a.Aluno).Include(a => a.Turma);
            return View(await escolaDeIdiomasContext.ToListAsync());
        }

        // GET: AlunoTurma/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoTurma = await _context.AlunoTurmas
                .Include(a => a.Aluno)
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.AlunoId == id);
            if (alunoTurma == null)
            {
                return NotFound();
            }

            return View(alunoTurma);
        }

        // GET: AlunoTurma/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome");
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Idioma");
            return View();
        }

        // POST: AlunoTurma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlunoId,TurmaId")] AlunoTurma alunoTurma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunoTurma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", alunoTurma.AlunoId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Idioma", alunoTurma.TurmaId);
            return View(alunoTurma);
        }

        // GET: AlunoTurma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoTurma = await _context.AlunoTurmas.FindAsync(id);
            if (alunoTurma == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", alunoTurma.AlunoId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Idioma", alunoTurma.TurmaId);
            return View(alunoTurma);
        }

        // POST: AlunoTurma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("AlunoId,TurmaId")] AlunoTurma alunoTurma)
        {
            if (id != alunoTurma.AlunoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunoTurma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoTurmaExists(alunoTurma.AlunoId))
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
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", alunoTurma.AlunoId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Idioma", alunoTurma.TurmaId);
            return View(alunoTurma);
        }

        // GET: AlunoTurma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoTurma = await _context.AlunoTurmas
                .Include(a => a.Aluno)
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.AlunoId == id);
            if (alunoTurma == null)
            {
                return NotFound();
            }

            return View(alunoTurma);
        }

        // POST: AlunoTurma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var alunoTurma = await _context.AlunoTurmas.FindAsync(id);
            _context.AlunoTurmas.Remove(alunoTurma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoTurmaExists(int? id)
        {
            return _context.AlunoTurmas.Any(e => e.AlunoId == id);
        }
    }
}
