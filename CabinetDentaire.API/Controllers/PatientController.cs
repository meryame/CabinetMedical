using CabinetDentaire.BLL.Services;
using CabinetDentaire.DAL.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CabinetDentaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        // GET: api/<PatientController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var patients = await _patientService.GetAllPatients();
                if(patients == null)
                {
                    return NotFound();
                }
                return Ok(patients);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
              if(id == Guid.Empty)
                    return NoContent();
                var patient = await _patientService.GetPatient(id);
                if(patient == null)
                    return NotFound();
                return Ok(patient);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // POST api/<PatientController>
        [HttpPost]
        public async Task<IActionResult> Add(Patient patient)
        {
            try
            {
                if(patient == null)
                    return BadRequest();
                await _patientService.AddPatient(patient);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Patient patient, Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest("enter informations");
                await _patientService.UpdatePatient(patient,id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest("enter id patient please");
                await _patientService.DeletePatient(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
