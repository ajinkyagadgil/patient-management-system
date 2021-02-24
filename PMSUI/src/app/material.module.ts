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
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule, MAT_DATE_LOCALE } from '@angular/material/core';
import {MatCardModule} from '@angular/material/card'; 
import {MatMenuModule} from '@angular/material/menu'; 
import {MatTabsModule} from '@angular/material/tabs'; 
import {MatAutocompleteModule} from '@angular/material/autocomplete'; 
// import {} from '@angular/material-moment-adapter';

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
        MatToolbarModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatCardModule,
        MatMenuModule,
        MatTabsModule,
        MatAutocompleteModule
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
        MatToolbarModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatCardModule,
        MatMenuModule,
        MatTabsModule,
        MatAutocompleteModule
    ],
    // providers: [
    //     {provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: {strict: true}}
    //   ]
    providers: [
        {provide: MAT_DATE_LOCALE, useValue: 'en-IN'},
      ],
})

export class AngularMaterialModule { }