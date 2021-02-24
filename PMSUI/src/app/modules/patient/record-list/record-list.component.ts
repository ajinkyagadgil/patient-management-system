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
import { ConfirmDialogComponent } from '../../shared/components/confirm-dialog/confirm-dialog.component';
import { FormBuilder, FormGroup } from '@angular/forms';

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
  dateRangeFormGroup: FormGroup;

  constructor(private loading: LoadingService,
    private patientService: PatientService,
    public dialog: MatDialog,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.initForm();
    this.loadNext();
  }

  initForm() {
    this.dateRangeFormGroup = this.fb.group({
      start: [new Date()],
      end: [new Date()]
    })
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

  onRecordDelete(recordId: string) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: {title: 'Delete Record?', message:'Are you sure you want to permanently delete the record'}
    })

    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.loading.show();
        this.patientService.deleteRecord(recordId).subscribe(res => {
          this.loadNext();
          this.loading.hide();
        })
      }
    })
  }

  getTotalAmount() {
    let total = 0;
    this.allRecordInformation.forEach(record => {
      total = total + record.amount;
    })
    return total;
    }
}
