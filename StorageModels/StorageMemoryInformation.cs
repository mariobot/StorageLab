using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageModels
{
    public class StorageMemoryInformation
    {
        public string? ConnectionString { get; set; }
        public string? ContainerName { get; set; }
        public string? BlobName { get; set; }
    }
}
