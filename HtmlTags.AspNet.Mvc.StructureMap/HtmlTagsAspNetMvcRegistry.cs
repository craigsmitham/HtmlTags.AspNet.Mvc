using System.Web;
using FubuCore;
using FubuCore.Binding.Values;
using FubuMVC.Core.Http.AspNet;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.UI;
using FubuMVC.Core.UI.Elements;
using FubuMVC.Core.UI.Security;
using FubuMVC.StructureMap3;
using HtmlTags.Conventions;
using StructureMap.Graph;
using StructureMap.Configuration.DSL;

namespace HtmlTags.AspNet.Mvc.StructureMap
{
    public class HtmlTagsAspNetMvcRegistry : Registry
    {
        public HtmlTagsAspNetMvcRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<IFubuRequest>();
                scan.AssemblyContainingType<ITypeResolver>();
                scan.AssemblyContainingType<ITagGeneratorFactory>();
                scan.AssemblyContainingType<IFieldAccessService>();
                scan.AssemblyContainingType<StructureMapFubuRegistry>();
                scan.AssemblyContainingType<HtmlTagsConfiguration>();

                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.LookForRegistries();
            });


            For<HtmlConventionLibrary>().Use(() => HtmlTagsConfiguration.Configuration.Conventions);

            For<IValueSource>().AddInstances(c =>
            {
                c.Type<RequestPropertyValueSource>();
            });
            For<ITagRequestActivator>().AddInstances(c =>
            {
                c.Type<ElementRequestActivator>();
                c.Type<ServiceLocatorTagRequestActivator>();
            });
            For<HttpRequestBase>().Use(c => c.GetInstance<HttpRequestWrapper>());
            For<HttpContextBase>().Use(c => c.GetInstance<HttpContextWrapper>());

            For<HttpRequest>().Use(() => HttpContext.Current.Request);
            For<HttpContext>().Use(() => HttpContext.Current);

            For<ITypeResolverStrategy>().Use<TypeResolver.DefaultStrategy>();
            For<IElementNamingConvention>().Use<DotNotationElementNamingConvention>();
            For(typeof(ITagGenerator<>)).Use(typeof(TagGenerator<>));
            For(typeof(IElementGenerator<>)).Use(typeof(ElementGenerator<>));
        }
    }
}
