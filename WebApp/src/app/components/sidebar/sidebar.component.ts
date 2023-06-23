import { Component } from '@angular/core';
import { Category } from 'src/app/model/category';
import { CategoryService } from 'src/app/services/category.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {
  // categories = ["Option 1", "Option 2", "Option 3"]
  categories: Category[] = []
  constructor(private categoryService:CategoryService, private sharedService: SharedService){
    // We are using reactive programming, so we need to subscribe to the publisher
    categoryService.getCategories().subscribe(res => {
      this.categories = res
    })
  }

  getProductsByCategory(category: Category){
    this.sharedService.sendClickEvent(category)
  }
  getAllProducts(){
    this.sharedService.sendClickEvent({"categoryCode": "ALL"})
  }
}
