using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;

namespace burgershack.Services {
  public class SpellbooksService {

    private readonly SpellbooksRepository _repo;

    public SpellbooksService (SpellbooksRepository repo) {
      _repo = repo;
    }

    internal Spellbook Create (Spellbook newSpellbook) {
      int id = _repo.Create (newSpellbook);
      newSpellbook.Id = id;
      return newSpellbook;
    }

    internal IEnumerable<SpellbookViewModel> GetSpellsByWizId (int wizardId) {
      return _repo.GetSpellsByWizId (wizardId);
    }
    public Spellbook Get (int Id) {
      Spellbook exists = _repo.GetById (Id);
      if (exists == null) { throw new Exception ("Invalid Spell ID"); }
      return exists;
    }

    internal Spellbook Delete (int id) {
      Spellbook exists = Get (id);
      _repo.Delete (id);
      return exists;
    }
  }
}