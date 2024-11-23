using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.Custom
{
    [HtmlTargetElement("custom")]
    public class MyCustomTagHelper: TagHelper
    {
        public string Message { get; set; }

        public ModelExpression ProductName { get; set; }
        //public override void Process(TagHelperContext context, TagHelperOutput output)
        //{
        //    output.Content.SetHtmlContent($"<div class='alert alert-warning'>{Message}-{ProductName.Model}</div>");
        //}

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            var existingContent = await output.GetChildContentAsync();
            var existingData = existingContent.GetContent();
            var names = existingData.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach(var item in names)
            {
                output.Content.AppendHtml($"<li>{item}</li>");
            }
            //return base.ProcessAsync(context, output);
        }
    }
}
