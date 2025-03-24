import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { GroceryService } from '../service/grocery-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  
  newProduct : FormGroup;
  selectedFile: File | undefined;
  categories : any[] | undefined;
  alert : boolean = false;

  constructor(private productService : GroceryService, private router : Router, private formBuilder: FormBuilder) {
    this.newProduct = this.formBuilder.group({
      productName: ['', [Validators.required, Validators.maxLength(100)]],
      productDescription: ['', [Validators.required, Validators.maxLength(255)]],
      productQuantity: ['', Validators.required],
      productPrice: ['', Validators.required],
      productDiscount: [''],
      productSpecification: ['', Validators.maxLength(100)],
      productImage: [null, [Validators.required, Validators.pattern(/\.(jpg|png)$/)]],
      categoryEntityId: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.productService.getCategories().subscribe( (result) =>
    {
      this.categories = result;
    });
  }

  onUploadImage(event: any)
  {
    const file = event.target.files[0];
    this.selectedFile = file;
  }

  addProductGrocery()
  {
    //console.warn(this.newProduct.value);
    if(this.newProduct.valid)
    {
      const formData = new FormData();
      formData.append('productName', this.newProduct.value.productName);
      formData.append('productDescription', this.newProduct.value.productDescription);
      formData.append('productQuantity', this.newProduct.value.productQuantity);
      formData.append('productPrice', this.newProduct.value.productPrice);
      formData.append('productDiscount', this.newProduct.value.productDiscount);
      formData.append('productSpecification', this.newProduct.value.productSpecification);
      if (this.selectedFile) {
        formData.append('productImageURL', this.selectedFile, this.selectedFile.name);
      }
      formData.append('categoryEntityId', this.newProduct.value.categoryEntityId);
    
      this.productService.addProduct(formData).subscribe( (result) =>{
        if(result)
        {
          this.alert = true;
          this.newProduct.reset({});
          setTimeout(() => {
            this.router.navigate(["/product"]);
          }, 3000);
        }
      });
    }
  }
  
  closeAlert()
  {
    this.alert=false;
  }
}
