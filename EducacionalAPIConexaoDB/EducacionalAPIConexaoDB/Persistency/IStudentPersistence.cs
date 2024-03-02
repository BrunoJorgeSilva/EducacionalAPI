using EducacionalAPIConexaoDB.Models;
using EducacionalAPIConexaoDB.ViewModel;

namespace EducacionalAPIConexaoDB.Persistency
{
    public interface IStudentPersistence
    {
        public IEnumerable<Student> GetStudents();
        public IEnumerable<Student> GetStudentByName(string nome);
        public Student GetStudentById(int id);
        public Student PostStudent(StudentViewModel student);
        public Student PutStudent(int id, Student student);
        void DeleteStudent(int id);

        public bool StudentExists(int id);
    }
}
