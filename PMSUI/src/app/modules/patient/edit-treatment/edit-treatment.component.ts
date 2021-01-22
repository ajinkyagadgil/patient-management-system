import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-treatment',
  templateUrl: './edit-treatment.component.html',
  styleUrls: ['./edit-treatment.component.scss']
})
export class EditTreatmentComponent implements OnInit {
  treatmentInformationFormGroup: FormGroup;
  treatmentImages: File[];
  @Input() isChild: boolean;
  constructor(private _formBuilder: FormBuilder) { }

  ngOnInit() {
    this.initForm()
  }

  initForm() {
    this.treatmentInformationFormGroup = this._formBuilder.group({
      treatmentTitle: ['', Validators.required],
      treatmentSummary: [''],
      treatmentDate: ['', Validators.required],
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

}
