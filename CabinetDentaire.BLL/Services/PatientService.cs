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
    public class PatientService : IPatientService
    {
        private readonly DbContext _dbContext;
        public PatientService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddPatient(Patient patient)
        {
            var commandText = "INSERT INTO patient (firstname,lastname,age,adresse,telephone,dentisteid) VALUES (@FirstName,@LastName,@Age,@Adresse,@Telephone,@DentisteID)";
            var parameters = new DynamicParameters();
            parameters.Add("firstname", patient.FirstName, DbType.String);
            parameters.Add("lastname" , patient.LastName, DbType.String);
            parameters.Add("age" , patient.Age, DbType.Int32);
            parameters.Add("adresse" , patient.Adresse, DbType.String);
            parameters.Add("telephone" , patient.Telephone, DbType.String);
            parameters.Add("DentisteID", patient.DentisteID, DbType.Guid);
            using (var connection = _dbContext.Connection())
            {
                await connection.ExecuteAsync(commandText, parameters);
            }
        }

        public async Task DeletePatient(Guid id)
        {
            var commandText = "delete from patient where patientid = @PatientID";
            var parameters = new DynamicParameters();
            parameters.Add("PatientID", id, DbType.Guid);
            using (var connection = _dbContext.Connection())
            {
                await connection.QueryFirstOrDefaultAsync<Patient>(commandText, parameters);
            }
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            var commandText = "select * from patient";
            using(var connection = _dbContext.Connection())
            {
                return (await connection.QueryAsync<Patient>(commandText)).ToList();
            }
        }

        public async Task<Patient> GetPatient(Guid id)
        {
            var commandText = "select * from patient where patientid = @PatientID";
            var parameters = new DynamicParameters();
            parameters.Add("PatientID", id, DbType.Guid);
            using (var connection = _dbContext.Connection())
            {
                return (await connection.QueryFirstOrDefaultAsync<Patient>(commandText, parameters));
            }
        }
        public async Task UpdatePatient(Patient patient, Guid id)
        {
            var commandText = "update patient set firstname = @FirstName, lastname = @LastName,age = @Age, adresse = @Adresse ,telephone = @Telephone where patientid = @PatientID";
            var parameters = new DynamicParameters();
            parameters.Add("FirstName",patient.FirstName,DbType.String);
            parameters.Add("LastName",patient.LastName,DbType.String);
            parameters.Add("Age",patient.Age,DbType.Int32);
            parameters.Add("Adresse", patient.Adresse, DbType.String);
            parameters.Add("Telephone",patient.Telephone, DbType.String);
            parameters.Add("PatientID",id, DbType.Guid);
            using (var connection = _dbContext.Connection())
            {
                await connection.ExecuteAsync(commandText, parameters);
            }
        }
    }
}
