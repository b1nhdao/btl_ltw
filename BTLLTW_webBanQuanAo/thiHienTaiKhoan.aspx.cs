using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLLTW_webBanQuanAo
{
    public partial class thiHienTaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<User> list = (List<User>)Application["Users"];
            foreach (User user in list)
            {
                hienoday.InnerHtml = generateString();
            }
        }

        private string generateString()
        {
            string html = "";
            html += "<table><tr><td>Username</td><td>Ho ten</td><td>Ngay sinh</td><td>Lop</td></tr>";
            List<User> list = (List<User>)Application["Users"];
            foreach (User user in list)
            {

                html += "<tr><td>" + user.Taikhoan + "</td><td> " + user.HoTen + "</td><td>" + user.Ngaysinh + "</td><td>" + user.Lop + "</td></tr>";
            }
            html += "</table>";
                return html;
        }
    }
}