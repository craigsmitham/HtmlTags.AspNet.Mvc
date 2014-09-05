using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace HtmlTags.AspNet.Mvc.Foundation
{
    //public static class FormHelpers
    //{
    //    public static HtmlTag FormBlock<T>(this HtmlHelper<T> htmlHelper, Expression<Func<T, object>> expression,
    //        Action<HtmlTag> blockTagConfiguraiton = null,
    //        Action<HtmlTag> labelTagConfiguration = null,
    //        Action<HtmlTag> inputTagConfiguration = null,
    //        Action<HtmlTag> validationTagConfiguration = null) where T : class
    //    {
    //        return htmlHelper.FormBlock(expression, new FoundationFormBlockBuilder(), blockTagConfiguraiton,
    //            labelTagConfiguration, inputTagConfiguration, validationTagConfiguration);
    //    }


    //}

    internal sealed class FoundationFormBlockBuilder : IFormBlockBuilder
    {
        public HtmlTag Build(bool hasErrors, HtmlTag block, HtmlTag label, HtmlTag input, HtmlTag validaton)
        {
            if (hasErrors)
            {
                label.AddClass("error");
                input.AddClass("error");
                validaton.AddClass("error");
            }

            label.Append(input);
            block.Append(label).Append(validaton);
            return block;
        }
    }
}