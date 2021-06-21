using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFCLPortal.Controllers;
using TFCLPortal.ProductMarkupRates;
using TFCLPortal.ProductMarkupRates.Dto;

namespace TFCLPortal.Web.Controllers
{
    public class ProductController : TFCLPortalControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IProductDetailAppService _productDetailAppService;
        public ProductController(IProductAppService productAppService,
            IProductDetailAppService productDetailAppService)
        {
            _productAppService = productAppService;
            _productDetailAppService = productDetailAppService;
        }
        public IActionResult Productlist()
        {
            var productsLists = _productAppService.GetAllProducts();
            return View(productsLists);
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductDto createProduct)
        {
            var product = _productAppService.CreateProduct(createProduct);

            return RedirectToAction("Productlist");
        }

        public IActionResult UpdateProduct(int Id)
        {
            var updateproduct = _productAppService.GetProductById(Id);

            return View(updateproduct);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductDto Productlist)
        {
            var updateproduct = _productAppService.UpdateProduct(Productlist);

            return RedirectToAction("Productlist");
        }

        public IActionResult AddProductDetail()
        {
            var url = HttpUtility.ParseQueryString(new Uri(HttpContext.Request.Headers["Referer"]).Query);
            var values=url.Get("Fk_ProductId");
            ViewBag.products = new SelectList(_productAppService.GetAllProducts(), "Id", "ProductName");
            ViewBag.values = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddProductDetail(CreateProductDetailDto createProductdetail)
        {

            string slabs = createProductdetail.SlabMin + "-" + createProductdetail.SlabMax;
            createProductdetail.Slabs = slabs;
            _productDetailAppService.CreateProductDetail(createProductdetail);

            return RedirectToAction("ProductDetaillist", new { FkProduct = createProductdetail.Fk_ProductId } );
        }
        public IActionResult ProductDetaillist(int FkProduct)
        {
           
           var product =_productAppService.GetProductById(FkProduct);
             
            return View(product);
        }

        public IActionResult UpdateProductDetail(int Id)
        {
            var updateproduct = _productDetailAppService.GetProductDetailById(Id);
            ViewBag.products = new SelectList(_productAppService.GetAllProducts(), "Id", "ProductName");
            return View(updateproduct);
        }

        [HttpPost]
        public IActionResult UpdateProductDetail(UpdateProductDetailDto Productlist)
        {
            var updateproduct = _productDetailAppService.UpdateProductDetail(Productlist);
            return RedirectToAction("ProductDetaillist", new { FkProduct = Productlist.Fk_ProductId });
        }

    }
}