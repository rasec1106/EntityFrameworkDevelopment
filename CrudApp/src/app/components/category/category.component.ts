import { Component } from '@angular/core';
import { Category } from 'src/app/model/category';
import { CategoryService } from 'src/app/services/category.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent {
  categories: Category[] = []
  constructor(private categoryService: CategoryService, private router: Router) {
    categoryService.getCategories().subscribe(res => this.categories = res)
  }

  addCategory(){    
    this.categoryService.currentCategory = {"categoryId": 0, "categoryName":"", categoryCode: ""}
    this.router.navigate(['category/create'])
  }

  updateCategory(category: any){
    this.categoryService.currentCategory = category
    this.router.navigate(['category/update'])
  }

  deleteCategory(category: any){
    if (confirm(`Quieres eliminar la categoria ${category.categoryName}?`)) {
      this.categoryService.deleteCategory(category.categoryId).subscribe(res=>{
        this.categoryService.getCategories().subscribe(res => this.categories = res)
        // this.router.navigate(['/category'])
      })
    }
  }
}

//EXAMEN CT03
/**
 * 1. Completa el CRUD (como quieras en el front y en el back, con DTO y etc) 9pts
 * 2. En WebApp haz que filtre los productos cuando doy click en las categorias en el sidebar
 */