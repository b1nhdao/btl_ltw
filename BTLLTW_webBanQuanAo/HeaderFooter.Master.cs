using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLLTW_webBanQuanAo
{
    public partial class HeaderFooter : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                account.Attributes.Remove("class");
                account.Attributes.Add("class", "flex");
                greeting.InnerHtml = "Xin chào " + Session["username"].ToString() + " | </p>";
                login.Attributes.Add("class", "hidden");

                if (Session["role"].ToString() == "admin")
                {
                    management.Attributes.Remove("class");
                }
            }

            cart_number.InnerText = (Session["quantity"] != null) ? Session["quantity"].ToString() : "0";
        }
    }
}