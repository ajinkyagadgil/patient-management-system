using Microsoft.AspNetCore.Http;
using Patient.Core.Common.Enums;
using Patient.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Patient.Core.Helpers
{
    public class Fileuploader
    {
        public async Task<List<FileInformationEntity>> UploadFiles(List<IFormFile> files, FileUploadType fileUploadType, Guid id)
        {
            var fileInformationEntityList = new List<FileInformationEntity>();
            var imagesStoragePath = string.Empty;
            var basePath = string.Empty;
            if (fileUploadType == FileUploadType.Patient)
            {
                imagesStoragePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "PatientImages", id.ToString());
                basePath = "patient-images";
            }
            if (fileUploadType == FileUploadType.Treatment)
            {
                imagesStoragePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "TreatmentImages", id.ToString());
                basePath = "treatment-images";
            }

            if (!Directory.Exists(imagesStoragePath))
            {
                Directory.CreateDirectory(imagesStoragePath);
            }
            foreach (var file in files)
            {
                var fileName = string.Concat(Guid.NewGuid().ToString(), Path.GetExtension(file.FileName));
                string filePath = Path.Combine(imagesStoragePath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    var fileInformationEntity = new FileInformationEntity
                    {
                        Path = string.Concat(basePath,"/", id.ToString()),
                        Name = fileName,
                        Size = file.Length,
                        CreationDate = DateTime.Now,
                        Type = file.ContentType
                    };
                    fileInformationEntityList.Add(fileInformationEntity);
                }
            }
            return fileInformationEntityList;
        }
    }
}
