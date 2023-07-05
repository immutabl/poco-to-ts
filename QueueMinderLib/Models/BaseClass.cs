using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueMinder.Domain.Interfaces;

namespace QueueMinder.Domain.Models
{
    public abstract class BaseClass : IBaseClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
