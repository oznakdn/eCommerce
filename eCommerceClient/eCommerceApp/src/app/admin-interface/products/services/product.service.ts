
import { Injectable } from '@angular/core';
import { AlertifyMessageService, MessageType, PositionType } from 'src/app/general/alertify-message.service';
import { HttpClientService } from 'src/app/general/http-client.service';




@Injectable({
  providedIn: 'root'
})
export class ProductService {


  constructor(private httpClientService:HttpClientService, private alertfyService:AlertifyMessageService) { }


    getProducts<GetProductModel>(){
    return this.httpClientService.get<GetProductModel>({
      controller:'products'
    }).pipe();
  }

  getProduct<GetProductModel>(id:string){
    return this.httpClientService.get<GetProductModel>({
      controller:'products',
    },id).pipe();
  }

  createProduct<CreateProductModel>(model:CreateProductModel){
    return this.httpClientService.post<CreateProductModel>({
      controller:'products',
    },model);
  }

  updateProduct<UpdateProductModel>(model:UpdateProductModel){
    return this.httpClientService.put({
      controller:"products"
    },model).pipe();
  }

  deleteProduct(id:string){
    this.httpClientService.delete({
      controller:"products"
    },id);
  }
}
