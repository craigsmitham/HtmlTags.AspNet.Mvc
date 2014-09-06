using System;
using System.Runtime.Remoting.Messaging;
using FubuMVC.Core.UI;
using FubuMVC.Core.UI.Elements;

namespace HtmlTags.AspNet.Mvc.Foundation.Conventions
{
    public class FoundationHtmlConventions : HtmlConventionRegistry
    {
        public ElementCategoryExpression Alerts
        {
            get
            {
                var builderSet = Library
                    .For<ElementRequest>()
                    .Category(ElementConstants.Alerts)
                    .Defaults;

                return new ElementCategoryExpression(builderSet);
            }
        }
        public FoundationHtmlConventions(Action<FoundationHtmlConventions> configurator = null)
        {
            // Set defaults

            if (configurator != null)
                configurator(this);

            Alerts.Always.BuildBy<FoundationAlertBuilder>();

            // TODO Button category
            // TODO Alert category
            // TODO Panels category
            // TODO Tooltips category
        }
    }
}