using System;

namespace HtmlTags.AspNet.Mvc.Conventions
{
    public static class ConfigurationHelper
    {
        public static void UseDefaultHtmlConventions(this HtmlTagsConfiguration configuration, Action<AspNetMvcHtmlConventions> conventionConfiguration = null)
        {
            configuration.AddConventions(new AspNetMvcHtmlConventions(conventionConfiguration));
        }
    }
}