using System;
using System.Collections.Generic;
using System.Data;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories {
  public class SpellsRepository {
    private readonly IDbConnection _db;
    public SpellsRepository (IDbConnection db) {
      _db = db;
    }
    internal IEnumerable<Spell> Get () {
      string sql = "SELECT * FROM spells";
      return _db.Query<Spell> (sql);
    }

    internal Spell GetById (int Id) {
      string sql = "SELECT * FROM spells WHERE id = @Id";
      return _db.QueryFirstOrDefault<Spell> (sql, new { Id });
    }

    internal int Create (Spell newSpell) {
      string sql = @"
        INSERT INTO spells
        (name)
        VALUES
        (@Name);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int> (sql, newSpell);
    }

    internal void Delete (int Id) {
      string sql = "DELETE FROM spells WHERE id = @Id";
      _db.Execute (sql, new { Id });
    }

    internal Spell Edit (Spell original) {
      string sql = @"
        UPDATE spells
        SET
            name = @Name,
        WHERE id = @Id;
        SELECT * FROM spells WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Spell> (sql, original);
    }
  }
}