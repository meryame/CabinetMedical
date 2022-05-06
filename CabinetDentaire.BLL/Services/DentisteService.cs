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
    public class DentisteService : IDentisteService
    {
        private readonly DbContext _dbContext;
        public DentisteService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddDentiste(Dentiste dentiste)
        {
            var commandText = "INSERT INTO dentiste(lastname,firstname,adresse,starttime,endtime,speciality) VALUES (@LastName, @FirstName, @Adresse, @StartTime, @EndTime, @Speciality)";
            var parameters = new DynamicParameters();
            parameters.Add("lastname",dentiste.LastName,DbType.String);
            parameters.Add("firstname", dentiste.FirstName, DbType.String);
            parameters.Add("adresse", dentiste.Adresse, DbType.String);
            parameters.Add("StartTime", dentiste.StartTime, DbType.Time);
            parameters.Add("EndTime", dentiste.EndTime, DbType.Time);
            parameters.Add("speciality", dentiste.Speciality, DbType.String);

            using(var connection = _dbContext.Connection())
            {
                await connection.ExecuteAsync(commandText, parameters);
            }

        }

        public async Task<IEnumerable<Dentiste>> GetAllDentiste()
        {
            var commandText = "select * from dentiste";
            using(var connection = _dbContext.Connection())
            {
                return (await connection.QueryAsync<Dentiste>(commandText)).ToList();
            }
        }
        public async Task UpdateCH(Dentiste dentiste, Guid id)
        {
            var commandText = "Update dentiste set starttime = @StartTime , endtime = @EndTime where dentisteid = @DentisteID";
            var parameters = new DynamicParameters();
            parameters.Add("StartTime", dentiste.StartTime, DbType.Time);
            parameters.Add("EndTime", dentiste.EndTime, DbType.Time);
            parameters.Add("DentisteID", id, DbType.Guid);
            using (var connection = _dbContext.Connection())
            {
                await connection.ExecuteAsync(commandText, parameters);
            }
        }
    }
}
