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
    public class RendezVousService : IRendezVousService
    {
        private readonly DbContext _dbContext;
        public RendezVousService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddRendezVous(RendezVous rendezVous)
        {
            var commandText = "insert into rendezvous (patientid,daterendezvous,dentisteid,consultid,cause,etatrendezvous) values (@PatientID,@Date,@DentisteID,@ConsultID,@Cause,@EtatRendezVous)";
            var parameters = new DynamicParameters();
            parameters.Add("PatientID", rendezVous.PatientID, DbType.Guid);
            parameters.Add("Date", rendezVous.Date, DbType.Date);
            parameters.Add("DentisteID", rendezVous.DentisteID, DbType.Guid);
            parameters.Add("ConsultID", rendezVous.ConsultID, DbType.Guid);
            parameters.Add("EtatRendezVous",rendezVous.EtatRendezVous, DbType.Boolean);
            parameters.Add("Cause", rendezVous.Cause, DbType.String);

            using (var connection = _dbContext.Connection())
            {
                await connection.ExecuteAsync(commandText, parameters);
            }
        }

        public async Task CancelRendezVous(Guid id, RendezVous rendezVous)
        {
            var commandText = "update rendezvous set etatrendezvous = @EtatRendezVous , cause = @Cause where rendezvousid = @RendezVousID";
            var parameters = new DynamicParameters();
            parameters.Add("EtatRendezVous", rendezVous.EtatRendezVous, DbType.Boolean);
            parameters.Add("Cause", rendezVous.Cause, DbType.String);
            parameters.Add("RendezVousID", id, DbType.Guid);
            using (var connection = _dbContext.Connection())
            {
                await connection.ExecuteAsync(commandText, parameters);
            }
        }

        public async Task<IEnumerable<RendezVous>> GetRendezVous()
        {
            var commandText = "select r.rendezvousid,c.consultid,c.typeconsult,p.patientid,p.lastname,d.dentisteid,d.lastname FROM rendezvous JOIN consultation c ON c.consultid = r.consultid JOIN patient p ON p.patientid = p.consultid JOIN dentiste d ON d.patientid = d.patientid order by r.daterendezvous";
            using (var connection = _dbContext.Connection())
            {
                return (await connection.QueryAsync<RendezVous>(commandText)).ToList();
            }
        }

        public async Task<RendezVous> GetRendezVous(Guid id)
        {
            var commandText = "select * from rendezvous where rendezvousid = @RendezVousID";
            var parameters = new DynamicParameters();
            parameters.Add("RendezVousID", id, DbType.Guid);
            using (var connection = _dbContext.Connection())
            {
                return (await connection.QueryFirstOrDefaultAsync<RendezVous>(commandText, parameters));
            }
        }
    }
}