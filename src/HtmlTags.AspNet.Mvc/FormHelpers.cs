using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using FubuMVC.Core.UI.Elements;

namespace HtmlTags.AspNet.Mvc
{
    public static class FormHelpers
    {
        public static HtmlTag Input<T>(this HtmlHelper<T> helper,
            Expression<Func<T, object>> expression)
            where T : class
        {
            var generator = GetGenerator<T>();
            return generator.InputFor(expression, model: helper.ViewData.Model);
        }

        public static HtmlTag Label<T>(this HtmlHelper<T> helper,
            Expression<Func<T, object>> expression)
            where T : class
        {
            var generator = GetGenerator<T>();
            return generator.LabelFor(expression, model: helper.ViewData.Model);
        }

        private static IElementGenerator<T> GetGenerator<T>() where T : class
        {
            var generator = DependencyResolver.Current.GetService<IElementGenerator<T>>();
            return generator;
        }
    }
}