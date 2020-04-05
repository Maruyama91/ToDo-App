using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Models;

namespace ToDoAPI.Data.EFCore
{
    public class EfCoreToDoRepository : EfCoreRepository<ToDo, ToDoAPIContext>
    {
        public EfCoreToDoRepository(ToDoAPIContext context) : base(context)
        {

        }
    }
}
