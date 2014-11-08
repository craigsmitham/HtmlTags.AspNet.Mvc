using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace HtmlTags.AspNet.Mvc.Bootstrap
{
    public static class IconHtmlHelper
    {
        public static HtmlTag IconLink(this HtmlHelper htmlHelper, Glyphicons icon, string linkText, string url)
        {
            return htmlHelper.Link(url, ConfigureIcon(icon, linkText));
        }

        public static HtmlTag IconLink<TController>(this HtmlHelper htmlHelper, Glyphicons icon, string linkText, Expression<Action<TController>> controllerAction) where TController : Controller
        {
            return htmlHelper.Link(controllerAction, ConfigureIcon(icon, linkText));
        }

        private static Action<HtmlTag> ConfigureIcon(Glyphicons icon, string linkText)
        {
            return tag =>
            {
                tag.Append(Glyphicon.Create(icon));
                tag.AppendHtml("&nbsp;");
                tag.AppendHtml(linkText);
            };
        }
    }
}