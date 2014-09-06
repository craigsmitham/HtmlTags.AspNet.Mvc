using HtmlTags.AspNet.Mvc;
using HtmlTags.AspNet.Mvc.Conventions;
using HtmlTags.AspNet.Mvc.Foundation.Conventions;

namespace MvcWebsite
{
    public static class HtmlTagsConfig
    {
        public static void Configure(HtmlTagsConfiguration config)
        {
            config.UseDefaultHtmlConventions();
            config.UseFoundationConventions(c =>
            {
                c.Alerts.Always.AddClass("rounded");
            });
        }
    }
}