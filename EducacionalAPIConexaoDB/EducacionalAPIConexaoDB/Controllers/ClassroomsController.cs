using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducacionalAPIConexaoDB.Context;
using EducacionalAPIConexaoDB.Models;
using EducacionalAPIConexaoDB.Service;

namespace EducacionalAPIConexaoDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly IClassRoomService _classroomService;

        public ClassroomsController(IClassRoomService classroomService)
        {
            _classroomService = classroomService;
        }

        // GET: api/ClassRooms
        [HttpGet]
        public ActionResult<IEnumerable<Classroom>> Get()
        {
            var classRooms = _classroomService.GetClassRooms();
            if (classRooms is null || classRooms.Count == 0)
            {
                return NotFound("Classrooms not found.");
            }
            return Ok(classRooms);
        }

        [HttpGet("alunos")]
        public ActionResult<IEnumerable<Classroom>> GetClassRoomsAlunos()
        {
            var classroomswithstudents = _classroomService.GetClassRoomsAlunos();
            if (classroomswithstudents == null || classroomswithstudents.Count() == 0)
                return NotFound("Classrooms not found");
            else
                return Ok(classroomswithstudents);

        }

        // GET: api/ClassRooms/5
        [HttpGet("{id:int}", Name = "GetClassRoomById")]
        public ActionResult<Classroom> GetClassRoomById(int id)
        {

            var ClassRoom = _classroomService.GetClassRoomById(id);

            if (ClassRoom == null)
            {
                return NotFound("Classroom not found.");
            }
            return Ok(ClassRoom);
        }

        [HttpPost]
        public ActionResult<Classroom> PostClassRoom(Classroom ClassRoom)
        {
            if (ClassRoom is null)
            {
                return BadRequest();
            }
            var classroomAdded = _classroomService.PostClassRoom(ClassRoom);

            return Ok(classroomAdded);
        }

        // PUT: api/ClassRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public ActionResult<Classroom> Put(int id, Classroom ClassRoom)
        {
            var classRoomEdited = _classroomService.Put(id, ClassRoom);
            return Ok(classRoomEdited);
        }


        // DELETE: api/ClassRooms/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool deleted = _classroomService.Delete(id);

            return Ok("Classroom deleted: " + deleted);
        }

        public ActionResult <bool> ClassRoomExists(int id)
        {
            return Ok(_classroomService.ClassRoomExists(id));
        }
    }
}
