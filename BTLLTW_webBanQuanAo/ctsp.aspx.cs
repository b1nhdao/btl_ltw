using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Util;
using WebGrease;

namespace BTLLTW_webBanQuanAo
{
    public partial class ctsp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = renderItemThumbnail();
            string s1 = renderItemInfo();
            List<Item> items = (List<Item>)Application["itemList"];
            List<ItemCart> itemCart = (List<ItemCart>)Application["itemCart"];
            hienAnh.InnerHtml = s;
            hienInfo.InnerHtml = s1;
            hienThongTin.InnerHtml = renderItemDescription();
        }

        //button for size()
        protected void Size_S_Click(object sender, EventArgs e)
        {
            size_picked.InnerHtml = "S";
        }

        protected void Size_M_Click(object sender, EventArgs e)
        {
            size_picked.InnerHtml = "M";
        }

        protected void Size_L_Click(object sender, EventArgs e)
        {
            size_picked.InnerHtml = "L";
        }

        protected void Size_XL_Click(object sender, EventArgs e)
        {
            size_picked.InnerHtml = "XL";
        }

        //button remove_quantity click
        protected void btn_remove_quantityOnClick(object sender, EventArgs e)
        {
            int quantity = Int32.Parse(number_quantity.Value.ToString());
            if (quantity == 1)
                return;
            quantity--;
            number_quantity.Value = quantity.ToString();
        }

        //add
        protected void btn_add_quantityOnClick(object sender, EventArgs e)
        {
            int quantity = Int32.Parse(number_quantity.Value.ToString());
            quantity++;
            number_quantity.Value = quantity.ToString();
        }

        //btn_buynow click

        protected void btn_buyNow_OnClick(object sender, EventArgs e)
        {
            string userName = (string)Session["username"];
            // Khởi tạo một giỏ hàng mới
            if (userName == null)
            {
                Response.Write("<script>'Bạn cần đăng nhập trước ! </script>'");
                return;
            }
            List<ItemCart> itemCart = new List<ItemCart>();

            // Lấy id sản phẩm từ QueryString
            string id = Request.QueryString["id"];
            Item item = getItem(Int32.Parse(id));
            int quantity = getQuantity();
            string size = size_picked.InnerHtml.ToString();
            if (size == "")
            {
                Response.Write("<script>alert('Hãy chọn size');</script>");
                return;
            }

            int itemCartID = 99; 

            ItemCart itemTemp = new ItemCart(itemCartID, item.Id, item.Name, item.Image, item.Category, item.Price, item.Final_price, item.Description, size, quantity, userName);

            itemCart.Add(itemTemp);

            Application["itemCart"] = itemCart;
            Session["quantity"] = itemTemp.quantity;

            Response.Redirect("cart.aspx");
        }


        //btn_cart click
        protected void btn_cart_OnClick(object sender, EventArgs e)
        {
            // Khởi tạo giỏ hàng nếu chưa có
            string userName = (string)Session["username"];
            if (userName == null)
            {
                Response.Write("<script>alert('Bạn cần đăng nhập vào trước !');</script>");
                return;
            }
            List<ItemCart> itemCart = (List<ItemCart>)Application["itemCart"] ?? new List<ItemCart>();
            Application["itemCart"] = itemCart;

            // Lấy id sản phẩm từ QueryString
            string id = Request.QueryString["id"];
            Item item = getItem(Int32.Parse(id));
            int quantity = getQuantity();
            string size = size_picked.InnerHtml.ToString();
            if (size == "")
            {
                Response.Write("<script>alert('Hãy chọn size');</script>");
                return;
            }

            // Kiểm tra xem itemCartID hiện tại trong Application là bao nhiêu, nếu chưa có thì gán bằng 1
            int itemCartID = (int?)Application["itemCartID"] ?? 1;

            // Tạo sản phẩm mới và tăng itemCartID
            ItemCart itemTemp = new ItemCart(itemCartID, item.Id, item.Name, item.Image, item.Category, item.Price, item.Final_price, item.Description, size, quantity, userName);
            itemCartID++;

            // Cập nhật lại itemCartID trong Application
            Application["itemCartID"] = itemCartID;

            // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
            foreach (ItemCart itemcart in itemCart)
            {
                if (itemcart.Id == itemTemp.Id && itemcart.Size == itemTemp.Size)
                {
                    itemcart.quantity += itemTemp.quantity;
                    Response.Write("<script>alert('Giỏ hàng đã được cập nhật!');</script>");
                    Response.Redirect(Request.RawUrl); // Chuyển hướng lại trang hiện tại để tránh lặp lại POST
                    return;
                }
            }

            // Thêm sản phẩm mới vào giỏ hàng
            itemCart.Add(itemTemp);

            int currentQuantity = (int?)Session["quantity"] ?? 0;
            Session["quantity"] = currentQuantity + itemTemp.quantity;

            // Hiện thông báo và chuyển hướng
            Response.Write("<script>alert('Giỏ hàng đã được cập nhật!');</script>");
            Response.Redirect(Request.RawUrl); // Chuyển hướng lại trang hiện tại để tránh lặp lại POST
        }



        //get info Item
        private Item getItem(int id)
        {
            List<Item> items = (List<Item>)Application["itemList"];
            Item item = items.Find(x => x.Id == id);
            return item;
        }
        private int getQuantity()
        {
            //Response.Write(number_quantity.InnerHtml.ToString());
            return int.Parse(number_quantity.Value);
        }

        private string renderItemThumbnail()
        {
            string html = "";
            List<Item> list = (List<Item>)Application["itemList"];
            string id = Request.QueryString["id"];
            foreach (Item item in list)
            {
                if (item.Id == Int32.Parse(id))
                {
                    html += generateStringThumbnail(item);
                }
            }
            return html;
        }

        private string renderItemInfo()
        {
            string html = "";
            List<Item> list = (List<Item>)Application["itemList"];
            string id = Request.QueryString["id"];

            foreach (Item item in list)
            {
                if (item.Id == Int32.Parse(id))
                {
                    html += generateStringInfo(item);
                }
            }
            return html;
        }

        private string renderItemDescription()
        {
            string html = "";
            List<Item> list = (List<Item>)Application["itemList"];
            string id = Request.QueryString["id"];

            foreach (Item item in list)
            {
                if (item.Id == Int32.Parse(id))
                {
                    html += generateStringDescription(item);
                }
            }
            return html;
        }

        public string renderCategory(Item item)
        {
            if (item.Category == 1 || item.Category == 4)
                return "Đồ mặc hằng ngày";
            if (item.Category == 2 || item.Category == 5)
                return "Đồ công sở";
            if (item.Category == 3 || item.Category == 6)
                return "Đồ thể thao";
            else return "Đồ trẻ em";
        }

        private string generateStringThumbnail(Item item)
        {
            string html = "";
            html += "<img src='" + item.Image + "' alt=''>";
            return html;
        }

        private string generateStringInfo(Item item)
        {
            string html = "";
            html += "<div class='title'><h3>" + item.Name + "</h3></div>" +
                        "<div class='category'>" + renderCategory(item) + "</div>" +
                        "<div class='price'><h2>" + item.Final_price.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " đ</h2></div>";
            return html;
        }

        private string generateStringDescription(Item item)
        {
            string html = "";
            html += item.Description;
            return html;
        }
    }
}