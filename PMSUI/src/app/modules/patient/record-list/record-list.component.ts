import { Component, OnInit, ViewChild } from '@angular/core';
import { LoadingService } from 'src/app/shared/loading.service';
import { PatientService } from '../patient.service';
import { RecordInformationModel } from 'src/app/models/records/RecordInformationModel';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { GuidModel } from 'src/app/models/common/GuidModel';
import { MatDialog } from '@angular/material/dialog';
import { EditRecordComponent } from './edit-record/edit-record.component';

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
  allRecordInformation: RecordInformationModel[];

  constructor(private loading: LoadingService,
    private patientService: PatientService,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.loadNext();
  }

  loadNext() {
    this.loading.show();
    this.patientService.getAllRecords().subscribe(res => {
      this.recordInformation = new MatTableDataSource(res);
      this.allRecordInformation = res;
      this.recordInformation.sort = this.sort;
      this.recordInformation.paginator = this.paginator;
      this.loading.hide();
    },
    err => {
      console.log(err.message);
    })
  }

  onRecordEdit(recordInformation: RecordInformationModel = {
    id : new GuidModel().Empty,
    patientId : new GuidModel().Empty,
    recordDate : null,
    amount : null,
    treatment : null,
    patientInformation : null
  }) {
    const dialogRef = this.dialog.open(EditRecordComponent, {
      disableClose: true,
      data: recordInformation
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadNext();
      }
    });
  }

  getTotalAmount() {
    let total = 0;
    this.allRecordInformation.forEach(record => {
      total = total + record.amount;
    })
    return total;
    }
}
