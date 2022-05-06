using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.DAL.Data.Models
{
    public class DbContext
    {
        private readonly IConfiguration _configuration;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection Connection()
            => new NpgsqlConnection(_configuration.GetConnectionString("MyConnection"));
    }
}
