using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageModels
{
    public class QueueInformation
    {
        public string? ConnectionString { get; set; }
        public string? QueueName { get; set; }
        public string? Message { get; set; }
    }
}
