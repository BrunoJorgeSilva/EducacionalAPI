using EducacionalAPIConexaoDB.Context;
using EducacionalAPIConexaoDB.Models;
using EducacionalAPIConexaoDB.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace EducacionalAPIConexaoDB.Persistency
{
    public class StudentPersistence : IStudentPersistence
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentPersistence(AppDbContext context
                                  ,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Student> GetStudents()
        {
            IEnumerable<Student> Students = _context.Students.AsNoTracking().ToList();
            return Students;
        }

        public IEnumerable<Student> GetStudentByName(string Name)
        {
            var Students = _context.Students.Where(x => x.Name.Contains(Name)).ToList();

            if (Students == null)
            {
                throw new Exception("Student não encontrado");
            }

            return Students;
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
        }

        public Student PostStudent(StudentViewModel student)
        {
            Student studentEntity = _mapper.Map<Student>(student);
            try
            {
                _context.Students.Add(studentEntity);
                _context.SaveChanges();
                return studentEntity;
            }
            catch
            {
                throw new Exception("Post Student Fail, contact de adm of the Api.");
            }
          
        }

        public Student PutStudent(int id, Student student)
        {
            Student oldStudentToEdit = GetStudentById(id);

            oldStudentToEdit.Name = student.Name;
            oldStudentToEdit.ClassRoomId = student.ClassRoomId;

            _context.Update(oldStudentToEdit);
            _context.SaveChanges();

            return oldStudentToEdit;
        }

        public void DeleteStudent(int id)
        {
            Student student = GetStudentById(id);
            if (student == null)
            {
                throw new Exception("Student Not Found!");
            }
            try
            {
                _context.Students.Remove(student);
            }
            catch 
            {
                throw new Exception("Failed to delete the Student.");
            }
        }

        public bool StudentExists(int id)
        {
            if (_context.Students.Any(e => e.StudentId == id))
                return true;
            else 
                return false;
        }
    }
}
