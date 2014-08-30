using HtmlTags.AspNet.Mvc.Conventions;

namespace HtmlTags.AspNet.Mvc
{
    public static class ConfigurationHelper
    {
        public static void UseDefaultAspNetMvcHtmlConventions(this HtmlTagsConfiguration configuration)
        {
            configuration.Conventions.Import(new DefaultAspNetMvcHtmlConventions().Library);
        }
    }
}