import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from 'src/app/material.module';
import { EmptyStringPipe } from './Pipes/empty-string.pipe';



@NgModule({
  declarations: [EmptyStringPipe],
  imports: [
    CommonModule,
    AngularMaterialModule
  ],
  exports: [
    AngularMaterialModule,
    EmptyStringPipe
  ]
})
export class SharedModule { }
