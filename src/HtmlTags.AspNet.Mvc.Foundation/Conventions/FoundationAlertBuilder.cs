using FubuMVC.Core.UI.Elements;

namespace HtmlTags.AspNet.Mvc.Foundation.Conventions
{
    internal sealed class FoundationAlertBuilder : IElementBuilder
    {
        public HtmlTag Build(ElementRequest request)
        {
            var close = new HtmlTag("a").Attr("href", "#").AddClass("close").AppendHtml("&times;");
            return new HtmlTag("div").BooleanAttr("data-alert").AddClass("alert-box").Append(close);
        }
    }
}