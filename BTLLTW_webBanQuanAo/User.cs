using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTLLTW_webBanQuanAo
{
    public class User
    {
        private string username, password;
        private string role;
        private int id;
        private string hoten;
        private string ngaysinh;
        private string lop;

        public User(int id, string taikhoan, string matkhau, string role, string hoten, string ngaysinh, string lop)
        {

            this.username = taikhoan;
            this.password = matkhau;
            this.role = role;
            this.id = id;
            this.hoten = hoten;
            this.ngaysinh = ngaysinh;
            this.lop = lop;
        }

        public string HoTen { get => hoten; set => hoten = value; }
        public string Ngaysinh { get => ngaysinh; set => ngaysinh = value; }

        public string Lop { get => lop; set => lop = value; }

        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Taikhoan
        {
            get => username;
            set => username = value;
        }

        public string Matkhau
        {
            get => password;
            set => password = value;
        }

        public string Role
        {
            get => role;
            set => role = value;
        }
    }
}