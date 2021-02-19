import { Component, OnInit, ViewChild } from '@angular/core';
import { LoadingService } from 'src/app/shared/loading.service';
import { PatientService } from '../patient.service';
import { RecordInformationModel } from 'src/app/models/records/RecordInformationModel';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-record-list',
  templateUrl: './record-list.component.html',
  styleUrls: ['./record-list.component.scss']
})
export class RecordListComponent implements OnInit {

  displayedColumns: string[] = ['firstName', 'lastName', 'treatment', 'amount', 'recordActions'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  recordInformation: MatTableDataSource<RecordInformationModel>;

  constructor(private loading: LoadingService,
    private patientService: PatientService) { }

  ngOnInit() {
    this.loadNext();
  }

  loadNext() {
    this.loading.show();
    this.patientService.getAllRecords().subscribe(res => {
      this.recordInformation = new MatTableDataSource(res);
      this.recordInformation.sort = this.sort;
      this.recordInformation.paginator = this.paginator;
      this.loading.hide();
    },
    err => {
      console.log(err.message);
    })
  }

  onRecordEdit() {

  }

  getTotalAmount() {
    return 100;
  }

}
