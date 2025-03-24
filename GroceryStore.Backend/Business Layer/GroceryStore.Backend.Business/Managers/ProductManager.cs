using AutoMapper;
using FluentValidation.Results;
using GroceryStore.Backend.Business.DTO;
using GroceryStore.Backend.Business.Managers.Interface;
using GroceryStore.Backend.Business.UoW;
using GroceryStore.Backend.Business.Validation;
using GroceryStore.Backend.DAL.Entities;
using GroceryStore.Backend.DAL.Repository.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Business.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var response = await _unitOfWork.ProductRepository.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductDTO>>(response);
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            var response = await _unitOfWork.ProductRepository.GetProduct(id);
            /*var response = _mapper.Map<ProductDTO>(product);

            using (var stream = System.IO.File.OpenRead(response.ProductImage))
            {
                response.ProductImageURL = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(response.ProductImage));
            }*/
            return _mapper.Map<ProductDTO>(response);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategory(int categoryId)
        {
            var response = await _unitOfWork.ProductRepository.GetProductsByCategory(categoryId);
            return _mapper.Map<IEnumerable<ProductDTO>>(response);
        }

        public async Task<IEnumerable<ProductDTO>> SearchProduct(string query)
        {
            var response = await _unitOfWork.ProductRepository.SearchProduct(query);
            return _mapper.Map<IEnumerable<ProductDTO>>(response);
        }

        public async Task<int> AddProduct(ProductDTO product)
        {
            var uploadedFile = product.ProductImageURL;

            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                string folder = "images/product/";
                folder += Guid.NewGuid().ToString() + "_" + uploadedFile.FileName;
                //string serverFolder = Path.Combine(_webHostEnvironment.ContentRootPath, folder); -- when we deploy into the server 
                // I use below folder to save the image because i want to use it on the angular and angular can't access the path apart from assests
                string imageUseFolder = Path.Combine("../../../../UI/GroceryStore.UI/src/assets/", folder);
                //uploadedFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
                uploadedFile.CopyTo(new FileStream(imageUseFolder, FileMode.Create));
                product.ProductImage = imageUseFolder;
            }

            ProductValidator productValidator = new ProductValidator();
            ValidationResult result = productValidator.Validate(product);

            if(result.IsValid)
            {
                var entity = _mapper.Map<ProductEntity>(product);
                var response = await _unitOfWork.ProductRepository.AddProduct(entity);
                return response;
            }
            return -1;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var response = await _unitOfWork.ProductRepository.DeleteProduct(id);
            return response;
        }

        public async Task updateQuantity(int id, int decQuantity)
        {
            await _unitOfWork.ProductRepository.updateQuantity(id, decQuantity);
        }

        public async Task<bool> UpdateProduct(ProductDTO updatedProduct)
        {
            var uploadedFile = updatedProduct.ProductImageURL;

            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                string folder = "images/product/";
                folder += Guid.NewGuid().ToString() + "_" + uploadedFile.FileName;
                //string serverFolder = Path.Combine(_webHostEnvironment.ContentRootPath, folder); -- when we deploy into the server 
                // I use below folder to save the image because i want to use it on the angular and angular can't access the path apart from assests
                string imageUseFolder = Path.Combine("../../../../UI/GroceryStore.UI/src/assets/", folder);
                //uploadedFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
                uploadedFile.CopyTo(new FileStream(imageUseFolder, FileMode.Create));
                updatedProduct.ProductImage = imageUseFolder;
            }

            ProductValidator productValidator = new ProductValidator();
            ValidationResult result = productValidator.Validate(updatedProduct);

            if (result.IsValid)
            {
                var entity = _mapper.Map<ProductEntity>(updatedProduct);
                var response = await _unitOfWork.ProductRepository.UpdateProduct(entity);
                return response;
            }
            return false;
        }
    }
}
