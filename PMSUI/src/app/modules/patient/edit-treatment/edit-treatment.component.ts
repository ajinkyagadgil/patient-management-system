import { Component, OnInit, Input, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GetTreatmentInformationModel } from 'src/app/models/treatment/GetTreatmentInformationModel';
import { GuidModel } from 'src/app/models/common/GuidModel';

@Component({
  selector: 'app-edit-treatment',
  templateUrl: './edit-treatment.component.html',
  styleUrls: ['./edit-treatment.component.scss']
})
export class EditTreatmentComponent implements OnInit {  
  treatmentInformationFormGroup: FormGroup;
  treatmentImages: File[];
  dialogTitle: string;
  @Input() isChild: boolean;
  constructor(private _formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public treatmentInformation: GetTreatmentInformationModel,) { }

  ngOnInit() {
    if(this.treatmentInformation.id == new GuidModel().Empty){
      this.dialogTitle = 'Add Treatment'
    }
    else{
      this.dialogTitle = 'Edit Treatment'
    }
    this.initForm()
  }

  initForm() {
    this.treatmentInformationFormGroup = this._formBuilder.group({
      id: [this.treatmentInformation.id],
      treatmentTitle: [this.treatmentInformation.title == null ? null : this.treatmentInformation.title, Validators.required],
      treatmentSummary: [this.treatmentInformation.summary == null ? null : this.treatmentInformation.summary],
      treatmentDate: [this.treatmentInformation.treatmentDate == null ? null : this.treatmentInformation.treatmentDate, Validators.required],
      treatmentImage: ['']
    });
  }

  onTreatmentImageChange(e) {
    debugger;
    const files: File[] = e.target.files;
    if (e.target.files == 0) {
      return
    }
    this.treatmentImages = files;
  }

  onSaveTreatmentInformation(){
    
  }

}
