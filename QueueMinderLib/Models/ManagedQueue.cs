using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueMinder.Domain.Interfaces;

namespace QueueMinder.Domain.Models
{
    public class ManagedQueue : BaseClass
    {
        public string EventName { get; set; }
        public List<QueueMember> QueueMembers { get; set; }
        //public System.Collections.Queue Members { get; set; }

        public int AddMember(QueueMember qm)
        {
            //Members.Enqueue(qm);
            qm.StartPosition = QueueMembers.Any() ? QueueMembers.Max(q => q.StartPosition) + 1 : 0;

            QueueMembers.Add(qm);
            return QueueMembers.Count();
        }

        public int RemoveMember(int id)
        {
            //Members.Dequeue();

            var qm = QueueMembers.Find(x => x.Id == id);

            if (qm == null)
            {
                throw new ApplicationException($"Member with Id:{id} was not found in Queue No. {Id}");
            }

            QueueMembers.Remove(qm);

            return QueueMembers.Count();
        }

        public ManagedQueue(string eventName)
        {
            EventName = eventName;
            QueueMembers = new List<QueueMember>();
            //Members = new System.Collections.Queue();
        }
    }
}
