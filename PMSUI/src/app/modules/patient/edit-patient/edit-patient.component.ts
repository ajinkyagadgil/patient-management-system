import { Component, OnInit, Input, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PatientService } from '../patient.service';
import { LoadingService } from 'src/app/shared/loading.service';
import { GetGenderInformationModel } from 'src/app/models/common/GetGenderInformationModel';
import { GuidModel } from 'src/app/models/common/GuidModel';
import { GetPatientInformationModel } from 'src/app/models/patient/GetPatientInformationModel';
import { PostPatientInformationModel } from 'src/app/models/patient/PostPatientInformationModel';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AppconfigService } from 'src/app/shared/appconfig.service';
import { ToasterService } from '../../shared/toaster.service';

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
    @Inject(MAT_DIALOG_DATA) public patientInformation: GetPatientInformationModel,
    private toasterService: ToasterService) { }

  ngOnInit() {
    this.loading.show();
    this.apiUrl = this.appConfigService.apiBaseUrl
    if (this.patientInformation.id == new GuidModel().Empty) {
      this.dialogTitle = "Add Patient"
      this.imageUrl = null;
    }
    else {
      this.dialogTitle = "Edit Patient"
      if (this.patientInformation.patientPhotoInformation != null) {
        this.imageUrl = `${this.apiUrl}${this.patientInformation.patientPhotoInformation.path}/${this.patientInformation.patientPhotoInformation.name}`
      }
      else {
        this.imageUrl = null;
      }
    }
    this.patientService.getGender().subscribe(res => {
      this.genders = res;
      this.initForm()
      this.loading.hide();
    }, error => {
      this.toasterService.error("Failed", error.error);
      this.loading.hide();
    })
  }

  initForm() {
    this.patientInformationFormGroup = this._formBuilder.group({
      id: [this.patientInformation.id],
      firstName: [this.patientInformation.firstName == null ? null : this.patientInformation.firstName, [Validators.required, Validators.maxLength(10)]],
      lastName: [this.patientInformation.lastName == null ? null : this.patientInformation.lastName, Validators.required],
      email: [this.patientInformation.email == null ? null : this.patientInformation.email, Validators.email],
      age: [this.patientInformation.age == null ? null : this.patientInformation.age, [Validators.required, Validators.pattern("^[0-9*]+$")]],
      phone: [this.patientInformation.phone == null ? null : this.patientInformation.phone, [Validators.required, Validators.pattern("^[0-9*-+,]+$")]],
      gender: [this.patientInformation.gender == null ? null : this.patientInformation.gender, Validators.required],
      history: [this.patientInformation.history == null ? null : this.patientInformation.history],
      caseNo: [this.patientInformation.caseNo == null ? null : this.patientInformation.caseNo],
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
    if (this.patientInformationFormGroup.invalid) {
      Object.keys(this.patientInformationFormGroup.controls).forEach(field => {
        const control = this.patientInformationFormGroup.get(field);
        control.markAsTouched({ onlySelf: true });
      });
      this.toasterService.warning("Warning", "There are errors in the form");
    }
    else {
      this.loading.show();
      this.patientService.savePatientInformation(this.prepareToSendPatientInformation()).subscribe(() => {
        this.loading.hide();
        this.toasterService.success("Sucess", "Changes Saved")
        this.dialogRef.close(true);
      }, error => {
        this.toasterService.error("Failed", error.error);
        this.loading.hide();
       })
    }
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
