using System;
using System.Collections.Generic;
using System.Text;

namespace Patient.Core.Entities
{
    public class FileInformationEntity
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
        public DateTime CreationDate { get; set; }
        public byte[] FileData { get; set; }
    }
}
