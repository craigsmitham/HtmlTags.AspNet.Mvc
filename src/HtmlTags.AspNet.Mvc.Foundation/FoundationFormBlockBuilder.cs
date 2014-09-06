namespace HtmlTags.AspNet.Mvc.Foundation
{
    internal sealed class FoundationFormBlockBuilder : IFormBlockBuilder
    {
        public HtmlTag Build(bool hasErrors, HtmlTag block, HtmlTag label, HtmlTag input, HtmlTag validaton)
        {
            if (hasErrors)
            {
                label.AddClass("error");
                input.AddClass("error");
                validaton.AddClass("error");
            }

            label.Append(input);
            block.Append(label).Append(validaton);
            return block;
        }
    }
}