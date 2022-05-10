using CabinetDentaire.BLL.Services;
using CabinetDentaire.DAL.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CabinetDentaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationService _consultationService;
        public ConsultationController(IConsultationService consultationService)
        {
            _consultationService = consultationService;
        }
        // GET: api/<ConsultationController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var consultations = await _consultationService.GetAllConsultations();
                return Ok(consultations);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET api/<ConsultationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest("enter id");
                await _consultationService.GetConsultation(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST api/<ConsultationController>
        [HttpPost]
        public async Task<IActionResult> Add(Consultation consultation)
        {
            try
            {
                if (consultation == null)
                    return BadRequest();
                await _consultationService.AddConsutation(consultation);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT api/<ConsultationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Consultation consultation , Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest("enter id");
                await _consultationService.UpdateConsultation(consultation, id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<ConsultationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest("enter id");
                await _consultationService.DeleteConsultation(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
