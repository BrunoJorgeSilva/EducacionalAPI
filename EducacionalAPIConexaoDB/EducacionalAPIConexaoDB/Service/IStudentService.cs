using EducacionalAPIConexaoDB.Models;
using EducacionalAPIConexaoDB.ViewModel;

namespace EducacionalAPIConexaoDB.Service
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetStudents();
        public IEnumerable<Student> GetStudentByName(string nome);

        public Student GetStudentById(int id);
        public StudentViewModel PostStudent(StudentViewModel student);
        public Student PutStudent(int id, Student student2);
        void DeleteStudent(int id);

        public bool StudentExists(int id);
    }
}
