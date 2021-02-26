import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ToasterService {

  constructor(private toastr: ToastrService) { }

  success(title: string = "Success", message: string) {
    this.toastr.success(message, title, {
      closeButton: true
    })
  }

  error(title: string = "Failed", message: string) {
    this.toastr.error(message, title, {
      closeButton: true
    })
  }

  warning(title: string = "Warning", message: string) {
    this.toastr.warning(message, title, {
      closeButton: true
    })
  }
}
