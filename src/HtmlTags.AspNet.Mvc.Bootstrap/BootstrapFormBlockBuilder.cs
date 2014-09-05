using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace HtmlTags.AspNet.Mvc.Bootstrap
{
    internal sealed class BootstrapFormBlockBuilder : IFormBlockBuilder
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