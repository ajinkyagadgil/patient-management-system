import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutDesignComponent } from './layout-design/layout-design.component';
import { RouterModule, Routes } from '@angular/router';
import { SideNavComponent } from 'src/app/layout/side-nav/side-nav.component';
import { TopNavComponent } from 'src/app/layout/top-nav/top-nav.component';
import { PatientModule } from '../patient/patient.module';
import { LayoutModule } from '@angular/cdk/layout';
import { LoadingComponent } from 'src/app/layout/loading/loading.component';

const routes: Routes = [
  { path: '',
    component: LayoutDesignComponent,
    children: [
      { path: '', loadChildren: () => import('../patient/patient.module').then(mod => mod.PatientModule)}   
    ]
  }
];

@NgModule({
  declarations: [LayoutDesignComponent, SideNavComponent, TopNavComponent, LoadingComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    LayoutModule
  ]
})
export class LayoutDesignModule { }
