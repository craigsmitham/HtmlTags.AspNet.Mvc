using HtmlTags.Conventions;

namespace HtmlTags.AspNet.Mvc
{
    public class HtmlTagsConfiguration
    {
        public static readonly HtmlTagsConfiguration Configuration = new HtmlTagsConfiguration();

        private HtmlTagsConfiguration()
        {
            Conventions = new HtmlConventionLibrary();
        }

        public HtmlConventionLibrary Conventions { get; private set; }
    }
}