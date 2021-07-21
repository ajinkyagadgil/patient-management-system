import { Component, OnInit } from '@angular/core';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.scss']
})
export class LoadingComponent {

  constructor(private loading: LoadingService) { }

  public get isLoaderRunning() {
    return this.loading.isLoading;
  }

}
