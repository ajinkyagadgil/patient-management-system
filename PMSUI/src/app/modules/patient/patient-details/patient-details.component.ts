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
import { EditPatientComponent } from '../edit-patient/edit-patient.component';
import { ConfirmDialogComponent } from '../../shared/components/confirm-dialog/confirm-dialog.component';
import { ImagesViewerComponent } from '../../shared/components/images-viewer/images-viewer.component';
import { ToasterService } from '../../shared/toaster.service';

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
  isPatientTreatmentDataAvailable: boolean;
  constructor(private route: ActivatedRoute,
    private patientService: PatientService,
    private loading: LoadingService,
    public dialog: MatDialog,
    private appConfigService: AppconfigService,
    private toasterService: ToasterService) { }

  ngOnInit(): void {
    this.apiUrl = this.appConfigService.apiBaseUrl
    this.patientId = this.route.snapshot.paramMap.get('patientId');
    this.loadNext();
  }

  getImagePath(treatmentFile: FileInformationModel) {
    let fullPath: string = '';
    return fullPath.concat(this.apiUrl, treatmentFile.path, "/", treatmentFile.name);
  }

  onTreatmentDelete(treatmentId: string) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      disableClose: true,
      data: { title: 'Delete Treatment?', message: 'Are you sure you want to delete the treatment information' }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loading.show();
        this.patientService.deleteTreatment(treatmentId).subscribe(() => {
          this.getPatientTreatments();
          this.toasterService.success("Success", "Treatment deleted Sucessfully");
          this.loading.hide();
        }, error => {
          this.toasterService.error("Failed", error.error);
          this.loading.hide();
        })
      }
    });
  }
  onTreatmentEdit(treatmentInformation: GetTreatmentInformationModel = {
    id: new GuidModel().Empty,
    patientId: this.patientId,
    summary: null,
    title: null,
    treatmentDate: null,
    treatmentFiles: null
  }) {
    this.treatmentInformation = treatmentInformation;

    const dialogRef = this.dialog.open(EditTreatmentComponent, {
      disableClose: true,
      width: "500px",
      data: this.treatmentInformation
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getPatientTreatments();
      }
    }, error => {
      this.toasterService.error("Failed", error.error);
      this.loading.hide();
    });
  }

  openImage(treatmentFile: FileInformationModel, treatmentFiles: FileInformationModel[]) {
    let imageUrl = this.getImagePath(treatmentFile);
    let imagesArray: string[] = [];
    imagesArray.push(imageUrl);
    let otherFiles = treatmentFiles.filter(x => x.id != treatmentFile.id);
    otherFiles.forEach(file => {
      imagesArray.push(this.getImagePath(file))
    })
    const dialogRef = this.dialog.open(ImagesViewerComponent, {
      data: imagesArray
    });
  }

  onImageDelete(imageId: string, treatment?: GetTreatmentInformationModel) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      disableClose: true,
      data: { title: 'Delete Image?', message: 'Are you sure you want to delete the treatment image' }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loading.show();
        this.patientService.deleteTreatmentImage(imageId).subscribe(() => {
          if (treatment != null || treatment != undefined) {
            this.patientTreatments.find(x => x.id == treatment.id).treatmentFiles = treatment.treatmentFiles.filter(x => x.id != imageId);
          }
          else {
            //this.getPatientTreatments();
            this.patientTreatments.forEach(treatment => {
              if (treatment.treatmentFiles.find(x => x.id == imageId)) {
                treatment.treatmentFiles = treatment.treatmentFiles.filter(x => x.id != imageId);
              }
            })
            this.allFiles = this.allFiles.filter(x => x.id != imageId);
          }
          this.toasterService.success("Success", "Treatment image deleted Sucessfully");
          this.loading.hide();
        }, error => {
          this.toasterService.error("Failed", error.error);
          this.loading.hide();
        })
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
      this.isPatientTreatmentDataAvailable = true;
      this.loading.hide();
    }, error => {
      this.toasterService.error("Failed", error.error);
      this.loading.hide();
    })
  }

  getPatientDetails() {
    this.loading.show();
    this.patientService.getPatientDetails(this.patientId).subscribe(res => {
      this.patientInformation = res;
      this.loading.hide();
    }, error => {
      this.toasterService.error("Failed", error.error);
      this.loading.hide();
    })
  }

  getPatientTreatments() {
    this.loading.show();
    this.patientService.getPatientTreatments(this.patientId).subscribe(res => {
      this.patientTreatments = res;
      this.loading.hide();
    }, error => {
      this.toasterService.error("Failed", error.error);
      this.loading.hide();
    })
  }

  onPatientEdit(patient: GetPatientInformationModel) {
    const dialogRef = this.dialog.open(EditPatientComponent, {
      disableClose: true,
      data: patient
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getPatientDetails();
      }
    }, error => {
      this.toasterService.error("Failed", error.error);
      this.loading.hide();
    });
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
