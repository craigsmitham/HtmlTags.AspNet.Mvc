using System;
using HtmlTags.AspNet.Mvc.Conventions;

namespace HtmlTags.AspNet.Mvc.Bootstrap.Conventions
{
    public static class BootstrapConfigurationHelper
    {
        public static void UseBootstrapConventions(this HtmlTagsConfiguration configuration, Action<BootstrapHtmlConventions> conventionConfiguration = null)
        {
            configuration.AddConventions(new BootstrapHtmlConventions(conventionConfiguration));
            configuration.DefaultFormBlockBuilderFactory = () => new BootstrapFormBlockBuilder();
        }
    }
}