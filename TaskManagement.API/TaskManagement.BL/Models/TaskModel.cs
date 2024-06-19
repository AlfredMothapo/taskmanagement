using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.BL.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public  string Title { get; set; } = string.Empty;
        public string? Description { get; set; } 
    }
}
