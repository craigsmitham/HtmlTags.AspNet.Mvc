using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Web.Mvc;

namespace HtmlTags.AspNet.Mvc
{

    public static class LinkHelpers
    {
        public static HtmlTag Link(this HtmlHelper htmlHelper, string url, Action<HtmlTag> configure = null)
        {
            return Link(a => a.Attr("href", url), configure);

        }

        private static HtmlTag Link(Action<HtmlTag> baseConfigure, Action<HtmlTag> optionalConfigure)
        {
            return new HtmlTag("a", a =>
            {
                baseConfigure(a);
                if (optionalConfigure != null)
                    optionalConfigure(a);
            });
        }


        public static HtmlTag Link(this HtmlHelper htmlHelper, string linkText, string url, Action<HtmlTag> configure = null)
        {
            return Link(a => a.Attr("href", url).Text(linkText), configure);
        }


        public static HtmlTag Link(this HtmlHelper htmlHelper, string actionName, object routeValues, Action<HtmlTag> configure = null)
        {
            return Link(htmlHelper, null, actionName, null, routeValues, configure);
        }

        public static HtmlTag Link(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, Action<HtmlTag> configure = null)
        {
            return Link(htmlHelper, linkText, actionName, null, routeValues, configure);
        }

        public static HtmlTag Link(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, Action<HtmlTag> configure = null)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var url = routeValues != null
                ? urlHelper.Action(actionName, controllerName, routeValues)
                : urlHelper.Action(actionName, controllerName);
            return Link(htmlHelper, linkText, url, configure);
        }

        public static HtmlTag Link<TController>(this HtmlHelper htmlHelper, Expression<Action<TController>> action, Action<HtmlTag> configure = null)
            where TController : Controller
        {
            var url = LinkBuilder.BuildUrlFromExpression(
                htmlHelper.ViewContext.RequestContext,
                RouteTable.Routes, action);
            return Link(htmlHelper, url, configure);
        }

        public static HtmlTag Link<TController>(this HtmlHelper htmlHelper, string linkText, Expression<Action<TController>> action, Action<HtmlTag> configure = null)
            where TController : Controller
        {

            return Link(htmlHelper, action, a =>
            {
                a.Text(linkText);
                if (configure != null)
                    configure(a);
            });
        }
    }
}