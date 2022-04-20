using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace CrossCountryApp.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [DisplayName("Student ID")]
        public int StudentID { get; set; }

        [DisplayName("Event ID")]
        public int EventID { get; set; }

        [DisplayName("Finish Time")]
        public DateTime FinishTime { get; set; }

        [DisplayName("Place")]
        public int Place { get; set; }
    }
}
