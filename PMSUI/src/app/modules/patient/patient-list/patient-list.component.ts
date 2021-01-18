import { Component, OnInit, ViewChild } from '@angular/core';
import { GetPatientInformationModel } from 'src/app/models/patient/GetPatientInformationModel';
import { PatientService } from '../patient.service';

import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { EditPatientComponent } from './edit-patient/edit-patient.component';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.scss']
})
export class PatientListComponent implements OnInit {

  public patientInformation: MatTableDataSource<GetPatientInformationModel>;
  displayedColumns: string[] = ['firstName', 'lastName', 'email', 'age', 'phone', 'gender', 'history', 'caseNo'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private patientService: PatientService,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadNext();
  }

  loadNext() {
    this.patientService.getAllPatients().subscribe(res => {
      this.patientInformation = new MatTableDataSource(res);
      this.patientInformation.sort = this.sort;
      this.patientInformation.paginator = this.paginator;
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.patientInformation.filter = filterValue.trim().toLowerCase();
  }

  openAddPatientDialog() {
    const dialogRef = this.dialog.open(EditPatientComponent, {
      height: '565px',
      width: '800px',
      disableClose: true
    })
  }

  OnRowClick(patient: GetPatientInformationModel){
    console.log(JSON.stringify(patient));
  }
}
