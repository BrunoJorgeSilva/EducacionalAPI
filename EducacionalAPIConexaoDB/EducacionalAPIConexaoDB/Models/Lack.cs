using System.Text.Json.Serialization;

namespace EducacionalAPIConexaoDB.Models
{
    public class Lack
    {
        public int LackId { get; set; }
        public DateTime? LackDate { get; set;}
        public int StudentId { get; set; }
        [JsonIgnore]
        public Student? Student { get; set; }

        public int ClassRoomId { get; set; }
        [JsonIgnore]
        public Classroom? ClassRoom { get;set; }
        public bool HealthCertificate { get; set; }
        public bool Active { get; set; }

    }
}
