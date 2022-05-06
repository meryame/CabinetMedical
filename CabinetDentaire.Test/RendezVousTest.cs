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
    public class RendezVousTest
    {
        private readonly IRendezVousService _rendezVousService;
        private readonly DbContext _dbContext;
        public RendezVousTest(IRendezVousService rendezVousService,DbContext dbContext)
        {
            _rendezVousService = rendezVousService;
            _dbContext = dbContext;
        }

        [Fact]
        public void TestToAddRendezVous()
        {
            var rendezVous = new RendezVous
            {
                PatientID = new Guid("c320492b-a63a-4217-b7ad-31654f036daa"),
                Date = DateTime.Now,
                DentisteID = new Guid("34ccf93f-dc87-462c-ba07-18b05e77bf1f"),
                ConsultID = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
            };
           
            var response = _rendezVousService.AddRendezVous(rendezVous);
            Assert.NotNull(response);
            //Assert.IsType<OkObjectResult>(response);


        }
        [Fact]
        public void TestToCanclRDV()
        {
            var rendezVousID = new Guid("a7b04faf-ab30-47aa-9280-7a323da726ef");
            var rendezVous = new RendezVous
            {
                EtatRendezVous = false,
                Cause = "travail"
            };
            var response = _rendezVousService.CancelRendezVous(rendezVousID, rendezVous);
            Assert.NotNull(response);
        }

    }
}
