import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PatientService } from '../../patient.service';
import { GetGenderInformationModel } from 'src/app/models/common/GetGenderInformationModel';
import { PostTreatmentInformationModel } from 'src/app/models/patient/PostTreatmentInformationModel';
import { GetPatientInformationModel } from 'src/app/models/patient/GetPatientInformationModel';
import { GuidModel } from 'src/app/models/common/GuidModel';
import { LoadingService } from 'src/app/shared/loading.service';

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
  postPatientInformation: GetPatientInformationModel = new GetPatientInformationModel();
  patientImage: File;
  treatmentImages: File[];

  constructor(public dialogRef: MatDialogRef<EditPatientComponent>,
    private _formBuilder: FormBuilder,
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
    this.treatmentInformationFormGroup = this._formBuilder.group({
      treatmentTitle: ['', Validators.required],
      treatmentSummary: [''],
      treatmentDate: ['', Validators.required],
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
    this.loading.show();
    this.patientImage = this.patientImage != null ? this.patientImage: null;
    this.patientService.savePatientInformation(this.prepareToSendPatientInformation(), this.prepareToSendTreatmentInformation(), this.patientImage).subscribe(res=> {
      let a = res;
      this.loading.hide();
    })
    
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

  prepareToSendTreatmentInformation(): PostTreatmentInformationModel {
    let treatmentInformationFormData = this.treatmentInformationFormGroup.value;

    this.postTreatmentInformation.title = treatmentInformationFormData.treatmentTitle;
    this.postTreatmentInformation.summary = treatmentInformationFormData.treatmentSummary;
    this.postTreatmentInformation.treatmentDate = treatmentInformationFormData.treatmentDate,
    this.postTreatmentInformation.treatmentPhoto = this.treatmentImages;
    return this.postTreatmentInformation;
  }
}
