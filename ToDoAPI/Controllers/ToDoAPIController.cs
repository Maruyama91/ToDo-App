using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data;
using ToDoAPI.Models;
using Microsoft.AspNetCore.JsonPatch;


namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ToDoAPIController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public ToDoAPIController(TRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
        // Get method returns all the ToDo Tasks in the database.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/3
        // Get with parameter method returns The ToDo Task having the id given as input.
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var todo = await repository.Get(id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        // PUT: api/[controller]/3
        // Put method updates the Todo Task record with the given Id in the database.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }
            await repository.Update(todo);
            return NoContent();
        }

        // PATCH: api/[controller]/3
        // Patch method will update specify property field (IsComplete ToDo and PercentCompletion) from table into database.
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id,[FromBody]JsonPatchDocument<TEntity> ToDoPatch)
        {
            var data = await repository.Get(id);

            if ( data == null)
            {
                return NotFound();
            }

            ToDoPatch.ApplyTo(data);

            return NoContent();

        }

        // POST: api/[controller]
        // Post method will save new input JSON data into database.
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity todo)
        {
            await repository.Add(todo);
            return CreatedAtAction("Get", new { id = todo.Id }, todo);
        }

        // DELETE: api/[controller]/3
        // Delete method will delete based on id parameter.
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var todo = await repository.Delete(id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

    }

}
