import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LoadingService } from 'src/app/shared/loading.service';
import { PatientService } from '../../patient.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { RecordInformationModel } from 'src/app/models/records/RecordInformationModel';
import { GuidModel } from 'src/app/models/common/GuidModel';
import { GetPatientInformationModel } from 'src/app/models/patient/GetPatientInformationModel';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { ToasterService } from 'src/app/modules/shared/toaster.service';

@Component({
  selector: 'app-edit-record',
  templateUrl: './edit-record.component.html',
  styleUrls: ['./edit-record.component.scss']
})
export class EditRecordComponent implements OnInit {
  patientInformation: GetPatientInformationModel[];
  recordInformationFormGroup: FormGroup;
  dialogTitle: string
  filteredOptions: Observable<GetPatientInformationModel[]>;
  constructor(private _fb: FormBuilder,
    private loading: LoadingService,
    private patientService: PatientService,
    @Inject(MAT_DIALOG_DATA) public recordInformation: RecordInformationModel,
    public dialogRef: MatDialogRef<EditRecordComponent>,
    private toasterService: ToasterService) { }

  ngOnInit() {
    this.loading.show();
    if (this.recordInformation.id == new GuidModel().Empty) {
      this.dialogTitle = 'Add Record'
    }
    else {
      this.dialogTitle = 'Edit Dialog'
    }
    this.patientService.getAllPatients().subscribe(res => {
      this.patientInformation = res;
      this.initForm();
      this.filteredOptions = this.recordInformationFormGroup.get('patient').valueChanges
        .pipe(
          startWith(''),
          map(value => typeof value === 'string' ? value : value.patient),
          map(patient => patient ? this._filter(patient) : this.patientInformation.slice())
        );
      this.loading.hide();
    }, error => {
      this.toasterService.error("Failed", error.error);
      this.loading.hide();
      this.dialogRef.close(false);
    })
  }

  private _filter(value: any): GetPatientInformationModel[] {
    const filterValue = value.toLowerCase();

    return this.patientInformation.filter(option => option.firstName.toLowerCase().includes(filterValue) || option.lastName.toLowerCase().includes(filterValue));
  }

  initForm() {
    this.recordInformationFormGroup = this._fb.group({
      id: [this.recordInformation.id],
      patient: [this.recordInformation.patientInformation == null ? null : this.recordInformation.patientInformation, Validators.required],
      date: [this.recordInformation.recordDate == null ? new Date() : new Date(this.recordInformation.recordDate), [Validators.required]],
      treatment: [this.recordInformation.treatment, [Validators.required]],
      amount: [this.recordInformation.amount, [Validators.required, Validators.pattern("^[0-9*]+$")]]
    })
  }

  onSaveRecordInformation() {
    if (this.recordInformationFormGroup.invalid) {
      Object.keys(this.recordInformationFormGroup.controls).forEach(field => {
        const control = this.recordInformationFormGroup.get(field);
        control.markAsTouched({ onlySelf: true });
      });
      this.toasterService.warning("Warning", "There are errors in the form")
    }
    else {
      this.loading.show();
      this.patientService.saveRecord(this.prepareToSendRecordInformation()).subscribe(() => {
        this.loading.hide();
        this.toasterService.success("Success", "Changes saved");
        this.dialogRef.close(true);
      }, error => {
        this.toasterService.error("Failed", error.error);
        this.loading.hide();
      }
      )
    }
  }

  displayFn(patient: GetPatientInformationModel): string {
    return patient && patient.id != new GuidModel().Empty ? patient.firstName + ' ' + patient.lastName : null;
  }

  prepareToSendRecordInformation() {
    let recordInformationFormData = this.recordInformationFormGroup.value

    let postRecordInformation: RecordInformationModel = {
      id: recordInformationFormData.id,
      patientId: recordInformationFormData.patient.id,
      treatment: recordInformationFormData.treatment,
      amount: Number(recordInformationFormData.amount),
      recordDate: this.formatDate(recordInformationFormData.date),
      patientInformation: recordInformationFormData.patient

    };
    return postRecordInformation;
  }

  formatDate(date: Date) {
    var offsetMs = date.getTimezoneOffset() * 60000;
    return new Date(date.getTime() - offsetMs);
  }
}
