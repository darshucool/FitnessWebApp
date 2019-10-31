using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PASA.Helpers
{
    public class SuccessMessage : Message
    {
        public SuccessMessage(string messageText)
            : base(messageText)
        {
        }

        public override MvcHtmlString Render(HtmlHelper htmlHelper)
        {
            var divTag = new TagBuilder("div");
            divTag.GenerateId("sucess_msg");
            divTag.AddCssClass("alert alert-success");
            divTag.SetInnerText(MessageText);

            var wrapperDivTag = new TagBuilder("div");
            wrapperDivTag.GenerateId("msg");
            wrapperDivTag.InnerHtml = divTag.ToString(TagRenderMode.Normal);

            return new MvcHtmlString(wrapperDivTag.ToString(TagRenderMode.Normal));
        }
    }
}