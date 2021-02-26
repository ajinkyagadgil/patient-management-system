import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetPatientInformationModel } from 'src/app/models/patient/GetPatientInformationModel';
import { ApiService } from 'src/app/shared/api.service';
import { GetGenderInformationModel } from 'src/app/models/common/GetGenderInformationModel';
import { PostPatientInformationModel } from 'src/app/models/patient/PostPatientInformationModel';
import { PostTreatmentInformationModel } from 'src/app/models/treatment/PostTreatmentInformationModel';
import { GetTreatmentInformationModel } from 'src/app/models/treatment/GetTreatmentInformationModel';
import { RecordInformationModel } from 'src/app/models/records/RecordInformationModel';
import { DateRangeModel } from 'src/app/models/records/DateRangeModel';

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

  savePatientAndTreatmentInformation(patientInformation: GetPatientInformationModel, treatmentInformation: PostTreatmentInformationModel, patientPhoto: File): Observable<any> {
    let formData = new FormData();
    if (patientPhoto != null) {
      formData.append("patientPhoto", patientPhoto, patientPhoto.name)
    }
    formData.append("patientInformation", JSON.stringify(patientInformation));

    if (treatmentInformation.treatmentFiles.length > 0) {
      for (var i = 0; i < treatmentInformation.treatmentFiles.length; i++) {
        formData.append("treatmentPhoto", treatmentInformation.treatmentFiles[i], treatmentInformation.treatmentFiles[i].name)
      }
      formData.append("treatmentInformation", JSON.stringify(treatmentInformation));
    }
    return this.Api.post("Patient/savePatientAndTreatment", formData);
  }

  savePatientInformation(patientInformation: PostPatientInformationModel): Observable<any> {
    let formData = new FormData();
    if (patientInformation.patientPhoto != null) {
      formData.append("patientPhoto", patientInformation.patientPhoto, patientInformation.patientPhoto.name);
    }
    formData.append("patientInformation", JSON.stringify(patientInformation));
    return this.Api.post("Patient/save", formData);
  }

  getPatientDetails(patientId: string): Observable<GetPatientInformationModel> {
    return this.Api.get(`Patient/get/${patientId}`);
  }

  getPatientTreatments(patientId: string): Observable<GetTreatmentInformationModel[]> {
    return this.Api.get(`Treatment/all/${patientId}`);
  }

  savePatientTreatment(treatmentInformation: PostTreatmentInformationModel): Observable<any> {
    let formData = new FormData();
    if (treatmentInformation.treatmentFiles?.length > 0) {
      for (var file = 0; file < treatmentInformation.treatmentFiles.length; file++) {
        formData.append("treatmentFiles", treatmentInformation.treatmentFiles[file], treatmentInformation.treatmentFiles[file].name)
      }
    }
    formData.append("treatmentInformation", JSON.stringify(treatmentInformation));
    return this.Api.post('Treatment/save', formData);
  }

  deletePatient(patientId: string): Observable<any> {
    return this.Api.delete(`Patient/delete/${patientId}`);
  }

  deleteTreatment(treatmentId: string): Observable<any> {
    return this.Api.delete(`Treatment/delete/${treatmentId}`);
  }

  getAllRecords(dateRange: DateRangeModel): Observable<RecordInformationModel[]> {
    return this.Api.post('Record/all', dateRange);
  }

  saveRecord(recordInformation: RecordInformationModel): Observable<any> {
    return this.Api.post('Record/save', recordInformation);
  }

  deleteRecord(recordId): Observable<any> {
    return this.Api.delete(`Record/delete/${recordId}`)
  }
}
