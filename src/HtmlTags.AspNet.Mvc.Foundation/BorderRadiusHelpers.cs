using System;
using System.Linq.Expressions;

namespace HtmlTags.AspNet.Mvc.Foundation
{
    public static class BorderRadiusHelpers
    {
        public static HtmlTag BorderRadius(this HtmlTag tag)
        {
            return tag.AddClass("radius");
        }

        public static HtmlTag BorderRounded(this HtmlTag tag)
        {
            return tag.AddClass("round");
        }
    }
}