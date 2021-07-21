import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  isLoading: boolean
  constructor() { }

  show() {
    this.isLoading = true;
  }

  hide(){
    this.isLoading = false;
  }
}
