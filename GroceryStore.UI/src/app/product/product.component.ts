import { Component, OnInit } from '@angular/core';
import { GroceryService } from '../service/grocery-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  constructor(private service : GroceryService, private router : Router) {}

  //
  isAdmin : boolean | undefined;
  alert : boolean | undefined;
  selectedCategoryName : any | undefined;
  searchQuery: string = "";

  // arrays
  categories : any[] | undefined;
  products : any[] = [];

  // for paginantion
  currentPage = 1;
  itemsPerPage = 5;

  // for sorting
  sortBy: string = 'name';
  sortDirection: string = 'asc';


  ngOnInit(): void {
    this.service.getCategories().subscribe( (result) =>
    {
      this.categories = result;
    });

    this.service.getAllProducts().subscribe( (result) =>
    {
      result = result.map((product: { productImage: string; }) => {
        console.warn(result)
        product.productImage = product.productImage.substring(product.productImage.lastIndexOf('/') + 1);
        return product;
      });
      this.products = result;
    });
    this.isAdmin = this.service.loginResult.userIsAdmin;
  }

  deleteProduct(id : number)
  {
    this.service.deleteProductById(id).subscribe( (result) =>{
      setTimeout(() => {
        location.reload();
        this.alert = true;
      }, 20);
    });
  }

  onCategoryClick(category: any) 
  {
    if (category.categoryId) {
      this.service.getProductsByCategoryId(category.categoryId).subscribe((result)=>{
        result = result.map((product: { productImage: string; }) => {
          product.productImage = product.productImage.substring(product.productImage.lastIndexOf('/') + 1);
          return product;
        });
        this.products = result;
        this.selectedCategoryName = category.categoryName;
      });
    }
    else
    {
      setTimeout(() => {
        location.reload();
      }, 20);
    }
  }

  onSearch()
  {
    if(this.searchQuery) {
      this.service.searchProduct(this.searchQuery).subscribe((result)=>{
        result = result.map((product: { productImage: string; }) => {
          product.productImage = product.productImage.substring(product.productImage.lastIndexOf('/') + 1);
          return product;
        });
        this.products = result;
      })
    }
    else
    {
      setTimeout(() => {
        location.reload();
      }, 20);
    }
  }

  clearSearchQuery()
  {
    this.searchQuery = '';
  }

  closeAlert()
  {
    this.alert = false;
  }

  // For pagination operations
  get paginatedProducts(): any[] {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    return this.products.slice(startIndex, endIndex);
  }

  onPageChange(page: number): void {
    this.currentPage = page;
  }

  getTotalPages(): number {
    return Math.ceil(this.products.length / this.itemsPerPage);
  }

  getPageNumbers(): number[] {
    const totalPages = this.getTotalPages();
    return Array.from({ length: totalPages }, (_, index) => index + 1);
  }

  // Sorting of products
  sortByName()
  {
    this.sortBy = 'productName';
    this.sortDirection = 'asc';
    this.performSorting();
  }

  sortByPrice()
  {
    this.sortBy = 'productPrice';
    this.sortDirection = 'asc';
    this.performSorting();
  }

  sortByDiscount()
  {
    this.sortBy = 'productDiscount';
    this.sortDirection = 'dsc';
    this.performSorting();
  }

  performSorting() {
    this.products.sort((a, b) => {
      if (this.sortDirection === 'asc') {
        if (a[this.sortBy] > b[this.sortBy]) {
          return 1;
        } else if (a[this.sortBy] < b[this.sortBy]) {
          return -1;
        } else {
          return 0;
        }
      } else {
        if (b[this.sortBy] > a[this.sortBy]) {
          return 1;
        } else if (b[this.sortBy] < a[this.sortBy]) {
          return -1;
        } else {
          return 0;
        }
      }
    });
  }
  
}
