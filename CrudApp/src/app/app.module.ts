import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { CategoryComponent } from './components/category/category.component';
import { CategoryFormComponent } from './components/category-form/category-form.component';
import { ProductComponent } from './components/product/product.component';

@NgModule({
  declarations: [
    AppComponent,
    CategoryComponent,
    CategoryFormComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: CategoryComponent},
      {path: 'category', component: CategoryComponent},
      {path: 'product', component: ProductComponent},
      {path: 'category/create', component: CategoryFormComponent},
      {path: 'category/update', component: CategoryFormComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
