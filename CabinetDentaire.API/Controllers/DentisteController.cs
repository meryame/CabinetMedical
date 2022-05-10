using CabinetDentaire.BLL.Services;
using CabinetDentaire.DAL.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CabinetDentaire.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DentisteController : ControllerBase
    {
        private readonly IDentisteService _dentisteService;
        public DentisteController(IDentisteService dentisteService)
        {
            _dentisteService = dentisteService;
        }
        // GET: api/<DentisteController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var dentistes = await _dentisteService.GetAllDentiste();
                return Ok(dentistes);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET api/<DentisteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                    return BadRequest("enter id");
                await _dentisteService.GetDentisteById(id);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // POST api/<DentisteController>
        [HttpPost]
        public async Task<IActionResult> Add(Dentiste dentiste)
        {
            try
            {
                if (dentiste == null)
                    return BadRequest("enter dentiste information!");
                await _dentisteService.AddDentiste(dentiste);
                return Ok();
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT api/<DentisteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Dentiste dentiste,Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest("enter id!");
                 await _dentisteService.UpdateCH(dentiste, id);
                return Ok();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        // DELETE api/<DentisteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest();
                await _dentisteService.DeleteDentiste(id);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
