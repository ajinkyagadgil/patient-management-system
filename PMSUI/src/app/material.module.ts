import { NgModule } from "@angular/core";

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatStepperModule } from '@angular/material/stepper';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';

@NgModule({
    declarations: [],
    imports: [
        MatTableModule,
        MatSortModule,
        MatFormFieldModule,
        MatInputModule,
        MatPaginatorModule,
        MatButtonModule,
        MatDialogModule,
        MatStepperModule,
        MatSelectModule,
        MatIconModule,
        MatToolbarModule 
    ],
    exports: [
        MatTableModule,
        MatSortModule,
        MatFormFieldModule,
        MatInputModule,
        MatPaginatorModule,
        MatButtonModule,
        MatDialogModule,
        MatStepperModule,
        MatSelectModule,
        MatIconModule,
        MatToolbarModule
    ]
})

export class AngularMaterialModule { }