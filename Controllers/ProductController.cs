using AJSExample.Data.Dtos;
using AJSExample.Interfaces;
using AJSExample.Models;
using AutoMapper;
using AJSExample.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace AJSExample.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _host;

        public ProductController(IProductRepository repo, IMapper mapper, IWebHostEnvironment host)
        {
            _repo = repo;
            _mapper = mapper;
            _host = host;
        }
        [HttpPost]
        public async Task<JsonResult> SaveProduct([FromBody] CreateProductDto args)
        {
            var product = _mapper.Map<CreateProductDto, Product>(args);
            product.Created_At = DateTime.Now;
            try
            {
                var response = await _repo.SaveProduct(product);
                return Json(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> UploadImage([FromRoute] int id, [FromBody] FileUploadRequest args)
        {
            try
            {
                var product = await _repo.GetProductById(id);

                if (product != null)
                {
                    await _repo.UpdateProductImage(id, args.Name);
                    await Files.WriteFileOnServer(_host.WebRootPath, args);
                    return new JsonResult(new { message = "Algo" });
                }

                return new JsonResult(new { message = "Prodcut Not Found" });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<List<Product>> List()
        {
            try
            {
                return await _repo.ListProducts();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}