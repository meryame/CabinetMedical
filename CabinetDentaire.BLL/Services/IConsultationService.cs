using CabinetDentaire.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.BLL.Services
{
    public interface IConsultationService
    {
        public Task AddConsutation(Consultation consultation);
    }
}
