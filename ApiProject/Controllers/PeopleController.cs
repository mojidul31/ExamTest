using Microsoft.AspNetCore.Mvc;
using ApiProject.Service;
using ApiProject.Dto;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {        
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {            
            _personService = personService;
        }

        // GET: api/People
        [HttpGet]
        public JsonResult GetPerson()
        {
            var personList = _personService.GetAllPersons();
            return new JsonResult(personList);
        }

        // GET: api/People/5
        [HttpGet("{id:int}")]
        public JsonResult GetPerson(int id)
        {
            var person = _personService.GetPerson(id);
            return new JsonResult(person);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public IActionResult PutPerson(int id, PersonDto person)
        {
            ResponseMessage response = new ResponseMessage();
            bool status = false;
            string message = "Invalid operation.";
            if (id != person.Id)
            {
                return BadRequest();
            }
            else
            {
                status = _personService.AddEditPerson(id, person);
                message = status ? "Data updated successfully." : "Failed to update.";
            }

            response.Status = status;
            response.Message = message;
            return new JsonResult(response);
        }

        // POST: api/People
        [HttpPost]
        public IActionResult PostPerson(PersonDto person)
        {
            ResponseMessage response = new ResponseMessage();
            bool status = false;
            string message = "Invalid operation.";
            if (person == null)
            {
                return BadRequest();
            }
            else
            {
                status = _personService.AddEditPerson(0, person);
                message = status ? "Data save successfully." : "Failed to save.";
            }

            response.Status = status;
            response.Message = message;
            return new JsonResult(response);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            ResponseMessage response = new ResponseMessage();
            bool status = false;
            string message = "Invalid operation.";
            if(id > 0)
            {
                status =_personService.DeletePerson(id);
                message = status ? "Data deleted successfully." : "Failed to delete.";
            }

            response.Status = status;
            response.Message = message;
            return new JsonResult(response);
        }

        // GET: api/People/history
        [HttpGet("{history}")]
        public JsonResult GetPersonHistory(string history)
        {
            var personList = _personService.GetAllPersonHistory();
            return new JsonResult(personList);
        }
    }
}
