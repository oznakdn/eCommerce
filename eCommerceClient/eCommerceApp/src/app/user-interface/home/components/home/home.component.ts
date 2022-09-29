import { Component, OnInit } from '@angular/core';
import { MessageType, PositionType, ToastrMessageService } from 'src/app/general/toastr-message.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private toastrService:ToastrMessageService) { }

  ngOnInit(): void {
    this.toastrService.getToastrMessage("Toastr","Information",MessageType.Info,PositionType.TopRight,3000);
  }

}
