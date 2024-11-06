using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLLTW_webBanQuanAo
{
    public partial class male : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = renderItem();
            List<Item> items = (List<Item>)Application["itemList"];
            hienoday.InnerHtml = s;
            showTitle.InnerHtml = renderTitle();
        }

        private string renderTitle()
        {
            string searchKeyword = Request.QueryString["search"];
            string category = Request.QueryString["category"];
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                return "KẾT QUẢ TÌM KIẾM CHO: " + searchKeyword;
            }

            if (category == "male")
                return "NAM";
            else if (category == "female")
                return "NỮ";
            else return "TRẺ EM";
        }

        private string renderItem()
        {
            string html = "";
            List<Item> list = (List<Item>)Application["itemList"];
            string category = Request.QueryString["category"];
            string search = Request.QueryString["search"];


            if (search != null)
            {
                foreach (Item item in list)
                {
                    if (item.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        html += generateString(item);
                    }
                }
            }

            if (category == "male")
            {
                foreach (Item item in list)
                {
                    if (item.Category <= 3)
                    {
                        html += generateString(item);
                    }
                }
            }

            if (category == "m_casual")
            {
                foreach (Item item in list)
                {
                    if (item.Category == 1)
                    {
                        html += generateString(item);
                    }
                }
            }

            if (category == "m_work")
            {
                foreach (Item item in list)
                {
                    if (item.Category == 2)
                    {
                        html += generateString(item);
                    }
                }
            }

            if (category == "m_sports")
            {
                foreach (Item item in list)
                {
                    if (item.Category == 3)
                    {
                        html += generateString(item);
                    }
                }
            }

            if (category == "female")
            {
                foreach (Item item in list)
                {
                    if (item.Category >= 4 && item.Category <= 6)
                    {
                        html += generateString(item);
                    }
                }
            }

            if (category == "f_casual")
            {
                foreach (Item item in list)
                {
                    if (item.Category == 4)
                    {
                        html += generateString(item);
                    }
                }
            }

            if (category == "f_work")
            {
                foreach (Item item in list)
                {
                    if (item.Category == 5)
                    {
                        html += generateString(item);
                    }
                }
            }

            if (category == "f_sports")
            {
                foreach (Item item in list)
                {
                    if (item.Category == 6)
                    {
                        html += generateString(item);
                    }
                }
            }

            if (category == "kid")
            {
                foreach (Item item in list)
                {
                    if (item.Category == 7)
                    {
                        html += generateString(item);
                    }
                }
            }

            if (category == "sale")
            {
                foreach (Item item in list)
                {
                    if (item.Price != 0)
                    {
                        html += generateString(item);
                    }
                }
            }

            if (category == "new")
            {
                foreach (Item item in list)
                {
                    html += generateString(item);
                }
            }

            return html;
        }

        private string generateString(Item item)
        {
            string html = "";
            html += "<div class='item'>" +
                        "<a href='ctsp.aspx?id=" + item.Id + "'>" +
                            "<img src='" + item.Image + "' alt=''>" +
                        "</a>" +
                        "<div class='item-info'>" +
                            "<p>" + item.Name + "<br/></p>" +
                            "<div class='price'>";

            if (item.Price == 0)
            {
                html += "<p class='price-after' style = 'color: black'>" + item.Final_price.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " đ</p>";
            }
            else
            {
                html += "<p class='price-after'>" + item.Final_price.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " đ</p>" +
                         "<sub class='price-before'>" + item.Price.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " đ</sub>";
            }

            html += "</div>" +
                    "</div>" +
                    "</div>";
            return html;
        }
    }
}