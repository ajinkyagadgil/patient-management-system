import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PatientService } from '../../patient.service';
import { GetGenderInformationModel } from 'src/app/models/common/GetGenderInformationModel';
import { PostTreatmentInformationModel } from 'src/app/models/patient/PostTreatmentInformationModel';
import { PostPatientInformationModel } from 'src/app/models/patient/PostPatientInformationModel';

@Component({
  selector: 'app-edit-patient',
  templateUrl: './edit-patient.component.html',
  styleUrls: ['./edit-patient.component.scss']
})
export class EditPatientComponent implements OnInit {
  genders: GetGenderInformationModel[];
  patientInformationFormGroup: FormGroup;
  treatmentInformationFormGroup: FormGroup;
  postTreatmentInformation: PostTreatmentInformationModel = new PostTreatmentInformationModel();
  postPatientInformation: PostPatientInformationModel = new PostPatientInformationModel();
  patientImage: File;
  treatmentImages: File[];

  constructor(public dialogRef: MatDialogRef<EditPatientComponent>,
    private _formBuilder: FormBuilder,
    private patientService: PatientService) { }

  ngOnInit() {
    this.patientService.getGender().subscribe(res => {
      this.genders = res;

      this.initForm()
    })
  }

  initForm() {
    this.patientInformationFormGroup = this._formBuilder.group({
      id: [''],
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
    this.treatmentInformationFormGroup = this._formBuilder.group({
      treatmentTitle: ['', Validators.required],
      treatmentSummary: [''],
      treatmentImage: ['']
    });
  }

  OnCancel() {
    this.dialogRef.close();
  }

  onPatientPhotoChange(e) {
    const files = e.target.files;
    if (e.target.files == 0) {
      return
    }
    this.patientImage = files[0];
  }

  onTreatmentImageChange(e) {
    debugger;
    const files: File[] = e.target.files;
    if (e.target.files == 0) {
      return
    }
    this.treatmentImages = files;
  }

  onSubmit() {
    let patientInformation = this.prepareToSendPatientInformation();
    let treatmentInformation = this.prepareToSendTreatmentInformation();
    this.patientService.savePatientInformation(this.prepareToSendPatientInformation(), this.prepareToSendTreatmentInformation()).subscribe(res=> {
      let a = res;
    })
    
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
    this.postPatientInformation.photo = this.patientImage != null ? this.patientImage : null;
    return this.postPatientInformation;
  }

  prepareToSendTreatmentInformation(): PostTreatmentInformationModel {
    let treatmentInformationFormData = this.treatmentInformationFormGroup.value;

    this.postTreatmentInformation.title = treatmentInformationFormData.treatmentTitle;
    this.postTreatmentInformation.summary = treatmentInformationFormData.treatmentSummary;
    this.postTreatmentInformation.treatmentPhoto = this.treatmentImages;
    return this.postTreatmentInformation;
  }
}
