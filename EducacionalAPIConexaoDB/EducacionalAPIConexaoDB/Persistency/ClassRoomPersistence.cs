using EducacionalAPIConexaoDB.Context;
using EducacionalAPIConexaoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducacionalAPIConexaoDB.Persistency
{
    public class ClassRoomPersistence : IClassRoomPersistence
    {
        private readonly AppDbContext _context;

        public ClassRoomPersistence(AppDbContext context)
        {
            _context = context;
        }
        public List<Classroom> GetClassRooms()
        {
            //Arrumar isso aqui e introzir o getAll
            var ClassRooms = _context.ClassRooms.ToList();
            return ClassRooms;
        }
        public List<Classroom> GetClassRoomsAlunos()
        {
            return _context.ClassRooms.Include(a => a.Students).ToList();
        }
        public Classroom GetClassRoomById(int id)
        {
           return _context.ClassRooms.Include(x => x.Students).FirstOrDefault(x => x.ClassroomId == id);
        }
        public Classroom PostClassRoom(Classroom classroom)
        {
            _context.ClassRooms.Add(classroom);
            _context.SaveChanges();
            return classroom;
        }
        public Classroom Put(int id, Classroom classroom)
        {
            var classroomToEdit = GetClassRoomById(id);
            if(classroomToEdit != null)
            {
                classroom.ClassroomId = id;
            }

            _context.Update(classroom);
            _context.SaveChanges();

            return classroom;
        }
        public bool Delete(int id)
        {
            var classroom = _context.ClassRooms.FirstOrDefault(x => x.ClassroomId == id);
            if (classroom == null)
            {
                throw new Exception ("Classroom not found");
            }
            classroom.Active = false;
            _context.ClassRooms.Update(classroom);
            _context.SaveChanges();
            return true;
        }

        public bool ClassRoomExists(int id)
        {
            return _context.ClassRooms.Any(e => e.ClassroomId == id);
        }


    }
}
