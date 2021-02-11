import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from 'src/app/material.module';
import { EmptyStringPipe } from './Pipes/empty-string.pipe';
import { GenderToStringPipe } from './Pipes/gender-to-string.pipe';
import { FilePathPipe } from './Pipes/file-path.pipe';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';



@NgModule({
  declarations: [EmptyStringPipe, GenderToStringPipe, FilePathPipe, ConfirmDialogComponent],
  imports: [
    CommonModule,
    AngularMaterialModule
  ],
  exports: [
    AngularMaterialModule,
    EmptyStringPipe,
    GenderToStringPipe
  ],
  entryComponents: [
    ConfirmDialogComponent
  ]
})
export class SharedModule { }
