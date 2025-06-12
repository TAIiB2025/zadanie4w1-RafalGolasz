using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KsiazkiController : ControllerBase
    {
        private readonly IKsiazkiService _service;

        public KsiazkiController(IKsiazkiService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ksiazka>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Ksiazka> GetById(int id)
        {
            var ksiazka = _service.GetById(id);
            if (ksiazka == null)
                return NotFound();
            return Ok(ksiazka);
        }

        [HttpPost]
        public IActionResult Post([FromBody] KsiazkaBody dto)
        {
            _service.Add(dto);
            return Created("", dto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] KsiazkaBody dto)
        {
            _service.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
