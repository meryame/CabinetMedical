using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.DAL.Data.Models
{
    public class Consultation
    {
        public Guid ConsultID { get; set; }
        public Guid PatientID { get; set; }
        public string? Type { get; set; }
        public string? Tarif { get; set; }
    }
}
