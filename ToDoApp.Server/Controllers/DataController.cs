
using Microsoft.AspNetCore.Mvc;

using ToDoApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public DataController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetData")]


        public async Task<ActionResult<IEnumerable<Person>>> GetData()
        {
            if (_dbContext.People == null)
            {
                return NotFound();
            }
            return await _dbContext.People.ToListAsync();
        }

        [HttpGet("Getdata/{id}")]

        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            if (_dbContext == null)
            {
                return NotFound();

            }

            var person = await _dbContext.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }

        [HttpPost]
        [Route("GetData")]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _dbContext.People.Add(person);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        [HttpDelete("Getdata/{id}")]

        public async Task<ActionResult> DeletePerson(int id)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            var person = await _dbContext.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            _dbContext.People.Remove(person);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}