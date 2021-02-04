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
import { AppconfigService } from 'src/app/shared/appconfig.service';
import { FileInformationModel } from 'src/app/models/common/FileInformationModel';
import { ThisReceiver } from '@angular/compiler';

@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrls: ['./patient-details.component.scss']
})
export class PatientDetailsComponent implements OnInit {

  patientInformation: GetPatientInformationModel;
  apiUrl: string;
  allFiles: FileInformationModel[] = [];
  allFilesAdded: boolean;
  patientTreatments: GetTreatmentInformationModel[];
  treatmentInformation: GetTreatmentInformationModel;
  patientId: string;
  isPatientDataAvailable: boolean;
  isPatientTreatmentDataAvailable:boolean;
  constructor(private route: ActivatedRoute,
    private patientService: PatientService,
    private loading: LoadingService,
    public dialog: MatDialog,
    private appConfigService: AppconfigService) { }

  ngOnInit(): void {
    this.apiUrl = this.appConfigService.apiBaseUrl
    this.patientId = this.route.snapshot.paramMap.get('patientId');
    this.loadNext();
  }

  getImagePath(treatmentFile: FileInformationModel) {
    let fullPath: string = '';
    return fullPath.concat(this.apiUrl, treatmentFile.path, "/", treatmentFile.name);
  }

  onTreatmentEdit(treatmentInformation: GetTreatmentInformationModel = {
    id: new GuidModel().Empty,
    patientId: this.patientId,
    summary: null,
    title: null,
    treatmentDate: null,
    treatmentFiles: null
  }){
    console.log("Patient Details edit button", JSON.stringify(treatmentInformation));
    this.treatmentInformation = treatmentInformation;

    const dialogRef = this.dialog.open(EditTreatmentComponent, {
      disableClose: true,
      width: "500px",
      data: this.treatmentInformation
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this.getPatientTreatments();
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
      this.patientTreatments = patientTreatments;
      console.log("Treatment information from API", JSON.stringify(this.patientTreatments));
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

  onAllFilesTabClick() {
    this.allFiles = []; //To reset
    this.loading.show();
    this.allFilesAdded = false
    this.patientTreatments.forEach(treatment => {
      treatment.treatmentFiles.forEach(file => {
        this.allFiles.push(file);
      });
    });
    this.allFilesAdded = true;
    this.loading.hide();
  }

}
