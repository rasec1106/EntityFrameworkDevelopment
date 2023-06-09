﻿using ApiProduct.DTOs;
using ApiProduct.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiProduct.Controllers
{
    [Route("api/[controller]")] // set the basepath; controller is an env variable to take the name of the Class
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;
        private ResponseDto responseDto;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            this.responseDto = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await productRepository.GetProducts();
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = productDtos;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                // this.responseDto.Result = null;
                this.responseDto.DisplayMessage = ex.ToString();
            }            
            return responseDto;            
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDto = await productRepository.GetProductById(id);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = productDto;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                // this.responseDto.Result = null;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }

        [HttpPost]
        public async Task<object> Post(ProductDto productDto)
        {
            try
            {
                ProductDto result = await productRepository.CreateProduct(productDto);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = result;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                // this.responseDto.Result = null;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }

        [HttpPut]
        public async Task<object> Put(ProductDto productDto)
        {
            try
            {
                ProductDto result = await productRepository.UpdateProduct(productDto);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = result;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                // this.responseDto.Result = null;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }

        [HttpDelete]
        // even of we don't define the Route decorator, .net is clever enough to understand that the id is passed as a path variable
        public async Task<object> Delete(int id)
        {
            try
            {
                bool result = await productRepository.DeleteProduct(id);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = result;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                // this.responseDto.Result = null;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }

        [HttpGet]
        [Route("/getByCategory/{categoryCode}")]
        public async Task<object> Get(string categoryCode)
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await productRepository
                            .GetProductsByCategoryCode(categoryCode);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = productDtos;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }
    }
}
