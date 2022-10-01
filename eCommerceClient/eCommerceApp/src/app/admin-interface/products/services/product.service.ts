import { Injectable } from '@angular/core';
import { observable, Observable } from 'rxjs';
import { HttpClientService } from 'src/app/general/http-client.service';
import { CreateProductModel } from '../models/create-product-model';


@Injectable({
  providedIn: 'root'
})
export class ProductService {


  constructor(private httpClientService:HttpClientService) { }


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
    },model).pipe();
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
