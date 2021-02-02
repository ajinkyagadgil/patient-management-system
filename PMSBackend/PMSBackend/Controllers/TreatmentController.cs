﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMSBackend.Handler.Patient.ViewModels;
using PMSBackend.Handler.Treatment;
using PMSBackend.Handler.Treatment.ViewModels;
using System;
using System.Threading.Tasks;

namespace PMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentHandler _treatmentHandler;
        public TreatmentController(ITreatmentHandler treatmentHandler)
        {
            _treatmentHandler = treatmentHandler;
        }

        [Route("all/{patientId}")]
        [HttpGet]
        public async Task<IActionResult> GetPatientTreatments([FromRoute]Guid patientId)
        {
            return Ok(await _treatmentHandler.GetPatientTreatments(patientId));
        }

        public async Task<IActionResult> SavePatientTreatment([FromForm]TreatmentInformationFormDataViewModel treatmentInformationFormDataViewModel )
        {
            var treatmentInformation = JsonConvert.DeserializeObject<PostTreatmentInformationViewModel>(treatmentInformationFormDataViewModel.treatmentInformation);
            treatmentInformation.treatmentFiles = treatmentInformationFormDataViewModel.treatmentFiles;
            await _treatmentHandler.SavePatientTreatment(treatmentInformation);
            return Ok();
        }
    }
}