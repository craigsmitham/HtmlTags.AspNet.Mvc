using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HtmlTags.AspNet.Mvc.Foundation
{
    public static class AlertHelpers
    {

        public static HtmlTag SuccessAlert(this HtmlHelper htmlHelper, string alertMessage)
        {
            return htmlHelper.Alert("success", alertMessage);
        }

        public static HtmlTag SuccessAlert(this HtmlHelper htmlHelper, List<string> alertMessages)
        {
            return htmlHelper.Alert("success", alertMessages);
        }


        public static HtmlTag WarningAlert(this HtmlHelper htmlHelper, string alertMessage)
        {
            return htmlHelper.Alert("warning", alertMessage);
        }

        public static HtmlTag WarningAlert(this HtmlHelper htmlHelper, List<string> alertMessages)
        {
            return htmlHelper.Alert("warning", alertMessages);
        }


        public static HtmlTag InfoAlert(this HtmlHelper htmlHelper, string alertMessage)
        {
            return htmlHelper.Alert("info", alertMessage);
        }

        public static HtmlTag InfoAlert(this HtmlHelper htmlHelper, List<string> alertMessages)
        {
            return htmlHelper.Alert("info", alertMessages);
        }

        public static HtmlTag ErrorAlert(this HtmlHelper htmlHelper, string alertMessage)
        {
            return htmlHelper.Alert("alert", alertMessage);
        }

        public static HtmlTag ErrorAlert(this HtmlHelper htmlHelper, List<string> alertMessages)
        {
            return htmlHelper.Alert("alert", alertMessages);
        }


        public static HtmlTag SecondaryAlert(this HtmlHelper htmlHelper, string alertMessage)
        {
            return htmlHelper.Alert("secondary", alertMessage);
        }

        public static HtmlTag SecondaryAlert(this HtmlHelper htmlHelper, List<string> alertMessages)
        {
            return htmlHelper.Alert("secondary", alertMessages);
        }

        private static HtmlTag Alert(this HtmlHelper htmlHelper, string alertClass, string alertText)
        {
            return String.IsNullOrWhiteSpace(alertText) ? new NoTag() : htmlHelper.Alert(alertClass).Text(alertText);
        }

        private static HtmlTag Alert(this HtmlHelper htmlHelper, string alertClass, List<string> alertMessages)
        {
            return alertMessages != null && alertMessages.Any()
                ? htmlHelper.Alert(alertClass)
                    .Append("ul", ul => alertMessages.ForEach(m => ul.Append("li", li => li.AppendHtml(m))))
                : new NoTag();
        }

        private static HtmlTag Alert(this HtmlHelper htmlHelper, string alertClass)
        {
            return new HtmlTag("div")
                .BooleanAttr("data-alert")
                .AddClasses("alert-box", alertClass)
                .Append("a", a => a.Attr("href", "#").AddClass("close").AppendHtml("&times;"));
            //var tagGeneratorFactory = DependencyResolver.Current.GetService<ITagGeneratorFactory>();
            //ITagGenerator<ElementRequest> tagGenerator = tagGeneratorFactory.GeneratorFor<ElementRequest>();
            //var tag = tagGenerator.Build(new ElementRequest(null), Conventions.ElementConstants.Alerts);
            //return tag.AddClass(@alertClass);
        }
    }
}