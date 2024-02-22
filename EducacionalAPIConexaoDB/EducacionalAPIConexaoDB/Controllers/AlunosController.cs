using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducacionalAPIConexaoDB.Context;
using EducacionalAPIConexaoDB.Models;
using EducacionalAPIConexaoDB.Persistency;

namespace EducacionalAPIConexaoDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAlunosPersistence _alunosPersistence;

        public AlunosController(AppDbContext context, IAlunosPersistence alunosPersistence)
        {
            _context = context;
            _alunosPersistence = alunosPersistence;
        }

        // GET: api/Alunos
        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> GetAlunos()
        {
            var alunos = _alunosPersistence.GetAlunos();
            //var alunos = _context.Alunos.AsNoTracking().ToList();
            if (alunos is null)
            {
                return NotFound("Nenhum aluno Encontrado");
            }
            return Ok(alunos); 
        }

        // GET: api/Alunos/5
        [HttpGet("{id:int}", Name= "ObterAluno")]
        public ActionResult<Aluno> GetAluno(int id)
        {
            var aluno = _context.Alunos.Where(x => x.AlunoId == id).Include("Email").FirstOrDefault(); 

            if (aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }

            return aluno;
        }

        [HttpGet("{nome}")]
        public ActionResult<IEnumerable<Aluno>> GetAlunoPorNome(string nome)
        {
            var alunos = _context.Alunos.Where(x => x.Nome.Contains(nome)).ToList();

            if (alunos == null)
            {
                return NotFound("Aluno não encontrado.");
            }

            return alunos;
        }

        [HttpPost]
        public ActionResult<Aluno> PostAluno(Aluno aluno)
        {
            if (aluno is null)
            {
                return BadRequest();
            }

            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            var novoAluno = _context.Alunos.Where(x => x.AlunoId == aluno.AlunoId); 

            return new CreatedAtRouteResult("ObterAluno", new { id = aluno.AlunoId }, aluno);
        }

        // PUT: api/Alunos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Aluno aluno)
        {
            if (id != aluno.AlunoId)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(aluno);
        }


        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(x => x.AlunoId == id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.AlunoId == id);
        }
    }
}
