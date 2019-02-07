using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            this._personService = personService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok(this._personService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Person person = this._personService.FindById(id);
            if (person == null)
                return this.NotFound();
            else
                return this.Ok();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return this.BadRequest();
            else
                return new ObjectResult(this._personService.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return this.BadRequest();
            else
                return new ObjectResult(this._personService.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._personService.Delete(id);
            return Ok();
        }
    }
}
