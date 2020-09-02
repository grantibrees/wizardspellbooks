using burgershack.Models;
using burgershack.Services;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers {
  [Route ("api/[controller]")]
  [ApiController]
  public class SpellbooksController : ControllerBase {
    private readonly SpellbooksService _service;

    public SpellbooksController (SpellbooksService service) {
      _service = service;
    }

    [HttpPost]
    public ActionResult<Spellbook> Post ([FromBody] Spellbook newSpellbook) {
      try {
        return Ok (_service.Create (newSpellbook));
      } catch (System.Exception e) {

        return BadRequest (e.Message);
      }
    }

    [HttpDelete ("{id}")]
    public ActionResult<Spellbook> Delete (int id) {
      try {
        return Ok (_service.Delete (id));
      } catch (System.Exception e) {
        return BadRequest (e.Message);
      }
    }
  }
}