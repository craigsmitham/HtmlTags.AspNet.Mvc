using System.Globalization;
using FubuMVC.Core.UI.Elements;

namespace HtmlTags.AspNet.Mvc.Conventions
{
    public class TextAreaPropertyNameModifier : IElementModifier
    {
        public bool Matches(ElementRequest token)
        {
            return token.Accessor.FieldName.EndsWith("TextArea", true, CultureInfo.CurrentCulture);
        }

        public void Modify(ElementRequest request)
        {
            TagHelpers.ToTextArea(request);
        }
    }
}