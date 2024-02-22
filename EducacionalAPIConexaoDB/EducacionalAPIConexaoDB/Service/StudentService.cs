using EducacionalAPIConexaoDB.Models;
using EducacionalAPIConexaoDB.Persistency;
using Microsoft.EntityFrameworkCore;

namespace EducacionalAPIConexaoDB.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentPersistence _studentPersistence;
        public StudentService(IStudentPersistence studentPersistence) 
        { 
            _studentPersistence = studentPersistence;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentPersistence.GetStudents();
        }

        public IEnumerable<Student> GetStudentByName(string Name)
        {
            return _studentPersistence.GetStudentByName(Name);
        }

        public Student GetStudentById(int id)
        {
            return _studentPersistence.GetStudentById(id);
        }

        public Student PostStudent (Student student)
        {
            return _studentPersistence.PostStudent(student);
        }

        public Student PutStudent(int id, Student student)
        {
            return _studentPersistence.PutStudent(id, student);
        }

        public void DeleteStudent(int id)
        {
            _studentPersistence.DeleteStudent(id);
        }

        public bool StudentExists(int id)
        {
            return _studentPersistence.StudentExists(id);
        }
    }
}
