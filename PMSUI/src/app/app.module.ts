import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {HttpClientModule} from '@angular/common/http'
import { AngularMaterialModule } from './material.module';
import { AppconfigService } from './shared/appconfig.service';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
  ],
  exports: [
    AngularMaterialModule
  ],
  providers: [
    AppconfigService,
    {
      provide: APP_INITIALIZER, useFactory: initConfig, deps: [AppconfigService], multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

function initConfig(config: AppconfigService){
  return () => config.loadAppConfig()
}
