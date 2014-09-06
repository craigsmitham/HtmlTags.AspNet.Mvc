using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HtmlTags.AspNet.Mvc
{
    public static class ModelStateHelpers
    {
        public static List<string> GetCustomErrors(this HtmlHelper htmlHelper)
        {
            var errors = new List<string>();
            var modelState = htmlHelper.ViewData.ModelState;
            if (modelState == null) return errors;

            var customModelState = modelState[""];
            if (customModelState == null) return errors;

            errors = customModelState.Errors
                .Select(modelError => modelError.ErrorMessage)
                .ToList();

            return errors;
        }
    }
}