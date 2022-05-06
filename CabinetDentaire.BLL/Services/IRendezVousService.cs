using CabinetDentaire.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.BLL.Services
{
    public interface IRendezVousService
    {
        public Task AddRendezVous(RendezVous rendezVous);
        public Task<IEnumerable<RendezVous>> GetRendezVous();
        public Task CancelRendezVous(Guid id,RendezVous rendezVous);
        public Task<RendezVous> GetRendezVous(Guid id);
    }
}
