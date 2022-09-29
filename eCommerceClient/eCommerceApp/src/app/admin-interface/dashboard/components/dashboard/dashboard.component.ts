import { Component, OnInit } from '@angular/core';
import { AlertifyMessageService, MessageType, PositionType } from 'src/app/general/alertify-message.service';
import { SpinnerService } from 'src/app/general/spinner.service';



@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private alertifyService:AlertifyMessageService, private spinnerService:SpinnerService) { }

  ngOnInit(): void {
    this.alertifyService.getAlertfyMessage("Alertify",MessageType.Success,PositionType.BottomRight,2000);
    this.spinnerService.getSpinner(1000);
  }

}
