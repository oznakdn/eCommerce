import { Component, OnInit, ViewChild} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { GetProductModel } from '../../models/get-product-model';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  displayedColumns: string[] = ['Id', 'Product Name', 'Stock', 'Price'];
  dataSource: MatTableDataSource<GetProductModel>;


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  constructor(private productService:ProductService) { }


  async ngOnInit(){
   await this.getProductsList();
  }

  async getProductsList(){
    this.productService.getProducts<GetProductModel[]>().subscribe(res=>{
    console.log(res);
    this.dataSource = new MatTableDataSource<GetProductModel>(res);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  });
}

async pageChanged(){
  await this.getProductsList();
}


}


