namespace Mvc_Example.Models.ModelMetadataTypes
{
    public class ProductMetadata
    {
        //Productdaki Data annotations verilerinin bulunduğu yeni bir kısım oluşturduk 
        //[Required(ErrorMessage ="Lütfen product Name 'i giriniz")]
        //[StringLength(100)]
        public string ProductName { get; set; }
    }
}
