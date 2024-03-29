using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PercobaanAPI1.Models;

namespace PercobaanAPI1.Controllers
{
    public class PersonController : Controller
    {
        private string __constr;
        public PersonController(IConfiguration configuration) 
        {
            __constr = configuration.GetConnectionString("WebApiDatabase");
        }
        public IActionResult Index() 
        {
            return View();
        }
        [HttpGet("api/person")]
        public ActionResult<Person> ListPerson()
        {
            PersonContext context = new PersonContext(this.__constr);
            List<Person> ListPerson = context.ListPerson();
            return Ok(ListPerson);
        }
        [HttpPost("api/person/create")]
        public IActionResult CreatePerson([FromBody] Person person) 
        {
            PersonContext context = new PersonContext(this.__constr);
            context.AddPerson(person);
            return Ok("Person added successfully");
        }
        [HttpPut("api/person/update/{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] Person person)
        {
            person.id_person = id;
            PersonContext context = new PersonContext(this.__constr);
            context.UpdatePerson(person);
            return Ok("Person update succesfully");
        }
        [HttpDelete("api/person/deleted/{id}")]
        public IActionResult DeletePerson(int id) 
        {
            PersonContext context = new PersonContext(this.__constr);
            context.DeletePerson(id);
            return Ok("Person delete successfully");
        }
    }
}
