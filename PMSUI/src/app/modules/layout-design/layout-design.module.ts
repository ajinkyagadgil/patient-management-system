import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutDesignComponent } from './layout-design/layout-design.component';
import { RouterModule, Routes } from '@angular/router';
import { LayoutModuleHolder } from 'src/app/layout/layout.module';
import { LayoutModule } from '@angular/cdk/layout';

const routes: Routes = [
  { path: '',
    component: LayoutDesignComponent,
    children: [
      { path: '', loadChildren: () => import('../patient/patient.module').then(mod => mod.PatientModule)}   
    ]
  }
];

@NgModule({
  declarations: [LayoutDesignComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    LayoutModuleHolder,
    LayoutModule
  ],
})
export class LayoutDesignModule { }
