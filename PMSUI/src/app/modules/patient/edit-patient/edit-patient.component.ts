import { Component, OnInit, Input, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PatientService } from '../patient.service';
import { LoadingService } from 'src/app/shared/loading.service';
import { GetGenderInformationModel } from 'src/app/models/common/GetGenderInformationModel';
import { GuidModel } from 'src/app/models/common/GuidModel';
import { GetPatientInformationModel } from 'src/app/models/patient/GetPatientInformationModel';
import { PostPatientInformationModel } from 'src/app/models/patient/PostPatientInformationModel';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PatientDialogModel } from 'src/app/models/patient/PatientDialogModel';
import { AppconfigService } from 'src/app/shared/appconfig.service';

@Component({
  selector: 'app-edit-patient',
  templateUrl: './edit-patient.component.html',
  styleUrls: ['./edit-patient.component.scss']
})
export class EditPatientComponent implements OnInit {
  public dialogTitle: string;
  postPatientInformation: PostPatientInformationModel
  genders: GetGenderInformationModel[];
  patientInformationFormGroup: FormGroup;
  patientImage: File;
  apiUrl: string;
  public imageUrl: string

  constructor(private _formBuilder: FormBuilder,
    private patientService: PatientService,
    private loading: LoadingService,
    private appConfigService: AppconfigService,
    public dialogRef: MatDialogRef<EditPatientComponent>,
    @Inject(MAT_DIALOG_DATA) public data: PatientDialogModel,) { }

  ngOnInit() {
    this.loading.show();
    this.apiUrl = this.appConfigService.apiBaseUrl
    if(this.data.patientInformation.id == new GuidModel().Empty){
      this.dialogTitle = "Add Patient"
      this.imageUrl = null;
    }
    else{
      this.dialogTitle = "Edit Patient"
      if(this.data.patientInformation.patientPhotoInformation != null) {
        this.imageUrl = `${this.apiUrl}${this.data.patientInformation.patientPhotoInformation.path}/${this.data.patientInformation.patientPhotoInformation.name}`
      }
      else{
        this.imageUrl = null;
      }
    }
    this.patientService.getGender().subscribe(res => {
      this.genders = res;

      this.initForm()
      this.loading.hide();
      console.log(JSON.stringify(this.data))
    })
  }

  initForm() {
    this.patientInformationFormGroup = this._formBuilder.group({
      id: [this.data.patientInformation.id],
      firstName: [this.data.patientInformation.firstName == null ? null: this.data.patientInformation.firstName, [Validators.required, Validators.maxLength(10)]],
      lastName: [this.data.patientInformation.lastName == null ? null: this.data.patientInformation.lastName, Validators.required],
      email: [this.data.patientInformation.email == null ? null: this.data.patientInformation.email, Validators.email],
      age: [this.data.patientInformation.age == null ? null: this.data.patientInformation.age, Validators.required],
      phone: [this.data.patientInformation.phone == null ? null: this.data.patientInformation.phone, Validators.required],
      gender: [this.data.patientInformation.gender?.id == null ? null: this.data.patientInformation.gender.id, Validators.required],
      history: [this.data.patientInformation.history == null ? null: this.data.patientInformation.history],
      caseNo: [this.data.patientInformation.caseNo == null ? null: this.data.patientInformation.caseNo],
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

  onDialogClose() {
    this.dialogRef.close();
  }

  prepareToSendPatientInformation(): PostPatientInformationModel {
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
