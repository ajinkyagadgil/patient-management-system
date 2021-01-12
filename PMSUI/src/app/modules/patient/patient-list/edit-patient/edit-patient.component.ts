import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-patient',
  templateUrl: './edit-patient.component.html',
  styleUrls: ['./edit-patient.component.scss']
})
export class EditPatientComponent implements OnInit {
  patientInformationFormGroup: FormGroup;
  treatmentInformationFormGroup: FormGroup;
  constructor(public dialogRef: MatDialogRef<EditPatientComponent>,
    private _formBuilder: FormBuilder) { }

  ngOnInit() {
    this.initForm()
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
      photo: ['']
    });
  }

}
