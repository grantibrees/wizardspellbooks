using System;
using System.Collections.Generic;
using System.Data;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories {
  public class WizardsRepository {
    private readonly IDbConnection _db;
    public WizardsRepository (IDbConnection db) {
      _db = db;
    }
    internal IEnumerable<Wizard> Get () {
      string sql = "SELECT * FROM wizards";
      return _db.Query<Wizard> (sql);
    }

    internal Wizard GetById (int wizardId) {
      string sql = "SELECT * FROM wizards WHERE id = @wizardId";
      return _db.QueryFirstOrDefault<Wizard> (sql, new { wizardId });
    }

    internal int Create (Wizard newWizard) {
      string sql = @"
        INSERT INTO wizards
        (description, name, price)
        VALUES
        (@Description, @Name, @Price);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int> (sql, newWizard);
    }

    internal void Delete (int Id) {
      string sql = "DELETE FROM wizards WHERE id = @Id";
      _db.Execute (sql, new { Id });
    }

    internal Wizard Edit (Wizard original) {
      string sql = @"
        UPDATE wizards
        SET
            name = @Name,
            description = @Description,
            price = @Price
        WHERE id = @Id;
        SELECT * FROM wizards WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Wizard> (sql, original);
    }
  }
}