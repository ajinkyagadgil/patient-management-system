import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientListComponent } from './patient-list/patient-list.component';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { PatientDetailsComponent } from './patient-details/patient-details.component';
import { EditPatientComponent } from './edit-patient/edit-patient.component';
import { EditTreatmentComponent } from './edit-treatment/edit-treatment.component';

const routes: Routes = [
  { path: '', redirectTo: 'patient', pathMatch: 'full' },
  { path: 'patient', children:[
    {path: '', component: PatientListComponent},
    {path: 'add', component: EditPatientComponent},
    {path: 'details', component: PatientDetailsComponent}
  ] },
  {path: 'add', component: EditPatientComponent},
  { path: 'patient/:id', component: PatientDetailsComponent }
];

@NgModule({
  declarations: [PatientListComponent, PatientDetailsComponent, EditPatientComponent, EditTreatmentComponent],
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
