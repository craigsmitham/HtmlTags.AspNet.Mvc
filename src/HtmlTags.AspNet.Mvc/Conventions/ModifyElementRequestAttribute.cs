using System;
using FubuMVC.Core.UI.Elements;

namespace HtmlTags.AspNet.Mvc.Conventions
{
    public abstract class ModifyElementRequestAttribute : Attribute
    {
        public abstract void Modify(ElementRequest reqquest);
    }
}