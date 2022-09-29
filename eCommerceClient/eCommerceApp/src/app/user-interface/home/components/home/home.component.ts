import { Component, OnInit } from '@angular/core';
import { SpinnerService } from 'src/app/general/spinner.service';
import { MessageType, PositionType, ToastrMessageService } from 'src/app/general/toastr-message.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private toastrService:ToastrMessageService, private spinnerService:SpinnerService) { }

  ngOnInit(): void {
    this.toastrService.getToastrMessage("Toastr","Information",MessageType.Info,PositionType.TopRight,3000);
    this.spinnerService.getSpinner(1000);
  }

}
