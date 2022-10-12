import { HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AlertifyMessageService, MessageType, PositionType } from 'src/app/general/alertify-message.service';
import { CreateProductModel } from '../../models/create-product-model';
import { ProductService } from '../../services/product.service';




@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent  implements OnInit {


  @Output() createdProduct: EventEmitter<CreateProductModel> = new EventEmitter();

  constructor(private productService: ProductService, private alertfyService: AlertifyMessageService) {
  }


  ngOnInit(): void {

  }


  createProduct(createProductModel: CreateProductModel) {
    this.productService.createProduct<CreateProductModel>(createProductModel).subscribe(res => {
      this.alertfyService.getAlertfyMessage("Product is created successfully", MessageType.Success, PositionType.TopRight, 2000);
    },
      (errorResponse: HttpErrorResponse) => {
        const error: Array<{ key: string, value: Array<string> }> = errorResponse.error;
        let message = "";
        error.forEach((val, index) => {
          val.value.forEach((v, i) => {
            message += `${v}<br>`
          });
        });
        this.alertfyService.getAlertfyMessage(`Not created!<br> ${message}`, MessageType.Error, PositionType.TopRight, 2000);
      });
  }


}
