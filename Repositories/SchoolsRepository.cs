using System;
using System.Collections.Generic;
using System.Data;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories {
  public class SchoolsRepository {
    private readonly IDbConnection _db;
    public SchoolsRepository (IDbConnection db) {
      _db = db;
    }
    internal IEnumerable<School> Get () {
      string sql = "SELECT * FROM schools";
      return _db.Query<School> (sql);
    }

    internal School GetById (int Id) {
      string sql = "SELECT * FROM schools WHERE id = @Id";
      return _db.QueryFirstOrDefault<School> (sql, new { Id });
    }

    internal int Create (School newSchool) {
      string sql = @"
        INSERT INTO schools
        (name)
        VALUES
        (@Name);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int> (sql, newSchool);
    }

    internal void Delete (int Id) {
      string sql = "DELETE FROM schools WHERE id = @Id";
      _db.Execute (sql, new { Id });
    }

    internal School Edit (School original) {
      string sql = @"
        UPDATE schools
        SET
            name = @Name,
        WHERE id = @Id;
        SELECT * FROM schools WHERE id = @Id;";
      return _db.QueryFirstOrDefault<School> (sql, original);
    }
  }
}