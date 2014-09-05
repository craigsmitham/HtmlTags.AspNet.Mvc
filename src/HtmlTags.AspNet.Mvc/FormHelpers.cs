﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using FubuCore.Reflection;
using FubuMVC.Core.UI.Elements;
using HtmlTags.Conventions;

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

        public static HtmlTag InputWithPlaceholder<T>(this HtmlHelper<T> helper,
           Expression<Func<T, object>> expression)
           where T : class
        {
            var generator = GetGenerator<T>();
            // Use label conventions to get placeholder text
            var placeholderText = Label(helper, expression).Text();
            return generator.InputFor(expression, model: helper.ViewData.Model).Attr("placeholder", placeholderText);
        }

        public static HtmlTag Label<T>(this HtmlHelper<T> helper,
            Expression<Func<T, object>> expression)
            where T : class
        {
            var generator = GetGenerator<T>();
            return generator.LabelFor(expression, model: helper.ViewData.Model);
        }

        public static HtmlTag Validator<T>(this HtmlHelper<T> helper, Expression<Func<T, object>> expression) where T : class
        {
            // MVC code don't ask me I just copied
            var expressionText = ExpressionHelper.GetExpressionText(expression);
            string fullHtmlFieldName
                = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expressionText);

            if (!helper.ViewData.ModelState.ContainsKey(fullHtmlFieldName))
                return new NoTag();

            ModelState modelState = helper.ViewData.ModelState[fullHtmlFieldName];
            ModelErrorCollection modelErrorCollection = modelState == null
                ? null
                : modelState.Errors;
            ModelError error = modelErrorCollection == null || modelErrorCollection.Count == 0
                ? null
                : modelErrorCollection.FirstOrDefault(m => !string.IsNullOrEmpty(m.ErrorMessage))
                ?? modelErrorCollection[0];
            if (error == null)
                return new NoTag();
            // End of MVC code

            var tagGeneratorFactory = DependencyResolver.Current.GetService<ITagGeneratorFactory>();
            var tagGenerator = tagGeneratorFactory.GeneratorFor<ElementRequest>();
            var request = new ElementRequest(expression.ToAccessor())
            {
                Model = helper.ViewData.Model
            };

            var tag = tagGenerator.Build(request, "Validator");

            tag.Text(error.ErrorMessage);

            return tag;
        }

        private static IElementGenerator<T> GetGenerator<T>() where T : class
        {
            var generator = DependencyResolver.Current.GetService<IElementGenerator<T>>();
            return generator;
        }
    }
}