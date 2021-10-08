using ApiProject.Dto;
using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiProject.Service
{
    public class PersonService : IPersonService
    {
        private readonly CoreDbContext _context;
        public PersonService(CoreDbContext context)
        {
            _context = context;
        }

        public bool AddEditPerson(int id, PersonDto person)
        {
            bool result = false;
            Person personNew = new Person();
            if (id > 0)
            {
                try
                {
                    PersonHistory personHistory = this.GetEntityFromDto(id);
                    personHistory.OperationType = "Update";
                    _context.PersonHistory.Add(personHistory);
                    _context.SaveChanges();
                    if (personHistory.Id > 0)
                    {
                        personNew = _context.Persons.Find(id);
                        personNew.Name = person.Name;
                        personNew.PhoneNo = person.PhoneNo;
                        personNew.Email = person.Email;
                        _context.Persons.Update(personNew);
                        _context.SaveChanges();
                        result = true;
                    }
                }catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                try
                {
                    personNew.Name = person.Name;
                    personNew.PhoneNo = person.PhoneNo;
                    personNew.Email = person.Email;
                    personNew.CreateDateTime = DateTime.Now;
                    _context.Persons.Add(personNew);
                    _context.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return result;
        }

        public bool DeletePerson(int id)
        {
            bool result = false;
            Person personExis = _context.Persons.Find(id);
            if(personExis != null)
            {
                PersonHistory personHistory = new PersonHistory();
                personHistory.RefId = personExis.Id;
                personHistory.Name = personExis.Name;
                personHistory.PhoneNo = personExis.PhoneNo;
                personHistory.Email = personExis.Email;
                personHistory.CreateDateTime = personExis.CreateDateTime;
                personHistory.OperationType = "Delete";
                personHistory.UpdateDateTime = DateTime.Now;
                _context.PersonHistory.Add(personHistory);
                _context.SaveChanges();
                if(personHistory.Id > 0)
                {
                    _context.Persons.Remove(personExis);
                    _context.SaveChanges();
                    result = true;
                }                
            }
            return result;
        }

        public List<PersonDto> GetAllPersons()
        {
            List<PersonDto> list = new List<PersonDto>();
            List<Person> personList = _context.Persons.ToList();
            if(personList != null && personList.Any())
            {
                foreach(var person in personList)
                {
                    list.Add(new PersonDto
                    {
                        Id = person.Id,
                        Name = person.Name,
                        PhoneNo = person.PhoneNo,
                        Email = person.Email,
                        CreateDateTime = person.CreateDateTime
                    });
                }
            }
            if(list != null && list.Any())
            {
                list = list.OrderByDescending(x => x.Id).ToList();
            }
            return list;
        }

        public PersonDto GetPerson(int id)
        {
            PersonDto personDto = new PersonDto();
            Person person = _context.Persons.Find(id);
            if (person != null)
            {
                personDto.Id = person.Id;
                personDto.Name = person.Name;
                personDto.PhoneNo = person.PhoneNo;
                personDto.Email = person.Email;
                personDto.CreateDateTime = person.CreateDateTime;
            }
            return personDto;
        }

        public List<PersonHistory> GetAllPersonHistory()
        {
            List<PersonHistory> list = new List<PersonHistory>();
            list = _context.PersonHistory.ToList();
            if (list != null && list.Any())
            {
                list = list.OrderByDescending(x => x.Id).ToList();
            }
            return list;
        }

        private PersonHistory GetEntityFromDto(int personId)
        {
            PersonHistory personHistory = new PersonHistory();
            Person personOld = _context.Persons.Find(personId);
            if (personOld != null)
            {
                personHistory.RefId = personOld.Id;
                personHistory.Name = personOld.Name;
                personHistory.PhoneNo = personOld.PhoneNo;
                personHistory.Email = personOld.Email;
                personHistory.CreateDateTime = personOld.CreateDateTime;
                personHistory.UpdateDateTime = DateTime.Now;
            }
            return personHistory;
        }

    }
}
