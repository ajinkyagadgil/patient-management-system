using System;

namespace Patient.Core.Entities.Common
{
    public class FileInformationEntity
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
