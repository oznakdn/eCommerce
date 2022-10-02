import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AlertifyMessageService, MessageType, PositionType } from 'src/app/general/alertify-message.service';
import { CreateProductModel } from '../../models/create-product-model';
import { ProductService } from '../../services/product.service';




@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent  implements OnInit {


  constructor(private productService:ProductService, private alertfyService:AlertifyMessageService) {
  }


  ngOnInit(): void {

  }

  createProduct(ProductName:HTMLInputElement, Stock:HTMLInputElement, Price:HTMLInputElement){
    const createProductModel:CreateProductModel = new CreateProductModel();
    createProductModel.productName = ProductName.value;
    createProductModel.stock =parseInt(Stock.value);
    createProductModel.price =parseFloat(Price.value);

    this.productService.createProduct(createProductModel).subscribe(res=>{
        // success
        this.alertfyService.getAlertfyMessage("The product was created as successfully",MessageType.Success,PositionType.TopRight,2000);
      },
      // error
      (errorResponse:HttpErrorResponse)=>{
        const error:Array<{key:string, value:Array<string>}>= errorResponse.error;
        let message="";
        error.forEach((val,index)=>{
            val.value.forEach((v,i)=>{
              message+=`${v}<br>`
            });
        })
        this.alertfyService.getAlertfyMessage(`Not created!<br> ${message}`,MessageType.Error,PositionType.TopRight,2000);
      });
  }


}
