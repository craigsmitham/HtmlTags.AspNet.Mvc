using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Web.Mvc;

namespace HtmlTags.AspNet.Mvc
{

    public static class LinkHelpers
    {
        public static HtmlTag Link(this HtmlHelper htmlHelper, string url)
        {
            return new HtmlTag("a").Attr("href", url);
        }


        public static HtmlTag Link(this HtmlHelper htmlHelper, string linkText, string url)
        {
            return new HtmlTag("a").Attr("href", url).Text(linkText);
        }


        public static HtmlTag Link(this HtmlHelper htmlHelper, string actionName, object routeValues)
        {
            return Link(htmlHelper, null, actionName, null, routeValues);
        }

        public static HtmlTag Link(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues)
        {
            return Link(htmlHelper, linkText, actionName, null, routeValues);
        }

        public static HtmlTag Link(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var url = routeValues != null
                ? urlHelper.Action(actionName, controllerName, routeValues)
                : urlHelper.Action(actionName, controllerName);
            return new HtmlTag("a").Attr("href", url).Text(linkText);
        }

        public static HtmlTag Link<TController>(this HtmlHelper helper, Expression<Action<TController>> action, Action<HtmlTag> linkConfiguration = null)
            where TController : Controller
        {
            var url = LinkBuilder.BuildUrlFromExpression(
                helper.ViewContext.RequestContext,
                RouteTable.Routes, action);
            return new HtmlTag("a", t =>
            {
                t.Attr("href", url);
                if (linkConfiguration != null)
                    linkConfiguration(t);
            });
        }

        public static HtmlTag Link<TController>(this HtmlHelper helper, Expression<Action<TController>> action, string linkText)
            where TController : Controller
        {
            return Link(helper, action, a => a.Text(linkText));
        }
    }
}