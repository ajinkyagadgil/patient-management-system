import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientListComponent } from './patient-list/patient-list.component';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { EditPatientComponent } from './patient-list/edit-patient/edit-patient.component';
import { ReactiveFormsModule } from '@angular/forms';

const routes: Routes = [
  { path: '', redirectTo: 'patient', pathMatch: 'full'},
  { path: 'patient', component: PatientListComponent},
];

@NgModule({
  declarations: [PatientListComponent, EditPatientComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    SharedModule
  ],
  entryComponents: [
    /*
    Because MatDialog instantiates components at run-time, the Angular compiler needs extra information to create the 
    necessary ComponentFactory for your dialog content component.For any component loaded into a dialog, 
    you must include your component class in the list of entryComponents in your NgModule definition 
    so that the Angular compiler knows to create the ComponentFactory for it.
    */
    EditPatientComponent
  ]
})
export class PatientModule { }
