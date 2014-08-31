using System;
using FubuMVC.Core.UI;

namespace HtmlTags.AspNet.Mvc.Conventions
{
    public static class ConfigurationHelper
    {
        public static void UseDefaultHtmlConventions(this HtmlTagsConfiguration configuration, Action<AspNetMvcHtmlConventions> conventionConfiguration = null)
        {
            configuration.AddConventions(new AspNetMvcHtmlConventions(conventionConfiguration));
        }

        public static void AddConventions(this HtmlTagsConfiguration configuration, Action<HtmlConventionRegistry> conventionRegsitryConfigurator)
        {
            var conventionRegistry = new HtmlConventionRegistry();
            conventionRegsitryConfigurator(conventionRegistry);
            configuration.AddConventions(conventionRegistry);
        }

        public static void AddConventions(this HtmlTagsConfiguration configuration, HtmlConventionRegistry conventionRegistry)
        {
            configuration.Conventions.Import(conventionRegistry.Library);
        }
    }
}