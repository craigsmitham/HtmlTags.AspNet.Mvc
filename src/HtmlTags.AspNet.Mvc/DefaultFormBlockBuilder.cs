namespace HtmlTags.AspNet.Mvc
{
    internal sealed class DefaultFormBlockBuilder : IFormBlockBuilder
    {
        public HtmlTag Build(bool hasErrors, HtmlTag block, HtmlTag label, HtmlTag input, HtmlTag validaton)
        {
            return block.Append(label).Append(input).Append(validaton);
        }
    }
}