using CabinetDentaire.BLL.Services;
using CabinetDentaire.DAL.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CabinetDentaire.Test
{
    public class PatientTest : IClassFixture<DbContext>
    {
        private readonly IPatientService _patientService;
        private readonly DbContext _dbContext;
        public PatientTest(IPatientService patientService, DbContext dbContext)
        {
            _patientService = patientService;
            _dbContext = dbContext;
        }
        [Fact]
        public void TestToAddPatient()
        {
            var patient = new Patient
            {
                FirstName = "meryy",
                LastName = "zeeeeerh",
                Age = 26,
                Adresse = "sale",
                Telephone = "0689784635"
            };
            var response = _patientService.AddPatient(patient);
            Assert.NotNull(response);
           //Assert.IsType<OkObjectResult>(response);
           

        }
    }
}
