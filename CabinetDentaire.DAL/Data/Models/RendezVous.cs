using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.DAL.Data.Models
{
    public class RendezVous
    {
        public Guid RendezVousID { get; set; }
        public Guid PatientID { get; set; }
        public DateTime Date { get; set; }
        public Guid DentisteID { get; set; }
        public Guid ConsultID { get; set; }
        public bool EtatRendezVous { get; set; }
        public string? Cause { get; set; }
    }
}
