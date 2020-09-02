using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;

namespace burgershack.Services {
  public class WizardsService {
    private readonly WizardsRepository _repo;
    public WizardsService (WizardsRepository wr) {
      _repo = wr;
    }

    public IEnumerable<Wizard> Get () {
      return _repo.Get ();
    }
    public Wizard Create (Wizard newWizard) {
      int id = _repo.Create (newWizard);
      newWizard.Id = id;
      return newWizard;
    }
    public Wizard Get (int wizardId) {
      Wizard exists = _repo.GetById (wizardId);
      if (exists == null) { throw new Exception ("Invalid Wizard ID"); }
      return exists;
    }

    public Wizard Delete (int id) {
      Wizard exists = Get (id);
      _repo.Delete (id);
      return exists;
    }

    public Wizard Edit (Wizard editWizard) {
      Wizard original = Get (editWizard.Id);
      original.Name = editWizard.Name == null ? original.Name : editWizard.Name;
      return _repo.Edit (original);
    }
  }
}