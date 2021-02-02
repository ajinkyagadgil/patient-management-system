import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from '../patient.service';
import { GetPatientInformationModel } from 'src/app/models/patient/GetPatientInformationModel';
import { GetTreatmentInformationModel } from 'src/app/models/treatment/GetTreatmentInformationModel';
import { LoadingService } from 'src/app/shared/loading.service';
import { forkJoin } from 'rxjs';
import { GuidModel } from 'src/app/models/common/GuidModel';
import { MatDialog } from '@angular/material/dialog';
import { EditTreatmentComponent } from '../edit-treatment/edit-treatment.component';

@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrls: ['./patient-details.component.scss']
})
export class PatientDetailsComponent implements OnInit {

  patientInformation: GetPatientInformationModel;
  patientTreatments: GetTreatmentInformationModel[];
  treatmentInformation: GetTreatmentInformationModel;
  patientId: string;
  isPatientDataAvailable: boolean;
  isPatientTreatmentDataAvailable:boolean;
  constructor(private route: ActivatedRoute,
    private patientService: PatientService,
    private loading: LoadingService,
    public dialog: MatDialog,) { }

  ngOnInit(): void {
    this.patientId = this.route.snapshot.paramMap.get('patientId');
    this.loadNext();
  }

  onTreatmentEdit(treatmentInformation: GetTreatmentInformationModel = {
    id: new GuidModel().Empty,
    patientId: this.patientId,
    summary: null,
    title: null,
    treatmentDate: null,
    treatmentFiles: null
  }){
    console.log(JSON.stringify(treatmentInformation));
    this.treatmentInformation = treatmentInformation;

    const dialogRef = this.dialog.open(EditTreatmentComponent, {
      disableClose: true,
      width: "500px",
      data: {treatmentInformation: this.treatmentInformation}
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        console.log("From Add", result);
        this.loadNext();
      }
    });
  }
  loadNext() {
    this.loading.show();
    forkJoin(
      this.patientService.getPatientDetails(this.patientId),
      this.patientService.getPatientTreatments(this.patientId)
    ).subscribe(([patientDetails, patientTreatments]) => {
      this.patientInformation = patientDetails;
      this.isPatientDataAvailable = true;
      console.log(JSON.stringify(this.patientInformation));
      this.patientTreatments = patientTreatments;
      this.isPatientTreatmentDataAvailable = true;
      this.loading.hide();
    })
  }

  getPatientDetails() {
    this.loading.show();
    this.patientService.getPatientDetails(this.patientId).subscribe(res => {
      this.patientInformation = res;
      this.loading.hide();
    })
  }

  getPatientTreatments() {
    this.loading.show();
    this.patientService.getPatientTreatments(this.patientId).subscribe(res => {
      this.patientTreatments = res;
      this.loading.hide();
    })
  }

}
