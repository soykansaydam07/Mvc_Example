using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_Example.Models;
using Mvc_Example.Models.Validators;
using Mvc_Example.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Mvc_Example.Controllers
{
    public class ProductController : Controller
    {

        #region Action Types
        
        //Action Types//

        #region ViewResult
        // View render etmek sırasında ilgili gelen result ı render etmek için client tarafına gönderiri

        //public ViewResult GetProducts()
        //{
        //    ViewResult result = View();
        //    return result;
        //}

        #endregion

         #region PartielViewResult

        //Client Tabanlı Ajax isteklerinde yapılıyorsa bu sistemin kullanımına yatkındır 
        // Böyle olmasının sbebi bir parca da render edilmesi gerekmete ise doğrudan tüm render ı yapıcağına parça render edilir 

        //public PartialViewResult GetProducts()
        //{
        //    PartialViewResult result = PartialView();
        //    return result;
        //}

        #endregion

        #region JsonResult

        //public JsonResult GetProducts()
        //{
        //JsonResult result = Json(new Product
        //{
        //    Id = 1,
        //    ProductName = "Computer",
        //    Quantity = 3
        //});
        //}

        #endregion

        #region EmptyResult

        // Bazı isteklerde değer döndürülmeye gerek yoktur Response var ama değer yoktur

        //public EmptyResult GetProducts()
        //{
        //    return new EmptyResult();
        //}

        // void ile aynı anlamda

        #endregion

        #region ContentResult

        // Bu kısımda metinsel ifade text tabanlı ifadelerde kullanılır gennellikle ajax için json ve content tarafları kullanılmaktadır 

        //public ContentResult GetProducts()
        //{
        //    ContentResult result = Content("Testing Testing");
        //    return result;

        //}

        #endregion

        #region ActionResult

        // Bütün result türlerinin base kısmıdır aslında birden fazla döndürme tipin olduğunda kullanman gereken dosya 

        //public ActionResult GetProducts()
        //{
        //    if (true)
        //    {
        //        return Json(new object())
        //    }
        //    else
        //    {
        //        return Content("Testing");
        //    }
        //}

        #endregion

        #region IActionResult

        //Polimorfizm kurallarına uyulması için genellikle kullanılır Action ile aynı görevdedir 

        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        #endregion

        #region ViewCompnentResult

        //ViewCompanentResult kısmıda gelen yanıta göre bir view companent render etmektedir 

        #endregion
       
        #endregion

        #region NonAcitonTypes
        
        //Non Action kısmında ise controllerda olup dışardan tetiklenmesi istenmeyen türdeki metotlar
        //tavsiye edilmez fakat kullanım için Data annotions tagı kullanılarak bu durum yapılır 

        //public ViewResult GetProducts()
        //{
        //    ViewResult result = View();
        //    return result;
        //}

        //[NonAction]
        //public void X()
        //{

        //}

        //[NonController] controller tarafında  yapılan ve dışarıdan tetiklenmemesi için yapılmış bir attribute dur
        
        #endregion

        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product {Id = 1, ProductName  = "A Product", Quantity = 10},
                new Product {Id = 2, ProductName  = "B Product", Quantity = 15},
                new Product {Id = 3, ProductName  = "C Product", Quantity = 20}
            };


            #region Model Bazlı Veri Gönderimi

            // return View(products);  //Yukarıdaki ilgili veriyi göndermek için bu şekilde kullanıyoruz 

            #endregion

            #region Veri Taşıma Kontrolleri

            #region ViewBag
            // View e gönderilecek datayı dinamik şekilde taşınmasını sağlamaktadır 

            //ViewBag.Products = products;

            #endregion

            #region ViewData
            //ViewBag de olduğu gibi Action daki datayı view ve taşır (Boxing Edilerek taşır)

            ViewData["products"] = products;

            #endregion

            #region TempData
            //ViewData de olduğu gibi Action daki datayı view ve taşır (Boxing Edilerek taşır)
            //redirect işlemlerinde bu yapı kullanılmaktadır Render edilmeden Farklı actiona gitmek için kullanılır 
            //Aktarım sırasında veri cookie oluşturacağı için aktarımda serialize ve deserialize işlemleri yapılmalıdır 

            TempData["products"] = JsonSerializer.Serialize(products);

            //return RedirectToAction("IndexRoute","Product");
            #endregion

            #endregion

            return View(); //Render seviyesi için gönderim bulunmaktadır

            
        }
        
        public IActionResult IndexRoute()
        {
            var data = TempData["products"].ToString();
            List<Product> products =  JsonSerializer.Deserialize<List<Product>>(data);
            return View();
        }

        public IActionResult GetProducts()
        {
            //View Mode ile bu iş yapılabilir ayrıca turple nesnesi ile bu durum halledelebilir

            Product product = new Product
            {
                Id = 1,
                ProductName = "A Product",
                Quantity = 10,
            };

            User user = new User
            {
                Id = 1,
                Name = "Soykan",
                LastName = "Saydam"
            };

            //UserProduct userProduct = new UserProduct
            //{
            //    Product = product,
            //    User = user,
            //};

            //return View(userProduct);

            var userProduct = (product, user); //turple nesnesi olduğunu otomatik anlar 
            return View(userProduct);
        }

        public IActionResult CreateProduct()
        {
            Product product = new Product
            {
                Id = 1,
                ProductName = "A Product",
                Quantity = 10,
            };
            return View(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProductSecond(IFormCollection productData)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProductThird(string Id,string ProductName,string Quantity)
        {
            return View();
        }

        public IActionResult GetProductData([FromQuery] Product product)
        {
            //Yukarıdada aynı şekilde böyle yakalayabilmekteyiz 

            var queryString = Request.QueryString; //QueryString parametresi string parametresi eklenmiş bunun bilgisini verir.
            var a = Request.Query["a"].ToString();  //QueryString parametreyi algılamak için kullanabiliriz 

            var value = Request.RouteValues; //Bu kısımdada root parametresi ile  veri alınıabilir 
            
            return View();
        }

        [HttpPost]
        public IActionResult GetProductValues(Product product){

            //Headers bu şekilde alınıp özellikle token authorise sistemlerde kullanılır 

            //Header da türkçe karakter kullanılmaz 

            var headers = Request.Headers;

            return View();
        }

        public IActionResult GetValidation(Product product)
        {
           
            //product = new Product()
            //{
            //    ProductInfos = new List<ProductInfo>()
            //    {
            //        new ProductInfo()
            //        {
            //            ProductDescription = null
            //        }
            //    }
            //};

            //ModelState : Data Annotationslarının durumunu kontrol eden ve geriye sonuç dönen property

            //ModelState.Values.ResultView ile hangisi hatalı bulubilmektedir 
            ProductValidator validator = new ProductValidator();

            //validator.ValidateAndThrow(product);
            //Validate edilmiş veride throw oluşturarak işlemi bitirmek için kullanılabilir  


          
            var resultOnlyProduct = validator.Validate(product, options => options.IncludeRuleSets("ProductPrivateRule"));



            ValidationResult result = validator.Validate(product);

            if (result.IsValid)
            {
                // Geçerli öğrenci modeli, validation’dan geçti.
                
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                
            }


            //if (!ModelState.IsValid)
            //{
            //    //Hatalı ise 
            //    var messages = ModelState.ToList();



            //    //Altta viewbag tarafında hatalı verilerin görünmesini sağlar
            //    //ViewBag.HataMesaj = ModelState.Values.
            //    //    FirstOrDefault(x => x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).
            //    //    Errors[0].ErrorMessage;

            //    return View(product);
            //}
            
            
            
            return View();

            //return View(product);
        }

    }
}
