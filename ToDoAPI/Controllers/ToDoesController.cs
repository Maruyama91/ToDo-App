using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;
using ToDoAPI.Data.EFCore;

namespace ToDoAPI.Controllers
{
    // Handle base controller which is ToDoAPIController 
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoesController : ToDoAPIController<ToDo, EfCoreToDoRepository>
    {
        public ToDoesController(EfCoreToDoRepository repository) : base(repository)
        {

        }
    }
}