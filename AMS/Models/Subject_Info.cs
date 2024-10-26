using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class Subject_Info
    {
        [Key]
        public int? SubjectId { get; set; }

        public string? SubjectName { get; set; }

        public string? SubjectDescription { get; set; }
    }
}
