import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PatientService } from '../patient.service';
import { LoadingService } from 'src/app/shared/loading.service';
import { GetGenderInformationModel } from 'src/app/models/common/GetGenderInformationModel';
import { GuidModel } from 'src/app/models/common/GuidModel';
import { GetPatientInformationModel } from 'src/app/models/patient/GetPatientInformationModel';

@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.scss']
})
export class AddPatientComponent implements OnInit {
  postPatientInformation: GetPatientInformationModel = new GetPatientInformationModel();
  genders: GetGenderInformationModel[];
  patientInformationFormGroup: FormGroup;
  patientImage: File;
  @Input() isChild: boolean;
  @Input() isEdit: boolean;
  constructor(private _formBuilder: FormBuilder,
    private patientService: PatientService,
    private loading: LoadingService) { }

  ngOnInit() {
    this.loading.show();
    this.patientService.getGender().subscribe(res => {
      this.genders = res;

      this.initForm()
      this.loading.hide();
    })
  }

  initForm() {
    this.patientInformationFormGroup = this._formBuilder.group({
      id: [new GuidModel().Empty],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.email],
      age: ['', Validators.required],
      phone: ['', Validators.required],
      gender: ['', Validators.required],
      history: [''],
      caseNo: [''],
      photo: ['']
    });
  }

  onPatientPhotoChange(e) {
    const files = e.target.files;
    if (e.target.files == 0) {
      return
    }
    this.patientImage = files[0];
  }

  prepareToSendPatientInformation(): GetPatientInformationModel {
    let patientInformationFormData = this.patientInformationFormGroup.value;

    this.postPatientInformation.id = patientInformationFormData.id;
    this.postPatientInformation.firstName = patientInformationFormData.firstName;
    this.postPatientInformation.lastName = patientInformationFormData.lastName;
    this.postPatientInformation.age = patientInformationFormData.age;
    this.postPatientInformation.gender = patientInformationFormData.gender;
    this.postPatientInformation.email = patientInformationFormData.email;
    this.postPatientInformation.phone = patientInformationFormData.phone;
    this.postPatientInformation.history = patientInformationFormData.history;
    this.postPatientInformation.caseNo = patientInformationFormData.caseNo;
    return this.postPatientInformation;
  }
  
}
