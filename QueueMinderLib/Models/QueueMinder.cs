using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QueueMinder.Domain.Models
{
    public class QueueMinder
    {
        public List<ManagedQueue> Queues;

        public QueueMinder()
        {
            Queues = new List<ManagedQueue>();
        }

        //@returns int - queue position of added member.
        public int AddMember(QueueMember qm)
        {
            if (Queues.All(q => q.Id != qm.QueueId))
            {
                throw new ApplicationException($"Queue with Id:{qm.QueueId} was not found.");
            }

            return Queues.FirstOrDefault(q => q.Id == qm.QueueId).AddMember(qm);

        }
        public void RemoveMember(int queueId, int memberId)
        {
            try
            {
                var queue = Queues.FirstOrDefault(q => q.Id == queueId);

                if (queue == null)
                {
                    throw new ApplicationException($"Queue #{queueId} was not found.");
                }
                else if (!queue.QueueMembers.Any(qm => qm.Id == memberId))
                {
                    throw new ApplicationException($"Member #{memberId} was not found in queue #{queueId}");
                }

                queue.RemoveMember(memberId);
                //.RemoveMember(m);
            }
            catch (Exception ex)
            {

            }
        }

        public int AddQueue(ManagedQueue queue)
        {
            Queues.Add(queue);
            return Queues.Count();
        }

        public async void ShowQueues()
        {
            var sb = new StringBuilder();

            foreach (var queue in Queues)
            {
                sb.AppendLine($"Queue: {queue.EventName}");

                queue.QueueMembers.ForEach(x =>
                {
                    sb.AppendLine($"{x.Forename} {x.Surname} {x.StartPosition} ({x.TelNo})");
                });
            }

            Console.Write(sb.ToString());
        }
    }

}