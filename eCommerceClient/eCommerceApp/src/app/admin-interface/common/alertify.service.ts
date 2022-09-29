import { Injectable } from '@angular/core';

declare var alertify: any;

@Injectable({
  providedIn: 'root',
})
export class AlertifyService {
  constructor() {}

  getMessage(message: string, messageType: MessageType, positionType:PositionType,delay:number) {
    alertify.set('notifier','delay', delay);
    alertify.set('notifier','position',positionType);
    alertify[messageType](message,messageType);
  }

}

export enum MessageType {
  Message = 'message',
  Success = 'success',
  Error = 'error',
  Warning = 'warning',
}

export enum PositionType{
  TopRight="top-right",
  TopLeft = "top-left",
  TopCenter="top-center",
  BottomRight ='bottom-right',
  BottomLeft="bottom-left",
  BottomCenter="bottom-center"
}
