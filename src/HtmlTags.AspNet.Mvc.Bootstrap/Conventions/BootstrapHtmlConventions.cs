using System;
using FubuMVC.Core.UI;

namespace HtmlTags.AspNet.Mvc.Bootstrap.Conventions
{
    public class BootstrapHtmlConventions : HtmlConventionRegistry
    {
        public BootstrapHtmlConventions(Action<BootstrapHtmlConventions> configurator = null)
        {
            if (configurator != null)
                configurator(this);

            Editors.Always.AddClass("form-control");
        }
    }
}