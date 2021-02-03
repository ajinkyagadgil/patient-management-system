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
      gender: [this.data.patientInformation.gender == null ? null: this.data.patientInformation.gender, Validators.required],
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

  onSavePatientInformation() {
    this.loading.show();
    this.patientService.savePatientInformation(this.prepareToSendPatientInformation()).subscribe(res => {
      this.loading.hide();
      this.dialogRef.close(true);
    }, error => {})
  }

  prepareToSendPatientInformation(): PostPatientInformationModel {
    let patientInformationFormData = this.patientInformationFormGroup.value;

    let postPatientInformation = {
      id: patientInformationFormData.id,
      firstName: patientInformationFormData.firstName,
      lastName: patientInformationFormData.lastName,
      age: patientInformationFormData.age,
      gender: patientInformationFormData.gender,
      email: patientInformationFormData.email,
      phone: patientInformationFormData.phone,
      history: patientInformationFormData.history,
      caseNo: patientInformationFormData.caseNo,
      patientPhoto: this.patientImage != null ? this.patientImage : null
    };
    return postPatientInformation;
  }
  
}
