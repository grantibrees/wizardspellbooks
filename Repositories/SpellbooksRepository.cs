using System;
using System.Collections.Generic;
using System.Data;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories {
  public class SpellbooksRepository {
    private readonly IDbConnection _db;

    public SpellbooksRepository (IDbConnection db) {
      _db = db;
    }

    internal int Create (Spellbook newSpellbook) {
      string sql = @"
        INSERT INTO spellbooks
        (wizardId, spellId)
        VALUES
        (@WizardId, @SpellId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int> (sql, newSpellbook);
    }

    internal IEnumerable<SpellbookViewModel> GetSpellsByWizId (int wizardId) {
      string sql = @"
        SELECT 
            spells.*,
            spellbooks.id as wizardIngId
        FROM spellbooks
        INNER JOIN spells ON spells.id = spellbooks.spellId 
        WHERE(spellbooks.wizardId = @wizardId)";
      return _db.Query<SpellbookViewModel> (sql, new { wizardId });
    }

    //this way uses aliasing on the table names
    // internal IEnumerable<SpellbookViewModel> GetSpellsByWizId(int wizardId)
    // {
    //   string sql = @"
    //     SELECT 
    //         i.*,
    //         ti.id as wizardIngId,
    //         t.name as wizardName
    //     FROM spellbooks ti
    //     INNER JOIN spells i ON i.id = ti.spellId 
    //     INNER JOIN wizards t on t.id = ti.wizardId
    //     WHERE(ti.wizardId = @wizardId)";
    //   return _db.Query<SpellbookViewModel>(sql, new { wizardId });
    // }

    internal Spellbook GetById (int id) {
      string sql = "SELECT * FROM spellbooks WHERE id = @Id";
      return _db.QueryFirstOrDefault<Spellbook> (sql, new { id });
    }

    internal void Delete (int id) {
      string sql = "DELETE FROM spellbooks WHERE id = @Id";
      _db.Execute (sql, new { id });

    }
  }
}