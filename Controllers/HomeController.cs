using Microsoft.AspNetCore.Mvc;

namespace Mvc_Example.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           

            return View(); // İceriye veri alınarak da tetikleme yaparsam eğer View object yapısı verip bunu razor kullanarak ön tarafta kullana bilirim 
        }


        public IActionResult IndexSecond()
        {
            //return View("IndexSecond"); //Aynı klasörde farklı view tetiklemek için kullanılır 

            return View(); // İceriye veri alınarak da tetikleme yaparsam eğer View object yapısı verip bunu razor kullanarak ön tarafta kullana bilirim 
        }


        public IActionResult IndexThird()
        {
           // Bu kısımda hazır templade ile View oluşturmasını görümüş olduk 

            return View(); // İceriye veri alınarak da tetikleme yaparsam eğer View object yapısı verip bunu razor kullanarak ön tarafta kullana bilirim 
        }
    }
}
