using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc_Example.Extensions
{
    static public class Extensions
    {
        public static IHtmlContent CustomTextBox(this IHtmlHelper htmlHelper,string name ,string value, string placeholder="")
        {
            return htmlHelper.TextBox(name, value, new 
            {
            
                style= "background-color:green; color:white",
                @class="form-input",
                placeholder = placeholder

            });
        }
    }
}
