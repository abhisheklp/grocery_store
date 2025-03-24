import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GroceryService } from '../service/grocery-service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.css']
})

export class UpdateProductComponent implements OnInit {

  editProduct : FormGroup;
  selectedFile: File | undefined;
  categories : any[] | undefined;
  alert : boolean = false;

  constructor(private router: Router, private productService : GroceryService, private route : ActivatedRoute, private formBuilder: FormBuilder) {
    this.editProduct = this.formBuilder.group({
      productName: ['', [Validators.required, Validators.maxLength(100)]],
      productDescription: ['', [Validators.required, Validators.maxLength(255)]],
      productQuantity: ['', Validators.required],
      productPrice: ['', Validators.required],
      productDiscount: [''],
      productSpecification: [''],
      productImage: [null, Validators.pattern(/\.(jpg|png)$/)],
      categoryEntityId: ['', Validators.required]
    });
  }


  ngOnInit(): void {
    this.productService.getCategories().subscribe( (result) =>
    {
      this.categories = result;
    });

    this.productService.getProductById(this.route.snapshot.params['id']).subscribe( (result : any) =>{
      //console.warn(result);
      this.editProduct.patchValue({
        productName : result['productName'],
        productDescription : result['productDescription'],
        productQuantity : result['productQuantity'],
        productPrice: result['productPrice'],
        productDiscount : result['productDiscount'],
        productSpecification : result['productSpecification'],
        productImage : result['productImageURL'],
        categoryEntityId : result['categoryEntityId'],
      })
      //console.warn(this.editProduct);
    });
  }

  onUploadImage(event: any)
  {
    const file = event.target.files[0];
    this.selectedFile = file;
  }

  editProductGrocery()
  {
    if(this.editProduct.valid)
    {
      const formData = new FormData();
      formData.append('productId', this.route.snapshot.params['id']);
      formData.append('productName', this.editProduct.value.productName);
      formData.append('productDescription', this.editProduct.value.productDescription);
      formData.append('productQuantity', this.editProduct.value.productQuantity);
      formData.append('productPrice', this.editProduct.value.productPrice);
      formData.append('productDiscount', this.editProduct.value.productDiscount);
      formData.append('productSpecification', this.editProduct.value.productSpecification);
      if (this.selectedFile) {
        formData.append('productImageURL', this.selectedFile, this.selectedFile.name);
      }
      formData.append('categoryEntityId', this.editProduct.value.categoryEntityId);

      this.productService.updateProduct(formData).subscribe( (result) =>{
        if(result)
        {
          this.alert = true;
          setTimeout(() => {
            this.router.navigate(["/product"]);
          }, 3000);
        }
      })
    }
  }

  closeAlert()
  {
    this.alert = false;
  }
}
