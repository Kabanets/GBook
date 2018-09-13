using GBook.Models;
using System;
using System.Web.Mvc;

namespace GBook.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(
            this HtmlHelper html,
            PagingInfo pagingInfo,
            Func<int, string> pageUrl)
        {
            TagBuilder list = new TagBuilder("ul");
            list.AddCssClass("pagination");
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder listItem = new TagBuilder("li");

                TagBuilder link = new TagBuilder("a");
                link.MergeAttribute("href", pageUrl(i));
                link.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    listItem.AddCssClass("active");
                    link.AddCssClass("selected");
                }
                listItem.InnerHtml += link.ToString();
                list.InnerHtml += listItem.ToString();
                
            }
            return MvcHtmlString.Create(list.ToString());
        }
    }
}