using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.BL.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; } 
    }
}
