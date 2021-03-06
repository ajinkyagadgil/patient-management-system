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
import { DateRangeModel } from 'src/app/models/records/DateRangeModel';
import { ToasterService } from '../../shared/toaster.service';

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
  isAllInformation: boolean;
  dateRangeFormGroup: FormGroup;

  constructor(private loading: LoadingService,
    private patientService: PatientService,
    public dialog: MatDialog,
    private fb: FormBuilder,
    private toasterService: ToasterService) { }

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
    this.isAllInformation = false;
    this.patientService.getAllRecords(this.getDateRangeValue()).subscribe(res => {
      this.recordInformation = new MatTableDataSource(res);
      this.recordInformation.sort = this.sort;
      this.recordInformation.paginator = this.paginator;
      
      this.isAllInformation = true
      this.loading.hide();
    }, error => {
      this.toasterService.error("Failed", error.error);
      this.loading.hide();
    })
  }

  onRecordEdit(recordInformation: RecordInformationModel = {
    id: new GuidModel().Empty,
    patientId: new GuidModel().Empty,
    recordDate: null,
    amount: null,
    treatment: null,
    patientInformation: null
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
      data: { title: 'Delete Record?', message: 'Are you sure you want to permanently delete the record' }
    })

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loading.show();
        this.patientService.deleteRecord(recordId).subscribe(() => {
          this.loadNext();
          this.toasterService.success("Success", "Record deleted Successfully");
          this.loading.hide();
        })
      }
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.recordInformation.filter = filterValue.trim().toLowerCase();

    this.recordInformation.filterPredicate = (data, filter: string)  => {
      const accumulator = (currentTerm, key) => {
        return key === 'patientInformation' ? currentTerm + data.patientInformation.firstName + data.patientInformation.lastName : currentTerm + data[key];
      };
      const dataStr = Object.keys(data).reduce(accumulator, '').toLowerCase();
      // Transform the filter by converting it to lowercase and removing whitespace.
      const transformedFilter = filter.trim().toLowerCase();
      return dataStr.indexOf(transformedFilter) !== -1;
    };
  }

  onDateRangeApply() {
    this.loading.show();
    this.isAllInformation = false;
    this.patientService.getAllRecords(this.getDateRangeValue()).subscribe(res => {
      this.recordInformation = new MatTableDataSource(res);
      this.isAllInformation = true;
      this.recordInformation.sort = this.sort;
      this.recordInformation.paginator = this.paginator;
      this.loading.hide();
    }, error => {
      this.toasterService.error("Failed", error.error);
      this.loading.hide();
    })
  }

  getDateRangeValue() {
    let dateRangeFormGroupData = this.dateRangeFormGroup.value;
    let dateRange: DateRangeModel = {
      startDate: this.formatDate(dateRangeFormGroupData.start),
      endDate: this.formatDate(dateRangeFormGroupData.end)
    }
    return dateRange;
  }
  getTotalAmount() {
    let total = 0;
    this.recordInformation.filteredData.forEach(record => {
      total = total + record.amount;
    })
    return total;
  }

  formatDate(date: Date) {
    if (date != null) {
      var offsetMs = date.getTimezoneOffset() * 60000;
      return new Date(date.getTime() - offsetMs);
    }
    else {
      return null;
    }
  }
}
