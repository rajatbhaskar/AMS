using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class Student_Master
    {
        [Key]
        public int StudentEnroll_Id { get; set; }



        public DateTime Date { get; set; }

        public bool IsPresent { get; set; }
        public bool IsAbsent { get; set; }

        [ForeignKey("sub_info")]
        public int? SubjectId { get; set; }
        //navigation properties
        public Subject_Info sub_info { get; set; }


    }
}
