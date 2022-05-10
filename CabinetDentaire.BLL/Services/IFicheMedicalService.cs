using CabinetDentaire.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.BLL.Services
{
    public interface IFicheMedicalService
    {
        public Task AddFicheMedical(FicheMedical ficheMedical);
        public Task<IEnumerable<FicheMedical>> GetAllFichesMedicals();
        public Task<FicheMedical> GetFicheMedical(Guid id);
        public Task DeleteFicheMedical(Guid id);
        public Task UpdateFicheMedical(FicheMedical ficheMedical, Guid id);
    }
}
