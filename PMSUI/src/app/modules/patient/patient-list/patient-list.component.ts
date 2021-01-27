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
    private router: Router) { }

  ngOnInit(): void {
    this.loadNext();
  }

  initData() {
    this.patientPhotoInformation = {
      id : new GuidModel().Empty,
      name : null,
      size : null,
      creationDate : null,
      path : null,
      type: null
    }

     this.patientData = {
      id : new GuidModel().Empty,
      firstName : null,
      lastName : null,
      email : null,
      age : null,
      gender : null,
      caseNo : null,
      history : null,
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
      data: {isFromHomeScreen: true, patientInformation: this.patientData}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
    //this.router.navigate(['patient/add'])
  }

  OnRowClick(patient: GetPatientInformationModel){
    this.loading.show();
    this.router.navigate(['patient/details'])
    this.loading.hide();
  }

  onPatientEdit(patient: GetPatientInformationModel) {
    const dialogRef = this.dialog.open(EditPatientComponent, {
      disableClose: true,
      data: {isFromHomeScreen: true, patientInformation: patient}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  onPatientDelete(patientId: string) {
    console.log(patientId);
  }

  onPatientDetails(patientId: string) {
    console.log(patientId);
  }
}
