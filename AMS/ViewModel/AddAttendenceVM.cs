using AMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.ViewModel
{
    public class AddAttendenceVM
    {
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public bool IsPresent { get; set; }
        public bool IsAbsent { get; set; }

       // public IEnumerable<Subject_Info>? SubjectId { get; set; }
       public int? SubjectId { get; set; }

        public string? SubjectName { get; set; }

        public IEnumerable<AddAttendenceVM>? StudentList { get; set; }


    }
}
