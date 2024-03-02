using EducacionalAPIConexaoDB.Models;
using EducacionalAPIConexaoDB.Persistency;
using EducacionalAPIConexaoDB.ViewModel;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace EducacionalAPIConexaoDB.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentPersistence _studentPersistence;
        private readonly IMapper _mapper;
        public StudentService(IStudentPersistence studentPersistence
                              ,IMapper mapper) 
        { 
            _studentPersistence = studentPersistence;
            _mapper = mapper;
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

        public StudentViewModel PostStudent (StudentViewModel student)
        {
            return _mapper.Map<StudentViewModel>(_studentPersistence.PostStudent(student));
            

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
