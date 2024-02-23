using EducacionalAPIConexaoDB.Models;
using EducacionalAPIConexaoDB.Persistency;

namespace EducacionalAPIConexaoDB.Service
{
    public class ClassRoomService : IClassRoomService
    {
        private readonly IClassRoomPersistence _classroomPersistence;

        public ClassRoomService(IClassRoomPersistence classroomPersistence)
        {
            classroomPersistence = _classroomPersistence;
        }
        public List<Classroom> GetClassRooms()
        {
            return _classroomPersistence.GetClassRooms();
        }
        public List<Classroom> GetClassRoomsAlunos()
        {
            return _classroomPersistence.GetClassRoomsAlunos();
        }
        public Classroom GetClassRoomById(int id)
        {
            return _classroomPersistence.GetClassRoomById(id);
        }
        public Classroom PostClassRoom(Classroom classroom)
        {
            return _classroomPersistence.PostClassRoom(classroom);
        }
        public Classroom Put(int id, Classroom classroom)
        {
            return _classroomPersistence.Put(id, classroom);
        }
        public bool Delete(int id)
        {
            return _classroomPersistence.Delete(id);
        }
        public bool ClassRoomExists(int id)
        {
            return _classroomPersistence.ClassRoomExists(id);
        }
    }
}
