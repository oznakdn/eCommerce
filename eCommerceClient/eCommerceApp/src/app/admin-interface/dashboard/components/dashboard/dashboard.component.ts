import { Component, OnInit } from '@angular/core';
import { AlertifyService, MessageType, PositionType } from 'src/app/admin-interface/common/alertify.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private alertfy:AlertifyService) { }

  ngOnInit(): void {
      this.alertfy.getMessage('Merhaba',MessageType.Success,PositionType.TopRight,1);
  }

}
