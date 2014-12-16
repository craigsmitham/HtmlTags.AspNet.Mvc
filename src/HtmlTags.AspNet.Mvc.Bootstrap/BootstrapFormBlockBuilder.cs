namespace HtmlTags.AspNet.Mvc.Bootstrap
{
    internal sealed class BootstrapFormBlockBuilder : IFormBlockBuilder
    {
        public HtmlTag Build(bool hasErrors, HtmlTag block, HtmlTag label, HtmlTag input, HtmlTag validaton)
        {
            if (hasErrors)
            {
                label.AddClass("error");
                input.AddClass("error");
                validaton.AddClass("error");
            }

            return block.AddClass("form-group").Append(label).Append(input).Append(validaton);
        }
    }
}