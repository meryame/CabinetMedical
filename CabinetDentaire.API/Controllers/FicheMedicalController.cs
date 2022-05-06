using CabinetDentaire.BLL.Services;
using CabinetDentaire.DAL.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CabinetDentaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FicheMedicalController : ControllerBase
    {
        private readonly FicheMedicalService _ficheMedicalService;
        public FicheMedicalController(FicheMedicalService ficheMedicalService)
        {
            _ficheMedicalService = ficheMedicalService;
        }
        // GET: api/<FicheMedicalController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FicheMedicalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FicheMedicalController>
        [HttpPost]
        public async Task<IActionResult> Add(FicheMedical ficheMedical)
        {
            try
            {
                if (ficheMedical == null)
                    return BadRequest("enter information");
                await _ficheMedicalService.AddFicheMedical(ficheMedical);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT api/<FicheMedicalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FicheMedicalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
