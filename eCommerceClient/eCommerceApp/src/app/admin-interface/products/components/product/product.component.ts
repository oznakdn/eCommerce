import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AlertifyMessageService, PositionType, MessageType } from 'src/app/general/alertify-message.service';
import { CreateProductModel } from '../../models/create-product-model';
import { GetProductModel } from '../../models/get-product-model';
import { UpdateProductModel } from '../../models/update-product-model';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {





  constructor(private productService: ProductService, private alertfyService: AlertifyMessageService) { }



  async ngOnInit() {

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

  updateProduct(updateProductModel: UpdateProductModel) {
    this.productService.updateProduct<UpdateProductModel>(updateProductModel).subscribe(res => {
    });
  }

  deleteProduct(id: string) {
    this.productService.deleteProduct(id);
  }

}


