using System;
using HtmlTags.AspNet.Mvc.Conventions;

namespace HtmlTags.AspNet.Mvc.Foundation.Conventions
{
    public static class ConfigurationHelper
    {
        public static void UseFoundationConventions(this HtmlTagsConfiguration configuration, Action<FoundationHtmlConventions> conventionConfiguration = null)
        {
            configuration.AddConventions(new FoundationHtmlConventions(conventionConfiguration));
            configuration.DefaultFormBlockBuilderFactory = () => new FoundationFormBlockBuilder();
        }
    }
}