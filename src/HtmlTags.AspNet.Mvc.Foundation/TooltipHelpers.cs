using System;

namespace HtmlTags.AspNet.Mvc.Foundation
{
    public static class TooltipHelpers
    {
        public static HtmlTag Tooltip(this HtmlTag tag, string text, Position position = Position.Default)
        {
            var positionClass =
                position == Position.Bottom ? "tip-bottom"
                : position == Position.Top ? "tip-top"
                : position == Position.Left ? "tip-left"
                : position == Position.Right ? "tip-right"
                : string.Empty;

            return tag
                .BooleanAttr("data-tooltip")
                .Attr("aria-haspopup", "true")
                .AddClasses("has-tip", positionClass)
                .Attr("title", text);
        }

        public enum Position
        {
            Default,
            Bottom,
            Top,
            Left,
            Right
        }
    }
}