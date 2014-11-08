using FubuCore.Reflection;
using FubuMVC.Core.UI.Elements;

namespace HtmlTags.AspNet.Mvc.Conventions
{
    public class HtmlTagAttributeModifier : IElementModifier
    {
        public bool Matches(ElementRequest token)
        {
            return token.Accessor.HasAttribute<ModifyElementRequestAttribute>();
        }

        public void Modify(ElementRequest request)
        {
            var attribute = request.Accessor.GetAttribute<ModifyElementRequestAttribute>();
            attribute.Modify(request);
        }
    }
}