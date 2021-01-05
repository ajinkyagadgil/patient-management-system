import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SideNavComponent } from './side-nav/side-nav.component';
import { TopNavComponent } from './top-nav/top-nav.component';
import { RouterModule, Routes } from '@angular/router';

@NgModule({
  declarations: [SideNavComponent, TopNavComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    SideNavComponent,
    TopNavComponent
  ]
})
export class LayoutModule { }
