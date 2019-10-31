using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using PASA.Domain;

namespace PASA.Helpers
{
    public static class HtmlHelpers
    {

        public static MvcHtmlString Message(this HtmlHelper helper)
        {
            if (helper.ViewContext.TempData.ContainsKey(ViewDataKeys.Message))
            {
                var message = (Message)helper.ViewContext.TempData[ViewDataKeys.Message];
                if (message != null)
                {
                    return message.Render(helper);
                }
            }
            return new MvcHtmlString(string.Empty);
        }
        public static MvcHtmlString ShowNextBidInfo(this HtmlHelper helper, decimal ProdPrice)
        {
            string html = "";
            try
            {
                if (ProdPrice < 100)
                {
                    ProdPrice=ProdPrice+10;
                    html += "Enter Rs. " + ProdPrice + " or more";
                }
                else if (ProdPrice < 1000)
                {
                    ProdPrice = ProdPrice + 100;
                    html += "Enter Rs. " + ProdPrice + " or more";
                }
                else if (ProdPrice < 5000)
                {
                    ProdPrice = ProdPrice + 500;
                    html += "Enter Rs. " + ProdPrice + " or more";
                }
                else if (ProdPrice > 5000)
                {
                    ProdPrice = ProdPrice + 1000;
                    html += "Enter Rs. " + ProdPrice + " or more";
                }
                html = "[ "+html+" ]";
            }
            catch (Exception)
            {

                throw;
            }
            return new MvcHtmlString(html);
        }
    }
}