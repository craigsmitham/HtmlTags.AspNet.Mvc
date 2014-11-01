using System.Text.RegularExpressions;

namespace HtmlTags.AspNet.Mvc.Bootstrap
{
    public static class Glyphicon
    {
        public static HtmlTag Create(Glyphicons glyphicons)
        {
            var iconClass = Regex.Replace(glyphicons.ToString(), "([A-Z])", " $1").Trim().ToLower().Replace(' ', '-');
            return new HtmlTag("span").AddClasses("glyphicon", string.Format("glyphicon-{0}", iconClass));
        }
    }
}