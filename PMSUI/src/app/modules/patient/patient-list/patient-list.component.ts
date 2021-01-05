import { Component, OnInit, ViewChild } from '@angular/core';
import { GetPatientInformationModel } from 'src/app/models/patient/GetPatientInformationModel';
import { PatientService } from '../patient.service';

import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.scss']
})
export class PatientListComponent implements OnInit {
  public patientInformation: MatTableDataSource<GetPatientInformationModel>;
  displayedColumns: string[] = ['name', 'age', 'phone', 'gender', 'history', 'caseNo'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private patientService: PatientService) { }

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
}
