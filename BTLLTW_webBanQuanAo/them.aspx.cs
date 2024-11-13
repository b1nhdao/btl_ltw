using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace BTLLTW_webBanQuanAo
{
    public partial class them : System.Web.UI.Page
    {
        private int inputID, inputCategory, inputPrice, inputFinal_Price;
        private string inputName, inputImage, inputDescription;
        private string fileName;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> items = (List<Item>)Application["itemList"];
            int count = items.Count;
            int maxId = items.Count > 0 ? items.Max(item => item.Id) : 0;


            if (string.IsNullOrEmpty(Request.Form["id"]))
            {
                inputID = maxId + 1;  // Sử dụng ID cao nhất + 1
                inputName = Request.Form["name"];
                inputCategory = Convert.ToInt32(Request.Form["category"]);
                inputPrice = Convert.ToInt32(Request.Form["price"]);
                inputFinal_Price = Convert.ToInt32(Request.Form["final_price"]);
                inputDescription = Request.Form["describe"];

                // Kiểm tra file upload trước khi gọi saveFile
                if (Request.Files["image"] != null && Request.Files["image"].ContentLength > 0)
                {
                    saveFile(Request.Files["image"], Server.MapPath("~/resource/"));
                    inputImage = "resource/" + fileName;

                    items.Add(new Item(inputID, inputName, inputImage, inputCategory, inputPrice, inputFinal_Price, inputDescription));
                    Application["itemList"] = items;
                    Response.Redirect("them.aspx");
                }
                else
                {
                    //Response.Write("No image file uploaded.");
                    //Response.Write(inputImage);
                }
            }
            if (Request.Form["id"] != null)
            {
                foreach(Item item in items)
                {
                    if(item.id == Int32.Parse(Request.Form["id"]))
                    {
                        item.Name = Request.Form["name"];
                        item.Category = Convert.ToInt32(Request.Form["category"]);
                        item.Price = Convert.ToInt32(Request.Form["price"]);
                        item.Final_price = Convert.ToInt32(Request.Form["final_price"]);
                        item.Description = Request.Form["describe"];

                        if (Request.Files["image"] != null && Request.Files["image"].ContentLength > 0)
                        {
                            saveFile(Request.Files["image"], Server.MapPath("~/resource/"));
                            item.Image = "resource/" + fileName;
                        }

                        Application["itemList"] = items;
                        Response.Redirect("them.aspx");
                    }
                }
            }

            // Hiển thị danh sách sản phẩm
            DisplayItems(items);

            // Gán giá trị cho các trường khi chỉnh sửa sản phẩm
            if (Request.QueryString["sua"] != null)
            {
                id.Value = Request.QueryString["sua"];
                name.Value = Request.QueryString["name"];
                category.Value = Request.QueryString["category"];
                price.Value = Request.QueryString["price"];
                final_price.Value = Request.QueryString["final_price"];
                describe.Value = Request.QueryString["describe"];
            }

            int deletesp = Convert.ToInt32(Request.QueryString["delete"]);
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].Id == deletesp)
                {
                    items.RemoveAt(i);
                    Response.Redirect("them.aspx");

                }
            }
        }

        // Hàm lưu file hình ảnh
        public void saveFile(HttpPostedFile file, string path)
        {
            fileName = Path.GetFileName(file.FileName);
            string filePath = Path.Combine(path, fileName);

            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            file.SaveAs(filePath);
        }

        // Hàm hiển thị danh sách sản phẩm
        private void DisplayItems(List<Item> items)
        {
            string tableHtml = "<table><tr><td>STT</td><td>ID</td><td>Tên sản phẩm</td><td>Đường dẫn ảnh</td><td>Loại</td><td>Giá</td><td>Giá cuối</td><td>Mô tả</td></tr>";
            int stt = 1;
            foreach (Item item in items)
            {
                tableHtml += $"<tr><td>{stt}</td><td>{item.Id}</td><td>{item.Name}</td><td>{item.Image}</td><td>{item.Category}</td><td>{item.Price}</td><td>{item.Final_price}</td><td>{item.Description}</td>";
                tableHtml += $"<td><a href='them.aspx?sua={item.Id}&name={item.Name}&image={item.Image}&category={item.Category}&price={item.Price}&final_price={item.Final_price}&describe={item.Description}'>Sửa</a></td>";
                tableHtml += $"<td><a href='them.aspx?delete={item.Id}'>Xóa</a></td></tr>";
                stt++;
            }
            tableHtml += "</table>";
            hienthidanhsach.InnerHtml = tableHtml;
        }
    }
}