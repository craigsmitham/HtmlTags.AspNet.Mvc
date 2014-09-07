using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using FubuCore.Reflection;
using FubuMVC.Core.UI.Elements;
using HtmlTags.Conventions;
using ElementConstants = HtmlTags.AspNet.Mvc.Conventions.ElementConstants;

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

        public static HtmlTag Validator<T>(
            this HtmlHelper<T> helper,
            Expression<Func<T, object>> expression,
            string category = ElementConstants.FormValidators) where T : class
        {
            var expressionText = ExpressionHelper.GetExpressionText(expression);
            var fullHtmlFieldName
                = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expressionText);

            if (!helper.ViewData.ModelState.ContainsKey(fullHtmlFieldName))
                return new NoTag();

            var modelState = helper.ViewData.ModelState[fullHtmlFieldName];
            var modelErrorCollection = modelState == null
                ? null
                : modelState.Errors;
            var error = modelErrorCollection == null || modelErrorCollection.Count == 0
                ? null
                // TODO: Should we render all messages, not just first?
                : modelErrorCollection.FirstOrDefault(m => !string.IsNullOrEmpty(m.ErrorMessage))
                ?? modelErrorCollection[0];
            if (error == null)
                return new NoTag();
            // End of MVC code

            var tagGeneratorFactory = DependencyResolver.Current.GetService<ITagGeneratorFactory>();
            var tagGenerator = tagGeneratorFactory.GeneratorFor<ElementRequest>();
            var request = new ElementRequest(expression.ToAccessor())
            {
                Model = helper.ViewData.Model,
            };

            var tag = tagGenerator.Build(request, category);

            tag.Text(error.ErrorMessage);

            return tag;
        }


        public static HtmlTag FormBlock<T>(this HtmlHelper<T> htmlHelper, Expression<Func<T, object>> expression,
           Action<HtmlTag> blockTagConfiguraiton = null,
           Action<HtmlTag> labelTagConfiguration = null,
           Action<HtmlTag> inputTagConfiguration = null,
           Action<HtmlTag> validationTagConfiguration = null,
           IFormBlockBuilder formBlockBuilder = null
            ) where T : class
        {
            formBlockBuilder = formBlockBuilder ?? HtmlTagsConfiguration.Configuration.DefaultFormBlockBuilderFactory();

            var block = new HtmlTag("div");
            if (blockTagConfiguraiton != null)
                blockTagConfiguraiton(block);

            var validation = htmlHelper.Validator(expression);
            var hasErrors = !String.IsNullOrEmpty(validation.Text());
            if (validationTagConfiguration != null)
                validationTagConfiguration(validation);

            var label = htmlHelper.Label(expression);
            if (labelTagConfiguration != null)
                labelTagConfiguration(label);

            var input = htmlHelper.Input(expression);
            if (inputTagConfiguration != null)
                inputTagConfiguration(input);

            return formBlockBuilder.Build(hasErrors, block, label, input, validation);
        }

        private static IElementGenerator<T> GetGenerator<T>() where T : class
        {
            var generator = DependencyResolver.Current.GetService<IElementGenerator<T>>();
            return generator;
        }
    }


}