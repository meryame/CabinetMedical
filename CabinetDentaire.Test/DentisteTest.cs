using CabinetDentaire.BLL.Services;
using CabinetDentaire.DAL.Data.Models;
using System;
using Xunit;

namespace CabinetDentaire.Test
{
    public class DentisteTest
    {
        private readonly IDentisteService _dentisteService;
        private readonly DbContext _dbContext;
        public DentisteTest(IDentisteService dentisteService,DbContext dbContext)
        {
            _dentisteService = dentisteService;
            _dbContext = dbContext;
        }
        [Fact]
        public void TestToChangeTime()
        {
            var dentisteID = new Guid("960382b7-2f8b-47a6-b74d-da1e5a129d95");
            var dentiste = new Dentiste
            {
                StartTime = new TimeSpan(12, 00, 0),
                EndTime = new TimeSpan(14, 30, 0)
            };
            var response = _dentisteService.UpdateCH(dentiste,dentisteID);
            Assert.NotNull(response);
        }
    }
}