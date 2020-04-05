using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToDoAPI.Data;


namespace ToDoAPI.Models
{
    public class ToDo : IEntity
    {
        // Id field as primary key.
        public int Id { get; set; }

        //Title field with validation minimum string length 10 and maximum 60 also required field.
        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string Title { get; set; }

        //Description field with validation maximum string length 100 and regex for only text also required field.
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Description { get; set; }

        //Expire Date & Time field also required field.
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExpireDateTime { get; set; }

        //IsComplete field use for mark ToDo as Done, default value is FALSE.
        [DefaultValue(false)]
        public bool IsComplete { get; set; }

        //Percent Completion field with regex for only number minimum 1 digit and maximum 3 digit also required field.
        [Required]
        [RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "Invalid Number Format")]
        public int PercentCompletion { get; set; }

    }
}
