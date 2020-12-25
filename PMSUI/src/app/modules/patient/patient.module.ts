import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientListComponent } from './patient-list/patient-list.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full'},
  { path: 'home', component: PatientListComponent},
];

@NgModule({
  declarations: [PatientListComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class PatientModule { }
