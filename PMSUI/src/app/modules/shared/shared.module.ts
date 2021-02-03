import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from 'src/app/material.module';
import { EmptyStringPipe } from './Pipes/empty-string.pipe';
import { GenderToStringPipe } from './Pipes/gender-to-string.pipe';
import { FilePathPipe } from './Pipes/file-path.pipe';



@NgModule({
  declarations: [EmptyStringPipe, GenderToStringPipe, FilePathPipe],
  imports: [
    CommonModule,
    AngularMaterialModule
  ],
  exports: [
    AngularMaterialModule,
    EmptyStringPipe,
    GenderToStringPipe
  ]
})
export class SharedModule { }
