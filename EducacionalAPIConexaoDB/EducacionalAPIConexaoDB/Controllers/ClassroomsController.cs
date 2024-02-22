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
    public class ClassroomsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassroomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ClassRooms
        [HttpGet]
        public ActionResult<IEnumerable<Classroom>> Get()
        {
            var ClassRooms = _context.ClassRooms.AsNoTracking().ToList();
            if (ClassRooms is null)
            {
                return NotFound("Nenhuma ClassRoom Encontrado");
            }
            return ClassRooms; 
        }

        [HttpGet("alunos")]
        public ActionResult<IEnumerable<Classroom>> GetClassRoomsAlunos()
        {
            try
            {
                return _context.ClassRooms.Include(a => a.Students).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema inesperado na captura de dados solicitados.");
            }
            
        }

        // GET: api/ClassRooms/5
        [HttpGet("{id:int}", Name= "ObterClassRoom")]
        public ActionResult<Classroom> GetClassRoom(int id)
        {
            try
            {
                var ClassRoom = _context.ClassRooms.FirstOrDefault(x => x.ClassroomId == id);

                if (ClassRoom == null)
                {
                    return NotFound("ClassRoom não encontrado.");
                }

                return Ok(ClassRoom);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema inesperado na captura de dados solicitados.");
            }
            
        }

        [HttpPost]
        public ActionResult<Classroom> PostClassRoom(Classroom ClassRoom)
        {
            if (ClassRoom is null)
            {
                return BadRequest();
            }

            _context.ClassRooms.Add(ClassRoom);
            _context.SaveChanges();

            var novaClassRoom = _context.ClassRooms.Where(x => x.ClassroomId == ClassRoom.ClassroomId); 

            return new CreatedAtRouteResult("ObterClassRoom", new { id = ClassRoom.ClassroomId }, ClassRoom);
        }

        // PUT: api/ClassRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Classroom ClassRoom)
        {
            if (id != ClassRoom.ClassroomId)
            {
                return BadRequest();
            }

            _context.Entry(ClassRoom).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(ClassRoom);
        }


        // DELETE: api/ClassRooms/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var ClassRoom = _context.ClassRooms.FirstOrDefault(x => x.ClassroomId == id);
            if (ClassRoom == null)
            {
                return NotFound("ClassRoom não encontrada");
            }

            _context.ClassRooms.Remove(ClassRoom);
            _context.SaveChanges();

            return Ok(ClassRoom);
        }

        private bool ClassRoomExists(int id)
        {
            return _context.ClassRooms.Any(e => e.ClassroomId == id);
        }
    }
}
