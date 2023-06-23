import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/model/category';
import { Product } from 'src/app/model/product';
import { ProductService } from 'src/app/services/product.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {

  products:Product[] = []
  clickEventSubscription: Subscription = new Subscription()

  constructor(private productService:ProductService, private sharedService: SharedService){
    this.clickEventSubscription = this.sharedService.getClickEvent().subscribe(()=>{
      this.getProductsByCategory(this.sharedService.currentCategory)
    })
    this.getAllProducts()
  }
  getAllProducts(){
    this.productService.getAllProducts().subscribe( res => {
      this.products = res
    })
  }

  getProductsByCategory(category: Category){
    if(category.categoryCode == "ALL") this.getAllProducts()
    else{
      this.productService.getProductsByCategory(category).subscribe(res=>{
        this.products = res
      })
    }
  }
}
