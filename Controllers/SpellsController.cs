using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Services;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers {
  [Route ("api/[controller]")]
  [ApiController]
  public class SpellsController : ControllerBase {
    private readonly SpellsService _service;
    public SpellsController (SpellsService service) {
      _service = service;
    }

    //GET
    [HttpGet]
    public ActionResult<IEnumerable<Spell>> Get () {
      try {
        return Ok (_service.Get ());
      } catch (Exception e) {
        return BadRequest (e.Message);
      }
    }
    //GETBYID
    [HttpGet ("{Id}")]
    public ActionResult<Spell> Get (int Id) {
      try {
        return Ok (_service.Get (Id));
      } catch (Exception e) {
        return BadRequest (e.Message);
      }
    }
    //POST
    [HttpPost]
    public ActionResult<Spell> Post ([FromBody] Spell newSpell) {
      try {
        return Ok (_service.Create (newSpell));
      } catch (Exception e) {
        return BadRequest (e.Message);
      }
    }
    //DEL
    [HttpDelete ("{id}")]
    public ActionResult<Spell> Delete (int id) {
      try {
        return Ok (_service.Delete (id));
      } catch (Exception e) {
        return BadRequest (e.Message);
      }
    }
    //PUT
    [HttpPut ("{id}")]
    public ActionResult<Spell> Edit ([FromBody] Spell newSpell, int id) {
      try {
        newSpell.Id = id;
        return Ok (_service.Edit (newSpell));
      } catch (Exception e) {
        return BadRequest (e.Message);
      }
    }

  }
}