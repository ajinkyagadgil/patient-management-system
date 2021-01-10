import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientListComponent } from './patient-list/patient-list.component';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { EditPatientComponent } from './patient-list/edit-patient/edit-patient.component';

const routes: Routes = [
  { path: '', redirectTo: 'patient', pathMatch: 'full'},
  { path: 'patient', component: PatientListComponent},
];

@NgModule({
  declarations: [PatientListComponent, EditPatientComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class PatientModule { }
