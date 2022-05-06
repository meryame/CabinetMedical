using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.DAL.Data.Models
{
    public class Dentiste
    {
        public Guid DentisteID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Adresse { get; set; }
        [DisplayFormat(DataFormatString = "{hh:mm:ss}", ApplyFormatInEditMode = true)]
        public TimeSpan StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{hh:mm:ss}", ApplyFormatInEditMode = true)]
        public TimeSpan EndTime { get; set; }
        public string? Speciality { get; set; }
    }
}
