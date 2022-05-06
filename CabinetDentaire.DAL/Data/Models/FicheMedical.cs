using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.DAL.Data.Models
{
    public class FicheMedical
    {
        public Guid FicheMedicalID { get; set; }
        public Guid DentisteID { get; set; }
        public string? Traitement { get; set; }
        public Guid PatientID { get; set; }


    }
}
