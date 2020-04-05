using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Data
{
    // Interface for assign Id field as API primary key
    public interface IEntity
    {
        int Id { get; set; }

    }
}
