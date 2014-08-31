using System;
using FubuMVC.Core.UI;

namespace HtmlTags.AspNet.Mvc
{
    public static class ConfigurationHelper
    {
        public static void UseDefaultAspNetMvcHtmlConventions(this HtmlTagsConfiguration configuration, Action<HtmlConventionRegistry> conventionConfiguration = null)
        {
            configuration.AddConventions(new DefaultHtmlConventions(), conventionConfiguration);
        }
    }
}