using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Services;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class WizardsController : ControllerBase
  {
    private readonly WizardsService _service;
    private readonly SpellbooksService _isbs;
    public WizardsController(WizardsService service, SpellbooksService isbs)
    {
      _service = service;
      _isbs = isbs;
    }

    //GET
    [HttpGet]
    public ActionResult<IEnumerable<Wizard>> Get()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //GETBYID
    [HttpGet("{wizardId}")]
    public ActionResult<Wizard> Get(int wizardId)
    {
      try
      {
        return Ok(_service.Get(wizardId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{wizardId}/spells")]
    public ActionResult<SpellbookViewModel> GetSpellsByWizId(int wizardId)
    {
      try
      {
        return Ok(_isbs.GetSpellsByWizId(wizardId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //POST
    [HttpPost]
    public ActionResult<Wizard> Post([FromBody] Wizard newWizard)
    {
      try
      {
        return Ok(_service.Create(newWizard));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //DEL
    [HttpDelete("{id}")]
    public ActionResult<Wizard> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //PUT
    [HttpPut("{id}")]
    public ActionResult<Wizard> Edit([FromBody] Wizard newWizard, int id)
    {
      try
      {
        newWizard.Id = id;
        return Ok(_service.Edit(newWizard));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}