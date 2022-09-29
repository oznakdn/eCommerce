import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ToastrMessageService {

  constructor(private toastrService:ToastrService) { }

  getToastrMessage(message:string, title:string,messageType:MessageType,positionType:PositionType, timeOut:number){
    this.toastrService[messageType](message,title,{
      positionClass:positionType,
      timeOut:timeOut
    });
  }
}

export enum MessageType{
  Success="success",
  Error="error",
  Warning="warning",
  Info = "info"
}

export enum PositionType{
TopRight ="toast-top-right",
TopLeft ="toast-left",
BottomRight="toast-bottom-right",
BottomLeft ="toast-bottom-left",
TopFullWidth="toast-top-full-width",
BottomFullWidth="toast-bottom-full-width",
TopCenter = "toast-top-center",
BottomCenter="toast-bottom-center"
}
