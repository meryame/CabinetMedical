using CabinetDentaire.BLL.Services;
using CabinetDentaire.DAL.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CabinetDentaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendezVousController : ControllerBase
    {
        private readonly IRendezVousService _rendezVousService;
        public RendezVousController(IRendezVousService rendezVousService)
        {
            _rendezVousService = rendezVousService;
        }
        // GET: api/<RendezVousController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var rendezvous = await _rendezVousService.GetRendezVous();
                return Ok(rendezvous);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET api/<RendezVousController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                    return NotFound();
                var rdv = await _rendezVousService.GetRendezVous(id);
                return Ok(rdv);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // POST api/<RendezVousController>
        [HttpPost]
        public async Task<IActionResult> Add(RendezVous rendezVous)
        {
            try
            {
                if (rendezVous == null)
                    return BadRequest();
                await _rendezVousService.AddRendezVous(rendezVous);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT api/<RendezVousController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,RendezVous rendezVous)
        {
            try
            {
                if (id != rendezVous.RendezVousID)
                    return BadRequest("Rdv id invalid");
                var rdvToUpdate = await _rendezVousService.GetRendezVous(id);
                if (rdvToUpdate == null)
                    return NotFound();
                await _rendezVousService.CancelRendezVous(id,rendezVous);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<RendezVousController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
