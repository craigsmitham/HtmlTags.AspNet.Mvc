using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace HtmlTags.AspNet.Mvc.Foundation
{
    public static class FormHelpers
    {
        /// <summary>
        /// Generates a label, input, and any validation errors
        /// </summary>
        public static HtmlTag LabelInputBlock<T>(this HtmlHelper<T> htmlHelper, Expression<Func<T, object>> expression) where T : class
        {
            //TODO Errors/validation
            var label = htmlHelper.Label(expression);
            var input = htmlHelper.Input(expression);
            return label.Append(input);
        }

        /// <summary>
        /// Generates an input with conventional placeholder text and any validation errors
        /// </summary>
        public static HtmlTag PlaceholderInputBlock<T>(this HtmlHelper<T> htmlHelper, Expression<Func<T, object>> expression) where T : class
        {
            //TODO Errors/validation
            var input = htmlHelper.InputWithPlaceholder(expression);
            return input;
        }
    }
}