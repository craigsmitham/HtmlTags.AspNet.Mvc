using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Web.Mvc;

namespace HtmlTags.AspNet.Mvc
{
    public static class LinkHelper
    {
        public static HtmlTag Link<TController>(this HtmlHelper helper, Expression<Action<TController>> action, string linkText)
            where TController : Controller
        {
            var url = LinkBuilder.BuildUrlFromExpression(
                helper.ViewContext.RequestContext,
                RouteTable.Routes, action);
            return new HtmlTag("a", t =>
            {
                t.Text(linkText);
                t.Attr("href", url);
            });
        }
    }
}