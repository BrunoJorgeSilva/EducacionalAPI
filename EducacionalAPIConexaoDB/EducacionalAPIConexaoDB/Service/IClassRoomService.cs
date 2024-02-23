using EducacionalAPIConexaoDB.Models;
using EducacionalAPIConexaoDB.Persistency;

namespace EducacionalAPIConexaoDB.Service
{
    public interface IClassRoomService
    {
        public List<Classroom> GetClassRooms();
        public List<Classroom> GetClassRoomsAlunos();
        public Classroom GetClassRoomById(int id);
        public Classroom PostClassRoom(Classroom classroom);
        public Classroom Put(int id, Classroom classroom);
        public bool Delete(int id);
        public bool ClassRoomExists(int id);
    }
}
