using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLLTW_webBanQuanAo
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<User> users = (List<User>)Application["Users"];
            List<ItemCart> cart = (List<ItemCart>)Application["itemCart"];
            string username = Request.Form["username"];
            string password = Request.Form["passowrd"];
            int count = 0;
            if (username != null && password != null)
            {
                foreach (User user in users)
                {
                    if (username == user.Taikhoan && password == user.Matkhau)
                    {
                        Session["username"] = username;
                        Session["role"] = user.Role;
                        Response.Redirect("index.aspx");
                        foreach (ItemCart cartItem in cart)
                        {
                            if(cartItem.UserName == username)
                            {
                                count++;
                            };
                        }
                        Session["quantity"] = count.ToString();
                    }
                    else if (username == user.Taikhoan && password != user.Matkhau)
                    {
                        notification.Attributes["class"] = "red";
                        notification.InnerHtml = "Sai mật khẩu !";
                    }
                    else if (username != user.Taikhoan)
                    {
                        notification.Attributes["class"] = "red";
                        notification.InnerHtml = "Tài khoản không tồn tại !";
                    }
                    else
                    {
                        notification.Attributes["class"] = "red";
                        notification.InnerHtml = "Sai thông tin đăng nhập !";
                    }
                }
                //for (int i = 0; i < users.Count; i++)
                //{
                //    if (String.Compare(users[i].Taikhoan, tkdn.ToString(), false) == 0 && String.Compare(users[i].Matkhau, mkdn.ToString(), false) == 0)
                //    {
                //        index = i;
                //        checkdn++;

                //        Response.Redirect("index.aspx");
                //    }
                //}
            }
        }
    }
}