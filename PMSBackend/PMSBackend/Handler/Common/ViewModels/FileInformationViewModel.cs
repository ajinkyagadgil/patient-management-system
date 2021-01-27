using System;

namespace PMSBackend.Handler.Patient.ViewModels
{
    public class FileInformationViewModel
    {
        public Guid id { get; set; }
        public string path { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public long size { get; set; }
        public DateTime creationDate { get; set; }
    }
}
