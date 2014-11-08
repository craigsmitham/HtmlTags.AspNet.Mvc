using FubuMVC.Core.UI.Elements;

namespace HtmlTags.AspNet.Mvc.Conventions
{
    internal static class TagHelpers
    {
        public static void ToTextArea(ElementRequest request)
        {
            request.CurrentTag.RemoveAttr("type");
            request.CurrentTag.TagName("TextArea");
            request.CurrentTag.AppendHtml(request.Value<string>());
        }
    }
}