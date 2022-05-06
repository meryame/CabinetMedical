using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabinetDentaire.DAL.Data.Models;

namespace CabinetDentaire.BLL.Services
{
    public interface IDentisteService
    {   
        public Task<IEnumerable<Dentiste>> GetAllDentiste();
        public Task UpdateCH(Dentiste dentiste, Guid id);
        public Task AddDentiste(Dentiste dentiste);
    }
}
