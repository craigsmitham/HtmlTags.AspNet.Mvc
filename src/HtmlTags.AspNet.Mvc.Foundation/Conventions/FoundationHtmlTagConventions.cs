using System;
using FubuMVC.Core.UI;

namespace HtmlTags.AspNet.Mvc.Foundation.Conventions
{
    public class FoundationHtmlConventions : HtmlConventionRegistry
    {
        public FoundationHtmlConventions(Action<FoundationHtmlConventions> configurator = null)
        {
            // Set defaults

            if (configurator != null)
                configurator(this);

            // TODO Button category
            // TODO Alert category
            // TODO Panels category
            // TODO Tooltips category
        }
    }
}