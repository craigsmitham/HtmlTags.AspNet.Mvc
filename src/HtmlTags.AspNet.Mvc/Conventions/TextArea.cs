using FubuMVC.Core.UI.Elements;

namespace HtmlTags.AspNet.Mvc.Conventions
{
    public class TextArea : ModifyElementRequestAttribute
    {
        public override void Modify(ElementRequest request)
        {
            TagHelpers.ToTextArea(request);
        }
    }
}