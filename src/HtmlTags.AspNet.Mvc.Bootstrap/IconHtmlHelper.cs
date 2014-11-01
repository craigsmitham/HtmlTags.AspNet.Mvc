using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace HtmlTags.AspNet.Mvc.Bootstrap
{
    public static class IconHtmlHelper
    {
        public static HtmlTag IconLink(this HtmlHelper htmlHelper, string linkText, string url, Glyphicons icon)
        {
            return htmlHelper.Link(url).ConfigureIconLink(icon, linkText);
        }

        public static HtmlTag IconLink<TController>(this HtmlHelper htmlHelper, Expression<Action<TController>> controllerAction, Glyphicons icon, string linkText) where TController : Controller
        {
            return htmlHelper.Link(controllerAction, a => a.ConfigureIconLink(icon, linkText));
        }

        private static HtmlTag ConfigureIconLink(this HtmlTag tag, Glyphicons icon, string linkText)
        {
            tag.Append(Glyphicon.Create(icon));
            tag.AppendHtml("&nbsp;");
            tag.AppendHtml(linkText);
            return tag;
        }
    }
}