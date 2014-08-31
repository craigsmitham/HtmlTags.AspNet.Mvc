using System;

namespace HtmlTags.AspNet.Mvc.Bootstrap.Conventions
{
    public static class ConfigurationHelper
    {
        public static void UseBootstrapConventions(this HtmlTagsConfiguration configuration, Action<BootstrapHtmlConventions> conventionConfiguration = null)
        {
            configuration.AddConventions(new BootstrapHtmlConventions(conventionConfiguration));
        }
    }
}