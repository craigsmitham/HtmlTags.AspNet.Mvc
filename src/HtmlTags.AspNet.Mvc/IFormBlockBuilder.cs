namespace HtmlTags.AspNet.Mvc
{
    public interface IFormBlockBuilder
    {
        HtmlTag Build(bool hasErrors, HtmlTag block, HtmlTag label, HtmlTag input, HtmlTag validaton);
    }
}