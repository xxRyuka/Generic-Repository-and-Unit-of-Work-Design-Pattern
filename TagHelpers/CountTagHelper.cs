using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using rdp.Data.Context;
using rdp.Data.Entities;

namespace rdp.TagHelpers;

[HtmlTargetElement("count-tag",Attributes = "count")]
public class CountTagHelper : TagHelper
{
    
    private readonly BankContext _context;

    public CountTagHelper(BankContext context)
    {
        _context = context;
    }

    [HtmlAttributeName("count")]
    public int _ApplicationUserId { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName="a";
        var count = _context.Accounts.Count(x => x.ApplicationUserId == _ApplicationUserId);
        var msg = $"<span class='badge bg-info text-white text-bolder' style='background: linear-gradient(135deg,rgb(246, 94, 160),rgb(152, 46, 214)); color: #1a202c; text-decoration: none; padding: 8px 15px; border-radius: 5px; font-weight: 600;' >{count} </span>";
        output.Content.SetHtmlContent(msg);
    }
}