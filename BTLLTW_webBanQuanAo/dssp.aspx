<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="dssp.aspx.cs" Inherits="BTLLTW_webBanQuanAo.male" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="style/base.css">
    <link rel="stylesheet" href="style/styleIndex.css">
    <link rel="stylesheet" href="style/styleList.css">
</head>

<body>
    <div class="body">
        <div class="title"><h1>THỜI TRANG <span id="showTitle" runat ="server"></span></h1>
        </div>
        <hr/>
        <br/>
        <div class="container">
            <div class="sidebar col-3">
                <h2>Bộ lọc</h2><br />
                <p>Giá tiền</p><br />

                <div>
                    <label><input type="radio" name="price-filter" value="under-200" onclick="filterByPrice()"> Dưới 200.000 đ</label><br>
                    <label><input type="radio" name="price-filter" value="200-500" onclick="filterByPrice()"> Từ 200.000 đ - 500.000 đ</label><br>
                    <label><input type="radio" name="price-filter" value="above-500" onclick="filterByPrice()"> Trên 500.000 đ</label><br>
                    <label><input type="radio" name="price-filter" value="all" onclick="filterByPrice()"> Tất cả</label><br>

                </div>
            </div>
            <div class ="content col-9" id="hienoday" runat="server" style=" display: flex; flex-wrap: wrap;gap: 20px;">
            </div>
        </div>
     </div>
        <script>
            function filterByPrice() {
                const filterValue = document.querySelector('input[name="price-filter"]:checked').value;
                const items = document.querySelectorAll('.body .container .item');

                console.log(items);

                items.forEach(item => {
                    const priceText = item.querySelector('.price-after').textContent;
                    const price = parseInt(priceText.replace(/\D/g, ''));

                    if ((filterValue === "under-200" && price < 200000) ||
                        (filterValue === "200-500" && price >= 200000 && price <= 500000) ||
                        (filterValue === "above-500" && price > 500000) ||
                        (filterValue === "all")) {
                        item.classList.remove('hidden');
                    } else {
                        item.classList.add('hidden');
                    }
                });
            }
        </script>
</body>
</html>

</asp:Content>
