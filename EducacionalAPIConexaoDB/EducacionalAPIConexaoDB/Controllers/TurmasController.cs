using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducacionalAPIConexaoDB.Context;
using EducacionalAPIConexaoDB.Models;

namespace EducacionalAPIConexaoDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TurmasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Turmas
        [HttpGet]
        public ActionResult<IEnumerable<Turma>> Get()
        {
            var turmas = _context.Turmas.AsNoTracking().ToList();
            if (turmas is null)
            {
                return NotFound("Nenhuma turma Encontrado");
            }
            return turmas; 
        }

        [HttpGet("alunos")]
        public ActionResult<IEnumerable<Turma>> GetTurmasAlunos()
        {
            try
            {
                return _context.Turmas.Include(a => a.Alunos).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema inesperado na captura de dados solicitados.");
            }
            
        }

        // GET: api/Turmas/5
        [HttpGet("{id:int}", Name= "ObterTurma")]
        public ActionResult<Turma> GetTurma(int id)
        {
            try
            {
                var turma = _context.Turmas.FirstOrDefault(x => x.TurmaId == id);

                if (turma == null)
                {
                    return NotFound("Turma não encontrado.");
                }

                return Ok(turma);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema inesperado na captura de dados solicitados.");
            }
            
        }

        [HttpPost]
        public ActionResult<Turma> PostTurma(Turma turma)
        {
            if (turma is null)
            {
                return BadRequest();
            }

            _context.Turmas.Add(turma);
            _context.SaveChanges();

            var novaTurma = _context.Turmas.Where(x => x.TurmaId == turma.TurmaId); 

            return new CreatedAtRouteResult("ObterTurma", new { id = turma.TurmaId }, turma);
        }

        // PUT: api/Turmas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Turma turma)
        {
            if (id != turma.TurmaId)
            {
                return BadRequest();
            }

            _context.Entry(turma).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(turma);
        }


        // DELETE: api/Turmas/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var turma = _context.Turmas.FirstOrDefault(x => x.TurmaId == id);
            if (turma == null)
            {
                return NotFound("Turma não encontrada");
            }

            _context.Turmas.Remove(turma);
            _context.SaveChanges();

            return Ok(turma);
        }

        private bool TurmaExists(int id)
        {
            return _context.Turmas.Any(e => e.TurmaId == id);
        }
    }
}
