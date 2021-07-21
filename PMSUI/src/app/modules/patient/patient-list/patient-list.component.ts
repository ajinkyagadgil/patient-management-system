import { Component, OnInit, ViewChild } from '@angular/core';
import { GetPatientInformationModel } from 'src/app/models/patient/GetPatientInformationModel';
import { PatientService } from '../patient.service';

import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { LoadingService } from 'src/app/shared/loading.service';
import { Router } from '@angular/router';
import { EditPatientComponent } from '../edit-patient/edit-patient.component';
import { GuidModel } from 'src/app/models/common/GuidModel';
import { FileInformationModel } from 'src/app/models/common/FileInformationModel';
import { ConfirmDialogComponent } from '../../shared/components/confirm-dialog/confirm-dialog.component';
import { ToasterService } from '../../shared/toaster.service';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.scss']
})
export class PatientListComponent implements OnInit {

  public patientPhotoInformation: FileInformationModel;
  public patientData: GetPatientInformationModel;

  public patientInformation: MatTableDataSource<GetPatientInformationModel>;
  displayedColumns: string[] = ['firstName', 'lastName', 'email', 'age', 'phone', 'gender', 'history', 'caseNo', 'patientActions'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private patientService: PatientService,
    public dialog: MatDialog,
    private loading: LoadingService,
    private router: Router,
    private toasterService: ToasterService) { }

  ngOnInit(): void {
    this.loadNext();
  }

  initData() {
    this.patientPhotoInformation = {
      id: new GuidModel().Empty,
      name: null,
      size: null,
      creationDate: null,
      path: null,
      type: null
    }

    this.patientData = {
      id: new GuidModel().Empty,
      firstName: null,
      lastName: null,
      email: null,
      age: null,
      gender: null,
      caseNo: null,
      history: null,
      phone: null,
      patientPhotoInformation: this.patientPhotoInformation
    };
  }

  loadNext() {
    this.loading.show();
    this.patientService.getAllPatients().subscribe(res => {
      this.patientInformation = new MatTableDataSource(res);
      this.patientInformation.sort = this.sort;
      this.patientInformation.paginator = this.paginator;
      this.loading.hide();
    }, error => {
      this.toasterService.error("Failed", error.error);
      this.loading.hide();
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.patientInformation.filter = filterValue.trim().toLowerCase();
  }

  openAddPatientDialog() {
    this.initData();
    const dialogRef = this.dialog.open(EditPatientComponent, {
      disableClose: true,
      data: this.patientData
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadNext();
      }
    });
  }

  OnRowClick(patient: GetPatientInformationModel) {
    this.loading.show();
    this.router.navigate(['patient/details', patient.id])
    this.loading.hide();
  }

  onPatientEdit(patient: GetPatientInformationModel = {
    id: new GuidModel().Empty,
    firstName: null,
    lastName: null,
    email: null,
    age: null,
    gender: null,
    caseNo: null,
    history: null,
    phone: null,
    patientPhotoInformation: null
  }) {
    const dialogRef = this.dialog.open(EditPatientComponent, {
      disableClose: true,
      data: patient
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadNext();
      }
    });
  }

  onPatientDelete(patientId: string) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      disableClose: true,
      data: { title: 'Delete Patient', message: 'Are you sure you want to delete the patient along with all the treatment and record information' }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loading.show();
        this.patientService.deletePatient(patientId).subscribe(() => {
          this.loadNext();
          this.toasterService.success("Success", "Patient information deleted successfully");
          this.loading.hide();
        }, error => {
          this.toasterService.error("Failed", error.error);
          this.loading.hide();
        })
      }
    });
  }

  onPatientDetails(patientId: string) {
    this.loading.show();
    this.router.navigate(['patient/details', patientId])
    this.loading.hide();
  }
}
