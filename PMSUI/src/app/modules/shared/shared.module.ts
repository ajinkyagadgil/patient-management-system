import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from 'src/app/material.module';
import { EmptyStringPipe } from './Pipes/empty-string.pipe';
import { GenderToStringPipe } from './Pipes/gender-to-string.pipe';
import { FilePathPipe } from './Pipes/file-path.pipe';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import { ImagesViewerComponent } from './components/images-viewer/images-viewer.component';
import { AngularImageViewerModule } from "angular-x-image-viewer";

@NgModule({
  declarations: [EmptyStringPipe, GenderToStringPipe, FilePathPipe, ConfirmDialogComponent, ImagesViewerComponent],
  imports: [
    CommonModule,
    AngularMaterialModule,
    AngularImageViewerModule
  ],
  exports: [
    AngularMaterialModule,
    EmptyStringPipe,
    GenderToStringPipe,
  ],
  providers: [],
  entryComponents: [
    ConfirmDialogComponent,
    ImagesViewerComponent
  ]
})
export class SharedModule {

}
