using CabinetDentaire.DAL.Data.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.BLL.Services
{
    public class FicheMedicalService : IFicheMedicalService
    {
        private readonly DbContext _dbContext;
        public FicheMedicalService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddFicheMedical(FicheMedical ficheMedical)
        {
            var commandText = "INSERT INTO fichemedical (dentisteid,traitement,patientid) VALUES (@DentisteID, @Traitement, @PatientID)";
            var parameters = new DynamicParameters();
            parameters.Add("DentisteID", ficheMedical.DentisteID, DbType.Guid);
            parameters.Add("traitement", ficheMedical.Traitement, DbType.String);
            parameters.Add("PatientID", ficheMedical.PatientID, DbType.Guid);
            using(var connection = _dbContext.Connection())
            {
               await connection.ExecuteAsync(commandText, parameters);
            }

        }
    }
}
