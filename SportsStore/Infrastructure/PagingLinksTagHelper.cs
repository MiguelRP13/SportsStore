using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PagingLinksTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public static int MaxLinksBeforeAndAfterCurrentPage = 7;

        public PagingLinksTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;

        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div");


            int initial = PageModel.CurrentPage - MaxLinksBeforeAndAfterCurrentPage;
            if (initial < 1) initial = 1;
            int final = PageModel.CurrentPage + MaxLinksBeforeAndAfterCurrentPage;
            if (final > PageModel.TotalPages) final = PageModel.TotalPages;

            for (int p = initial; p <= final; p++)
            {
                TagBuilder pageLink = new TagBuilder("a");
                pageLink.Attributes["href"] = urlHelper.Action(PageAction,
                   new { page = p });
                pageLink.InnerHtml.Append(p.ToString());
                result.InnerHtml.AppendHtml(pageLink);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }         
    
} 
