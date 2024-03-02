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
using EducacionalAPIConexaoDB.Service;
using EducacionalAPIConexaoDB.ViewModel;
using AutoMapper;

namespace EducacionalAPIConexaoDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IStudentService _studentsService;
        private readonly IMapper _mapper;

        public StudentsController(AppDbContext context, 
                                  IStudentService studentsService
                                  ,IMapper mapper)
        {
            _context = context;
            _studentsService = studentsService;
            _mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            var Students = _studentsService.GetStudents();
            if (Students is null)
            {
                return NotFound("Nenhum Student Encontrado");
            }
            return Ok(Students); 
        }

        // GET: api/Students/5
        [HttpGet("{id:int}", Name= "GetStudentById")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _studentsService.GetStudentById(id);
            if (student == null)
            {
                return NotFound("Student not found. Check the Id requested please.");
            }

            return student;
        }

        [HttpGet("{Name}")]
        public ActionResult<IEnumerable<Student>> GetStudentByName(string Name)
        {
            var students = _studentsService.GetStudentByName(Name);

            if (students == null)
            {
                return NotFound("Student not found.");
            }

            return Ok(students);
        }

        [HttpPost]
        public ActionResult<Student> PostStudent(StudentViewModel Student)
        {
            if (Student is null)
            {
                return BadRequest();
            }
            var student = _studentsService.PostStudent(Student);
            return Ok(student);
        }
        
        [HttpPut("{id:int}")]
        public ActionResult PutStudent(int id, Student student)
        {
            var studentEdited = _studentsService.PutStudent(id, student);

            if(studentEdited == null)
            {
                return BadRequest("Fail to edit the student, contact the administrator of the api please.");
            }

            return Ok(studentEdited);
        }


        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            _studentsService.DeleteStudent(id);
            return Ok("The Student with the id: " + id + ",was successfully deleted.");
        }

        [HttpGet("studentExists")]
        public ActionResult<bool> StudentExists(int id)
        {
            bool exist = _studentsService.StudentExists(id);
            if (exist)
                return Ok(exist);
            else
                return NotFound(exist);
        }
    }
}
