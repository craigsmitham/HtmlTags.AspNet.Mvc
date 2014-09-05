using System;
using HtmlTags.Conventions;

namespace HtmlTags.AspNet.Mvc
{
    public class HtmlTagsConfiguration
    {
        public static readonly HtmlTagsConfiguration Configuration = new HtmlTagsConfiguration();

        private HtmlTagsConfiguration()
        {
            Conventions = new HtmlConventionLibrary();
            DefaultFormBlockBuilderFactory = () => new DefaultFormBlockBuilder();
        }

        public HtmlConventionLibrary Conventions { get; private set; }
        public Func<IFormBlockBuilder> DefaultFormBlockBuilderFactory { get; set; }
    }
}