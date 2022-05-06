using CabinetDentaire.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.BLL.Services
{
    public interface IPatientService
    {
        public Task AddPatient(Patient patient);
        public Task<IEnumerable<Patient>> GetAllPatients();
        public Task<Patient> GetPatient(Guid id);
    }
}
