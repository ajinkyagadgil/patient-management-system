import { Component, OnInit, Input, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { GetTreatmentInformationModel } from 'src/app/models/treatment/GetTreatmentInformationModel';
import { GuidModel } from 'src/app/models/common/GuidModel';
import { LoadingService } from 'src/app/shared/loading.service';
import { PostTreatmentInformationModel } from 'src/app/models/treatment/PostTreatmentInformationModel';
import { PatientService } from '../patient.service';
import { AppconfigService } from 'src/app/shared/appconfig.service';
import { ToasterService } from '../../shared/toaster.service';
// import * as moment from 'moment';

@Component({
  selector: 'app-edit-treatment',
  templateUrl: './edit-treatment.component.html',
  styleUrls: ['./edit-treatment.component.scss']
})
export class EditTreatmentComponent implements OnInit {
  treatmentInformationFormGroup: FormGroup;
  treatmentFiles: File[];
  dialogTitle: string;
  @Input() isChild: boolean;
  constructor(private _formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public treatmentInformation: GetTreatmentInformationModel,
    public dialogRef: MatDialogRef<EditTreatmentComponent>,
    private loading: LoadingService,
    private patientService: PatientService,
    private appConfigService: AppconfigService,
    private toasterService: ToasterService) { }

  ngOnInit() {
    this.loading.show();
    if (this.treatmentInformation.id == new GuidModel().Empty) {
      this.dialogTitle = 'Add Treatment'
    }
    else {
      this.dialogTitle = 'Edit Treatment'
    }
    this.initForm();
    this.loading.hide();
  }

  initForm() {
    this.treatmentInformationFormGroup = this._formBuilder.group({
      id: [this.treatmentInformation.id],
      treatmentTitle: [this.treatmentInformation.title == null ? null : this.treatmentInformation.title, [Validators.required]],
      treatmentSummary: [this.treatmentInformation.summary == null ? null : this.treatmentInformation.summary],
      treatmentDate: [this.treatmentInformation.treatmentDate == null ? null : new Date(this.treatmentInformation.treatmentDate), [Validators.required]],
      treatmentImage: ['']
    });
  }

  onTreatmentImageChange(e) {
    const files: File[] = e.target.files;
    if (e.target.files == 0) {
      return
    }
    this.treatmentFiles = files;
  }

  onSaveTreatmentInformation() {
    if (this.treatmentInformationFormGroup.invalid) {
      Object.keys(this.treatmentInformationFormGroup.controls).forEach(field => {
        const control = this.treatmentInformationFormGroup.get(field);
        control.markAsTouched({ onlySelf: true });
      });
      this.toasterService.warning("Warning", "There are errors in the form")
    }
    else {
      this.loading.show();
      this.patientService.savePatientTreatment(this.prepareToSendTreatmentInformation()).subscribe(() => {
        this.loading.hide();
        this.toasterService.success("Success", "Changes saved");
        this.dialogRef.close(true);
      }, error => {
        this.toasterService.error("Failed", error.error);
        this.loading.hide();
      })
    }
  }

  prepareToSendTreatmentInformation(): PostTreatmentInformationModel {
    let treatmentInformationFormData = this.treatmentInformationFormGroup.value;

    let postPatientInformation: PostTreatmentInformationModel = {
      id: treatmentInformationFormData.id,
      title: treatmentInformationFormData.treatmentTitle,
      summary: treatmentInformationFormData.treatmentSummary,
      patientId: this.treatmentInformation.patientId,
      treatmentDate: this.formatDate(treatmentInformationFormData.treatmentDate),
      treatmentFiles: this.treatmentFiles == null ? null : this.treatmentFiles
    };
    return postPatientInformation;
  }

  formatDate(treatmentDate: Date) {
    var offsetMs = treatmentDate.getTimezoneOffset() * 60000;
    return new Date(treatmentDate.getTime() - offsetMs);
  }
}
