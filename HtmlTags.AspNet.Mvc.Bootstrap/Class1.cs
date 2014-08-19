using FubuMVC.Core.UI;

namespace HtmlTags.AspNet.Mvc.Bootstrap
{
    public class BootstrapHtmlConventions : DefaultHtmlConventions
    {
        public BootstrapHtmlConventions()
        {
            Editors.Always.AddClass("form-controll");
            // Razor
            // @Html.Editor(m => m.FirstName).AddClass("le-custom")
            // <input class="form-control" ...
        }
    }

    public static class ConfigurationHelper
    {
        public static void UseBootstrapConventions(this HtmlTagsConfiguration configuration)
        {
            configuration.Conventions.Import(new BootstrapHtmlConventions().Library);
        }
    }
}