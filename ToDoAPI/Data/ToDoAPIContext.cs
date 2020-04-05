using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Models
{
    // Context class generate from EF Scaffolding
    public class ToDoAPIContext : DbContext
    {
        public ToDoAPIContext (DbContextOptions<ToDoAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoAPI.Models.ToDo> ToDo { get; set; }
    }
}
