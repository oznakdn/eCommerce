import { Component, ViewChild , AfterViewInit} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { CreateProductModel } from '../../models/create-product-model';
import { GetProductModel } from '../../models/get-product-model';
import { UpdateProductModel } from '../../models/update-product-model';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements AfterViewInit {


  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  //products:GetProductModel[]=[];
  product:GetProductModel;
  createProductModel:CreateProductModel=new CreateProductModel();
  updateProductModel:UpdateProductModel = new UpdateProductModel();


  displayedColumns: string[] = ['Id', 'Product Name', 'Stock', 'Price'];
  dataSource: MatTableDataSource<GetProductModel>;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


  constructor(private productService:ProductService) {



  }



  ngOnInit(): void {
    this.getProductsList();

    /* Create test
    this.createProductModel.productName="Silgi";
    this.createProductModel.stock=500;
    this.createProductModel.price=5;
    this.createProduct(this.createProductModel);
    */

    /* Update test
    this.updateProductModel.id="B6FDD1E2-4E4D-419E-665B-08DAA3993140";
    this.updateProductModel.productName="Kalem Tras";
    this.updateProductModel.stock=500;
    this.updateProductModel.price=5;
    this.updateProduct(this.updateProductModel);
    */

    /*Delete test
    this.deleteProduct("B6FDD1E2-4E4D-419E-665B-08DAA3993140");
    */

  }



  getProductsList(){
      this.productService.getProducts<GetProductModel[]>().subscribe(res=>{
      console.log(res);
      this.dataSource = new MatTableDataSource(res);
      //this.products = res;
    });
  }

  getProductById(id:string){
    this.productService.getProduct<GetProductModel>(id).subscribe(res=>{
      console.log(res);
      this.product = res;
    })
  }

  createProduct(createProductModel:CreateProductModel){
    this.productService.createProduct<CreateProductModel>(createProductModel).subscribe(res=>{
        this.getProductsList();
    });
  }

  updateProduct(updateProductModel:UpdateProductModel){
    this.productService.updateProduct<UpdateProductModel>(updateProductModel).subscribe(res=>{
        this.getProductsList();
    });
  }

  deleteProduct(id:string){
    this.productService.deleteProduct(id);
    this.getProductsList();
  }

}


