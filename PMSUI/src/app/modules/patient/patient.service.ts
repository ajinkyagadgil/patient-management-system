import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetPatientInformationModel } from 'src/app/models/patient/GetPatientInformationModel';
import { ApiService } from 'src/app/shared/api.service';
import { GetGenderInformationModel } from 'src/app/models/common/GetGenderInformationModel';

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
}
