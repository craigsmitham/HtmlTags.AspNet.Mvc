using System;
using FubuMVC.Core.UI;
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

        public void AddConventions(HtmlConventionRegistry conventions,
            Action<HtmlConventionRegistry> configuration = null)
        {
            if (configuration != null)
                configuration(conventions);

            Conventions.Import(conventions.Library);
        }
    }
}