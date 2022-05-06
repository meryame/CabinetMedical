using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.DAL.Data.Models
{
    public class Patient
    {
        public Guid PatientID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public int Age { get; set; }
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }
        public Guid DentisteID { get; set; }





    }
}
