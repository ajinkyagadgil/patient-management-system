import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetPatientInformationModel } from 'src/app/models/patient/GetPatientInformationModel';
import { ApiService } from 'src/app/shared/api.service';
import { GetGenderInformationModel } from 'src/app/models/common/GetGenderInformationModel';
import { PostPatientInformationModel } from 'src/app/models/patient/PostPatientInformationModel';
import { PostTreatmentInformationModel } from 'src/app/models/treatment/PostTreatmentInformationModel';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private Api: ApiService) { }

  getAllPatients(): Observable<GetPatientInformationModel[]> {
    return this.Api.get("Patient/get/all")
  }

  getGender(): Observable<GetGenderInformationModel[]> {
    return this.Api.get("Common/genders")
  }

  savePatientInformation(patientInformation: GetPatientInformationModel, treatmentInformation: PostTreatmentInformationModel, patientPhoto: File): Observable<any> {
    let formData = new FormData();
    if(patientPhoto != null) {
      formData.append("patientPhoto", patientPhoto, patientPhoto.name)
    }
    formData.append("patientInformation", JSON.stringify(patientInformation));

    if(treatmentInformation.treatmentFiles.length > 0) {
      for(var i=0; i< treatmentInformation.treatmentFiles.length; i++) {
        formData.append("treatmentPhoto", treatmentInformation.treatmentFiles[i], treatmentInformation.treatmentFiles[i].name)
      }
      formData.append("treatmentInformation", JSON.stringify(treatmentInformation));
    }
    return this.Api.post("Patient/save", formData);
  }
}
