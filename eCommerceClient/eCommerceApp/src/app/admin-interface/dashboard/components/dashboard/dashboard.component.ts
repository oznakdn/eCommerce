import { Component, OnInit } from '@angular/core';
import { AlertifyMessageService, MessageType, PositionType } from 'src/app/general/alertify-message.service';



@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private alertifyService:AlertifyMessageService) { }

  ngOnInit(): void {
    this.alertifyService.getAlertfyMessage("Alertify",MessageType.Success,PositionType.TopLeft,3000);
  }

}
