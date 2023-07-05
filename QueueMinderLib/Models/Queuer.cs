using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueMinder.Domain.Interfaces;

namespace QueueMinder.Domain.Models
{
    public class QueueMember : BaseClass
    {
        public int QueueId { get; set; }
        public string? Forename { get; set; }
        public string? Surname { get; set; }
        public int StartPosition { get; set; }
        public string? TelNo { get; set; }

        public QueueMember()
        {
            Created = DateTime.Now;
        }
    }
}