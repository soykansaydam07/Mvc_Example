using Mvc_Example.Models.Validators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mvc_Example.Models
{
    //[Validator(typeof(ProductValidator))]
    public class Product
    {
        //[Required(ErrorMessage ="Lütfen product Name 'i giriniz")]
        //[StringLength(100)]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        //[EmailAddress(ErrorMessage ="Lütfen doğru bir email adresi giriniz")]
        public decimal Price { get; set; }
        public string  UserEmail { get; set; }
        public Market MarketData { get; set; }
        //public ProductInfo ProductInfos { get; set; }
        public List<ProductInfo> ProductInfos { get; set; } = new List<ProductInfo>();
        public bool IsFoodProduct { get; set; }
        public bool? IsToolProduct { get; set; } = false;
        public string ProductNumber { get; set; }

        //public IList<ProductInfo> ProductInfoList { get; set; } = new List<ProductInfo>();

    }
}
