using CabinetDentaire.DAL.Data.Models;
using Dapper;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.BLL.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly DbContext _dbContext;
        public ConsultationService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddConsutation(Consultation consultation)
        {
            var commandText = "insert into consultation (consultid,patientid,typeconsult,tarif) values (@ConsultID,@PatientID,@Type,@Tarif)";
            var parameters = new DynamicParameters();
            parameters.Add("ConsultID", consultation.ConsultID, DbType.Guid);
            parameters.Add("PatientID", consultation.PatientID, DbType.Guid);
            parameters.Add("Type", consultation.Type, DbType.String);
            parameters.Add("Tarif", consultation.Tarif, DbType.String);

            using(var connection = _dbContext.Connection())
            {
                await connection.ExecuteAsync(commandText, parameters);
            }

        }
    }
}
