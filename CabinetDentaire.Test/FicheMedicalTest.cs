using CabinetDentaire.BLL.Services;
using CabinetDentaire.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CabinetDentaire.Test
{
    public class FicheMedicalTest
    {
        private readonly IFicheMedicalService _ficheMedicalService;
        private readonly DbContext _dbContext;
        public FicheMedicalTest(IFicheMedicalService ficheMedicalService, DbContext dbContext)
        {
            _ficheMedicalService = ficheMedicalService;
            _dbContext = dbContext;
        }
        [Fact]
        public async Task Test()
        {
            var ficheMedical = new FicheMedical
            {
                DentisteID = new Guid("34ccf93f-dc87-462c-ba07-18b05e77bf1f"),
                Traitement = "detartrage",
                PatientID = new Guid("c320492b-a63a-4217-b7ad-31654f036daa")
            };

            var response = _ficheMedicalService.AddFicheMedical(ficheMedical);
            Assert.NotNull(response);
        }
    }
}
