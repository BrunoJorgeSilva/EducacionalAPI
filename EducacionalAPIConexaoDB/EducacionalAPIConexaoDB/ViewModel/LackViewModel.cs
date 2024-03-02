using System.Net.NetworkInformation;
using System.Text.Json.Serialization;
using EducacionalAPIConexaoDB.Models;

namespace EducacionalAPIConexaoDB.ViewModel
{
    public class LackViewModel
    {
        public int LackId { get; set; }
        public DateTime? LackDate { get; set;}
        public int StudentId { get; set; }
        [JsonIgnore]
        public StudentViewModel? Student { get; set; }

        public int ClassRoomId { get; set; }
        [JsonIgnore]
        public ClassroomViewModel? ClassRoom { get;set; }
        public bool HealthCertificate { get; set; }
        public bool Active { get; set; }

    }
}
