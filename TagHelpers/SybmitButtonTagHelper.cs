using Microsoft.AspNetCore.Razor.TagHelpers;

namespace OlympicGamesSite.TagHelpers
{
    [HtmlTargetElement("submit-button")]
    public class SubmitButtonTagHelper : TagHelper
    {
        public string Text { get; set; } = "Submit";
        public string CssClass { get; set; } = "btn btn-primary";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.SetAttribute("type", "submit");
            output.Attributes.SetAttribute("class", CssClass);
            output.Content.SetContent(Text);
        }
    }
}
