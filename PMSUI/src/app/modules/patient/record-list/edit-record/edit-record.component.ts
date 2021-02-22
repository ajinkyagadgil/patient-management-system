import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LoadingService } from 'src/app/shared/loading.service';
import { PatientService } from '../../patient.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RecordInformationModel } from 'src/app/models/records/RecordInformationModel';
import { GuidModel } from 'src/app/models/common/GuidModel';
import { GetPatientInformationModel } from 'src/app/models/patient/GetPatientInformationModel';

@Component({
  selector: 'app-edit-record',
  templateUrl: './edit-record.component.html',
  styleUrls: ['./edit-record.component.scss']
})
export class EditRecordComponent implements OnInit {
  patientInformation: GetPatientInformationModel[];
  recordInformationFormGroup: FormGroup;
  dialogTitle: string
  constructor(private _fb: FormBuilder,
    private loading: LoadingService,
    private patientService: PatientService,
    @Inject(MAT_DIALOG_DATA) public recordInformation: RecordInformationModel,) { }

  ngOnInit() {
    this.loading.show();
    if(this.recordInformation.id == new GuidModel().Empty) {
      this.dialogTitle = 'Add Record'
    }
    else{
      this.dialogTitle = 'Edit Dialog'
    }
    this.patientService.getAllPatients().subscribe(res => {
      this.patientInformation = res;
      this.initForm();
      this.loading.hide();
    })
  }

  initForm() {
    this.recordInformationFormGroup = this._fb.group({
      id: [this.recordInformation.id],
      patient: [this.recordInformation.patientInformation == null ? null : this.recordInformation.patientInformation, Validators.required],
      date: [this.recordInformation.recordDate == null ? new Date() : new Date(this.recordInformation.recordDate), [Validators.required]],
      treatment: [this.recordInformation.treatment, [Validators.required]],
      amount: [this.recordInformation.amount, [Validators.required]]
    })
  }

  onSaveRecordInformation() {

  }

  displayFn(patient: GetPatientInformationModel): string {
    debugger;
    return patient && patient.id != new GuidModel().Empty ? patient.firstName + ' ' + patient.lastName : null;
  }

}
