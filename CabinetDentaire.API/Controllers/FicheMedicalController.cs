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
        public async Task<IActionResult> Get()
        {
            try
            {
                var ficheMedical = await _ficheMedicalService.GetAllFichesMedicals();
                return Ok(ficheMedical);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET api/<FicheMedicalController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                    return BadRequest("enter id");
                await _ficheMedicalService.GetFicheMedical(id);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // POST api/<FicheMedicalController>
        [HttpPost]
        public async Task<IActionResult> Add(FicheMedical ficheMedical)
        {
            try
            {
                ficheMedical.FicheMedicalID = Guid.NewGuid();
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
        public async Task<IActionResult> Put(FicheMedical ficheMedical)
        {
            try
            {
                if (ficheMedical.FicheMedicalID == Guid.Empty)
                    return BadRequest("enter id");
                await _ficheMedicalService.UpdateFicheMedical(ficheMedical);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<FicheMedicalController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                    return BadRequest("enter id");
                await _ficheMedicalService.DeleteFicheMedical(id);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
