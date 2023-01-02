<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMain.aspx.cs" Inherits="DocumentWebDemo.WebMain" %>

<!DOCTYPE html>

<head runat="server">
    <title>Trang chủ</title>
    <link href="../webmainCss.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server"></form>
        <div>
            <h1 class="auto-style1">SỞ GIAO THÔNG VẬN TẢI THÀNH PHỐ HỒ CHÍ MINH</h1>
            <h1 class="auto-style1">TRUNG TÂM QUẢN LÝ GIAO THÔNG CÔNG CỘNG THÀNH PHỐ HỒ CHÍ MINH</h1>
        </div>
        <ul class="menu"> 
            <li>Trang Chủ</li>
            <li class="has-submenu">
                Giới thiệu
                <ul class="submenu">
                    <a href="Introduce.aspx">Giới Thiệu Chung</a>
                    <a>Chức năng-Nhiệm Vụ</a>
                    <a>Cơ cấu tổ chức</a>
                </ul>
            </li>
            <li class="has-submenu">
                Thông tin tuyến
                <ul class="submenu">
                    <a>Tuyến</a>
                    <a>Tìm đường</a>
                    <a>Dự báo giờ</a>
                </ul>
            </li>
            <li class="has-submenu">
                Tra cứu thông tin
                <ul class="submenu">
                    <a href="ClientUI.aspx">Văn Bản</a>
                    <a>Tuyển dụng</a>
                    <a>Quy trình cấp phù hiệu xe kinh doanh vận tải</a>
                    <a>Đưa rước học sinh</a>
                </ul>
            </li>
            <li>Xử lý vi phạm</li>
            <li>Phản ánh</li>
            <li class="has-submenu">
                Tiến độ Giải ngân tiền trợ giá
                <ul class="submenu">
                    <a>Giải ngân tiền trợ giá xe buýt</a>
                    <a>Giải ngân tiền vé tập xe buýt</a>
                </ul>
            </li>
        </ul>
    <p style="text-align: center">
        <span id="dnn_dnnCopyright_lblCopyright" class="SkinObject" style="margin: 0px; padding: 0px; border: 0px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-weight: 400; font-stretch: inherit; font-size: 12px; line-height: inherit; font-family: Arial; vertical-align: baseline; color: rgb(47, 47, 47); letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(252, 252, 252); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">Bản quyền © Trung tâm Quản lý giao thông công cộng Thành phố Hồ Chí Minh</span><br style="color: rgb(47, 47, 47); font-family: Arial; font-size: 12px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(252, 252, 252); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;" />
        <span style="margin: 0px; padding: 0px; border: 0px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-weight: 400; font-stretch: inherit; font-size: 12px; line-height: inherit; font-family: Arial; vertical-align: baseline; color: rgb(47, 47, 47); letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(252, 252, 252); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">Phát triển bởi<span>&nbsp;</span><a href="http://www.fis.com.vn/" style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; font-size: 12px; line-height: inherit; font-family: inherit; vertical-align: baseline; color: rgb(94, 151, 0); text-decoration: none; outline: 0px;" target="fis">Công 
        ty Hệ thống Thông tin FPT</a></span></p></body>
</html>