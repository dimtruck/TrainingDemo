using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.Helpers
{
    public static class ImageHelper
    {
        public static MvcHtmlString GenderImage(this HtmlHelper htmlHelper,
            Gender source, string alternativeText)
        {
            //declare the html helper 
            var builder = new TagBuilder("image");
            //hook the properties and add any required logic
            string imageSource = String.Empty;
            switch (source)
            {
                case Gender.MALE:
                    imageSource = "~/Content/man.png";
                    break;
                case Gender.FEMALE:
                    imageSource = "~/Content/woman.png";
                    break;
                default:
                    break;
            }
            builder.MergeAttribute("src", 
                UrlHelper.GenerateContentUrl(
                imageSource, new HttpContextWrapper(HttpContext.Current)));
            builder.MergeAttribute("alt", alternativeText);
            //create the helper with a self closing capability
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        } 
    }
}