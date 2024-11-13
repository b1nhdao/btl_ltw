<%@ Page Title="Đăng ký" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="BTLLTW_webBanQuanAo.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="style/base.css">
    <link rel="stylesheet" href="style/styleIndex.css">
    <title>Document</title>
</head>
<body>
    <div class="body">
        <div class="inner-wrap">
            <form action="" method="post" class="form" runat="server">
                <div class="row">
                    <h1>Đăng ký</h1>
                    <a href="login.aspx">Quay về đăng nhập</a>
                </div>
                <hr/>
                <div class="content">
                    <p>Tên đăng nhập</p>
                    <input type="text" name="username" id="username" placeholder="Nhập tên đăng nhập">
                    
                    <p>Họ và tên</p>
                    <input type="text" name="hoten" id="hoten" placeholder="Nhập họ và tên">
                    <p>Ngày sinh</p>
                    <input type="date" name="ngaysinh" id="ngaysinh">
                    <p>Gioi tinh</p>
                    
                    <select name="gioitinh" id="gioitinh">
                        <option value="Nam">Nam</option>
                        <option value="Nu">Nu</option>
                    </select>
                    <p>Lớp</p>
                    <select name="lop" id="lop">
                        <option value="22A01">22A01</option>
                        <option value="22A02">22A02</option>
                        <option value="22A03">22A03</option>
                        <option value="22A04">22A04</option>
                        <option value="22A05">22A05</option>
                        <option value="22A06">22A06</option>
                        <option value="22A07">22A07</option>
                        <option value="22A08">22A08</option>
                        <option value="22A09">22A09</option>
                    </select>
                    
                    <p>Mật khẩu</p>
                    <input type="password" name="password" id="password" placeholder="Nhập mật khẩu">
                    <p>Nhập lại mật khẩu</p>
                    <input type="password" name="re-password" id="re-password" placeholder="Nhập lại mật khẩu">
                    <label class="hidden" id="notijs" style="color: red;"></label>
                    <label class="hidden" id="notification" runat="server"></label>

                </div>
                <input type="button" value="Đăng ký" class="button" onclick="return dangkyOnclick();">
            </form>                
        </div>
    </div>
    <link rel="stylesheet" href="style/styleSignin.css">
    <script>
        function dangkyOnclick() {
            var username = document.getElementById('username').value;
            var password = document.getElementById('password').value;
            var rePassword = document.getElementById('re-password').value;
            var notification = document.getElementById('notijs');
            var passwordRegex = /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).+$/;

            var hotenRegex = /^[a-zA-Z\s]+$/;
            var hoten = document.getElementById('hoten').value;
            var lop = document.getElementById('lop').value; 

            if (!hotenRegex.test(hoten)) {
                notification.classList.remove("hidden");
                notification.innerHTML = "Họ tên không được chứa ký tự số và ký tự đặc biệt";
                return false;
            } else if (hoten.length < 8 || hoten.length > 50) {
                notification.classList.remove("hidden");
                notification.innerHTML = "Họ tên phải dài trong khoảng 8 -> 50 kí tự";
                return false;
            } else if (password.length < 8) {
                notification.classList.remove("hidden");
                notification.innerHTML = "Mật khẩu phải có ít nhất 8 ký tự";
                return false;
            } else if (!passwordRegex.test(password)) {
                notification.classList.remove("hidden");
                notification.innerHTML = "Mật khẩu phải chứa ít nhất một chữ in hoa, một chữ số và một ký tự đặc biệt";
                return false;
            } else {
                notification.innerHTML = "";
                console.log("Lớp được chọn:", lop);  // In ra giá trị lớp
                document.querySelector("form").submit();
            }
        }
    </script>
</body>
</html>
</asp:Content>
