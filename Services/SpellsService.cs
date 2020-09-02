using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;

namespace burgershack.Services
{
  public class SpellsService
  {
    private readonly SpellsRepository _repo;
    public SpellsService(SpellsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Spell> Get()
    {
      return _repo.Get();
    }
    public Spell Get(int Id)
    {
      Spell exists = _repo.GetById(Id);
      if (exists == null) { throw new Exception("Invalid Spell ID"); }
      return exists;
    }

    public Spell Create(Spell newSpell)
    {
      int id = _repo.Create(newSpell);
      newSpell.Id = id;
      return newSpell;
    }

    public Spell Delete(int id)
    {
      Spell exists = Get(id);
      _repo.Delete(id);
      return exists;
    }

    public Spell Edit(Spell editSpell)
    {
      Spell original = Get(editSpell.Id);
      original.Name = editSpell.Name == null ? original.Name : editSpell.Name;
      return _repo.Edit(original);
    }
  }
}