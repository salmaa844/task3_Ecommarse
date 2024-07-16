using AutoMapper;
using Ecommerce.API.mapping_profile;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Entities.DTO;
using Ecommerce.Core.IRepositories;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IUnitOfWork<Products> unitOfWork;
        private readonly IMapper mapper;

        public ApiResponse response;
        //private readonly IGenricRepositorycs<Products> genricRepositorycs;



        public ProductController(IUnitOfWork<Products> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            response = new ApiResponse();
            this.mapper = mapper;

        }
            [HttpGet]
            public async Task<ActionResult<ApiResponse>> GetAll()
            {
               
                var model = await unitOfWork.ProductRepository.GetAll();
                var check = model.Any();
            if (check)
            {
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.IsSuccess = check;
                var mappedProducts = mapper.Map<IEnumerable<Products>, IEnumerable<ProductPostDTO>>(model);
                response.Result = mappedProducts;
                //response.Result = model;
                return response;
            }
            else
            {
                response.ErrorMessage = "No products found";
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.IsSuccess = false;
                return response;
            }
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<ApiResponse>> GetById(int id)
            {
               
                var model = await unitOfWork.ProductRepository.GetById(id);
                return Ok(model);
            }
            [HttpPost]
            public async Task<ActionResult<ApiResponse>> CreateProduct(Products model)
            {
            

                await unitOfWork.ProductRepository.Create(model);
                await unitOfWork.Save();
                return Ok(model);
            }
            
            [HttpPut]
            public async Task<ActionResult> UpdateProduct(Products model)
            {
               
                unitOfWork.ProductRepository.Update(model);
                await unitOfWork.Save();
                return Ok(model);
            }
            [HttpDelete]
            public async Task<ActionResult> DeleteProduct(int id)
            {
                
                unitOfWork.ProductRepository.Delete(id);
                await unitOfWork.Save();
                return Ok();

            }
        [HttpGet("Product/{cat_id}")]
        public async Task<ActionResult<ApiResponse>> GetProductByCatId(int cat_id)
        {
            var products = await unitOfWork.ProductRepository.GetAllProductsByCategoryId(cat_id);
            var mappedProducts = mapper.Map<IEnumerable<Products>, IEnumerable<ProductPostDTO>>(products);
            return Ok(mappedProducts);


        }

    }
    }


