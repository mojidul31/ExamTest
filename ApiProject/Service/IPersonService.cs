using ApiProject.Dto;
using ApiProject.Models;
using System.Collections.Generic;

namespace ApiProject.Service
{
    public interface IPersonService
    {
        bool AddEditPerson(int id, PersonDto person);
        bool DeletePerson(int id);
        List<PersonDto> GetAllPersons();
        PersonDto GetPerson(int id);
        List<PersonHistory> GetAllPersonHistory();
    }
}
