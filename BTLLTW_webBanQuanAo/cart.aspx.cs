using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLLTW_webBanQuanAo
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["username"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    BindCart();
                    hiengiatienoday.InnerHtml = generatePriceCart();
                }
            }
        }

        private string renderCategory(Item item)
        {
            if (item.Category == 1 || item.Category == 4)
                return "Đồ mặc hằng ngày";
            if (item.Category == 2 || item.Category == 5)
                return "Đồ công sở";
            if (item.Category == 3 || item.Category == 6)
                return "Đồ thể thao";
            else return "Đồ trẻ em";
        }

        protected void btn_add_quantityOnClick(object sender, EventArgs e)
        {
            List<ItemCart> itemCarts = (List<ItemCart>)Application["itemCart"];
        }

        private void BindCartAfterDelete()
        {
            List<ItemCart> list = (List<ItemCart>)Application["itemCart"];
            ListViewCart.DataSource = list;
            ListViewCart.DataBind();
        }

        private void BindCart()
        {
            string userName = (string)Session["username"];
            Response.Write(userName);
            List<ItemCart> list = (List<ItemCart>)Application["itemCart"];
            List<ItemCart> newList = new List<ItemCart>();
            foreach (ItemCart item in list)
            {
                if (item.userName == userName)
                {
                    newList.Add(item);
                    item.price = item.final_price * item.quantity;
                }
                else
                {
                    continue;
                }
            }
            ListViewCart.DataSource = newList;
            ListViewCart.DataBind();
        }

        private string generatePriceCart()
        {
            string userName = (string)Session["username"];
            int final_price = 0;
            List<ItemCart> listCart = (List<ItemCart>)Application["ItemCart"];
            foreach (ItemCart item in listCart)
            {
                if (item.userName == userName) 
                {
                    final_price += (item.Final_price * item.Quantity);
                }
            }
            string html = "";
            html += "<div class='price-cart'>" +
            "<div class='row'>" +
                "<p>Tạm tính</p>" +
                "<div class='price'><p>" + final_price.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " đ</p></div>" +
            "</div>" +
            "<div class='row'>" +
                "<p>Giảm giá</p>" +
                "<div class='price'><p>" + 0 + " đ</p></div>" +
            "</div>" +
            "<div class='row'>" +
                "<p>Phí giao hàng</p>" +
                "<div class='price'><p>Miễn phí</p></div>" +
            "</div>" +
            "<br>" +
            "<hr>" +
            "<br>" +
            "<div class='row'>" +
                "<p>Tổng</p>" +
                "<div class='total-price'><b><p>" + final_price.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " đ</p></b></div>" +
            "</div>" +
        "</div>" +
        "<br>";
            return html;
        }

        private void GenerateTotalPrice(List<ItemCart> itemCart)
        {
            int totalPrice = itemCart.Sum(item => item.price);
            hiengiatienoday.InnerHtml = $"Tổng tiền: {totalPrice.ToString("N0", new System.Globalization.CultureInfo("vi-VN"))} đ";
        }

        protected void ListViewCart_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string userName = (string)Session["username"];
            if (e.CommandName == "DeleteItem")
            {
                int itemCartID = int.Parse(e.CommandArgument.ToString());
                List<ItemCart> itemCart = (List<ItemCart>)Application["itemCart"];

                // Remove the item from the cart
                ItemCart itemToRemove = itemCart.Find(item => item.itemCartID == itemCartID);
                int quantityRemove = itemToRemove.quantity;
                if (itemToRemove != null)
                {
                    itemCart.Remove(itemToRemove);
                }

                // Update Application state and rebind cart
                Application["itemCart"] = itemCart;
                BindCartAfterDelete();
                hiengiatienoday.InnerHtml = generatePriceCart();

                int currentQuantity = 0;
                foreach (ItemCart item in itemCart)
                {
                    if(item.userName == userName)
                    {
                        currentQuantity += item.quantity;
                    }
                    else
                    {
                        continue;
                    }
                }
                Session["quantity"] = currentQuantity;
                Response.Redirect(Request.RawUrl);
            }

            if (e.CommandName == "IncreaseQuantity")
            {
                int itemCartID = int.Parse(e.CommandArgument.ToString());
                List<ItemCart> itemCart = (List<ItemCart>)Application["itemCart"];

                // Find the item to increase its quantity
                ItemCart itemToUpdate = itemCart.Find(item => item.itemCartID == itemCartID);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Quantity += 1; // Increase quantity by 1
                }


                // Update Application state and rebind cart
                Application["itemCart"] = itemCart;
                BindCart();
                hiengiatienoday.InnerHtml = generatePriceCart();
            }

            if (e.CommandName == "DecreaseQuantity")
            {
                int itemCartID = int.Parse(e.CommandArgument.ToString());
                List<ItemCart> itemCart = (List<ItemCart>)Application["itemCart"];

                // Find the item to decrease its quantity
                ItemCart itemToUpdate = itemCart.Find(item => item.itemCartID == itemCartID);
                if (itemToUpdate != null && itemToUpdate.Quantity > 1)
                {
                    itemToUpdate.Quantity -= 1; // Decrease quantity by 1
                }

                // Update Application state and rebind cart
                Application["itemCart"] = itemCart;
                BindCart();
                hiengiatienoday.InnerHtml = generatePriceCart();
            }
        }
    }
}