using EducacionalAPIConexaoDB.Context;
using EducacionalAPIConexaoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducacionalAPIConexaoDB.Persistency
{
    public class StudentPersistence : IStudentPersistence
    {
        private readonly AppDbContext _context;

        public StudentPersistence(AppDbContext context)
        {
            _context = context;
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

        public Student PostStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return student;
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
