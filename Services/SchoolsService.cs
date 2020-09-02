using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;

namespace burgershack.Services
{
  public class SchoolsService
  {
    private readonly SchoolsRepository _repo;
    public SchoolsService(SchoolsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<School> Get()
    {
      return _repo.Get();
    }
    public School Get(int Id)
    {
      School exists = _repo.GetById(Id);
      if (exists == null) { throw new Exception("Invalid School Id"); }
      return exists;
    }

    public School Create(School newSchool)
    {
      int id = _repo.Create(newSchool);
      newSchool.Id = id;
      return newSchool;
    }

    public School Delete(int id)
    {
      School exists = Get(id);
      _repo.Delete(id);
      return exists;
    }

    public School Edit(School editSchool)
    {
      School original = Get(editSchool.Id);
      original.Name = editSchool.Name == null ? original.Name : editSchool.Name;
      return _repo.Edit(original);
    }
  }
}