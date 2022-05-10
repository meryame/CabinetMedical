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

        public async Task DeleteFicheMedical(Guid id)
        {
            var commandText = "delete from fichemedical where fichemedicalid = @FicheMedicalID";
            var parameters = new DynamicParameters();
            parameters.Add("FicheMedicalID", id, DbType.Guid);
            using (var connection = _dbContext.Connection())
            {
                await connection.QueryFirstOrDefaultAsync<FicheMedical>(commandText, parameters);
            }
        }

        public async Task<IEnumerable<FicheMedical>> GetAllFichesMedicals()
        {
            var commandText = "select * from fichemedical";
            using (var connection = _dbContext.Connection())
            {
                return (await connection.QueryAsync<FicheMedical>(commandText)).ToList();
            }
        }

        public async Task<FicheMedical> GetFicheMedical(Guid id)
        {
            var commandText = "select * from fichemedical where fichemedicalid = @FicheMedicalID";
            var parameters = new DynamicParameters();
            parameters.Add("FicheMedicalID", id, DbType.Guid);
            using (var connection = _dbContext.Connection())
            {
                return (await connection.QueryFirstOrDefaultAsync<FicheMedical>(commandText, parameters));
            }
        }

        public async Task UpdateFicheMedical(FicheMedical ficheMedical, Guid id)
        {
            var commandText = "update fichemedical set traitement = @Traitement where fichemedicalid = @FicheMedicalID";
            var parameters = new DynamicParameters();
            parameters.Add("Traitement", ficheMedical.Traitement, DbType.String);
            parameters.Add("FicheMedicalID", id, DbType.Guid);
            using (var connection = _dbContext.Connection())
            {
                await connection.ExecuteAsync(commandText, parameters);
            }
        }
    }
}
