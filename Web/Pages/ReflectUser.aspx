<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReflectUser.aspx.cs" Inherits="Web.Pages.ReflectUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../CSS/StyleSheet1.css" rel="stylesheet" type="text/css" />
    <div class="main-container bg-light shadow-lg">
        <div id="form11" runat="server">
            <div class="header">
                <div class="portalName text-center form-control h-100 border-0 bg-light">
                    Sở Giao Thông Vận Tải Thành phố Đà Lạt
                    <br />
                    Trung tâm Quản lý giao thông công cộng Thành phố Đà Lạt
                </div>
                <div class="login-language-social-container">
                    <div class="language">
                        <div class="language-object">
                            <span class="language-selected">Tiếng Việt</span>
                            <span class="language">|</span>
                            <span class="language">English</span>
                        </div>
                    </div>
                    <div class="social-links">
                        <a href="https://www.facebook.com/tkdg2308" title="Facebook" target="facebook">
                            <span>Facebook</span>
                        </a>
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="eds_containers_NewsTwo eds_templateGroup_default eds_template_Default">
                    <h2>
                        <span id="dnn_ctr575_dnnTITLE_titleLabel" class="Head">
                            <span class="highlight">Đường đi</span>
                            bằng xe buýt
                        </span>
                    </h2>


                    <div class="dnnFormItem">
                        <formview action="https://formspree.io/f/mqkozknv" method="POST">
                             <div class=" d-flex">
                            <asp:Label CssClass="text-right w-25 mr-5" ID="Label1" runat="server" Text="Địa chỉ Email"></asp:Label>
                            <input type="text" class="form-control" id="txtEmail" runat="server" placeholder="">
                        </div>
                        <div class=" d-flex">
                            <asp:Label CssClass="text-right w-25 mr-5" ID="Label2" runat="server" Text="Tên"></asp:Label>
                            <input type="text" class="form-control" id="txtName" runat="server" placeholder="">
                        </div>
                        <div class=" d-flex">
                            <asp:Label CssClass="text-right w-25 mr-5" ID="Label3" runat="server" Text="Số điện thoại"></asp:Label>
                            <input type="text" class="form-control" id="txtPhoneNumber" runat="server" placeholder="">
                        </div>
                        <div class=" d-flex">
                            <asp:Label CssClass="text-right w-25 mr-5" ID="Label4" runat="server" Text="Phản ánh về"></asp:Label>
                            <asp:DropDownList CssClass=" form-control h-25 mb-2" ID="drlType" runat="server"></asp:DropDownList>
                        </div>
                        <div class=" d-flex">
                            <asp:Label CssClass="text-right w-25 mr-5" ID="Label5" runat="server" Text="Tiêu đề"></asp:Label>
                            <input type="text" class="form-control" id="txtTitle" runat="server" placeholder="">
                        </div>
                        <div class=" d-flex">
                            <asp:Label CssClass="text-right w-25 mr-5"  ID="Label6" runat="server" Text="Nội dung"></asp:Label>
                            <textarea class="mb-2" id="txtContent" cols="20" rows="17" runat="server"></textarea>
                        </div>
                        <div class=" d-flex">
                            <asp:Label CssClass="text-right w-25 mr-5" ID="Label7" runat="server" Text="Tập đính kèm"></asp:Label>
                           <asp:FileUpload CssClass="text-right w-25 mr-5" ID="txtFile" runat="server" />`
                        </div>
                        <div class=" d-flex">
                            <asp:Label CssClass="text-right w-25 mr-5" ID="Label8" runat="server" Text="Gửi cho tôi một bản sao"></asp:Label>
                            <input  class="mb-5" id="Reflect_Select_All" type="checkbox">
                        </div>
                        
                        <div class=" d-flex">
                            <asp:Button  ID="btnSubmit" runat="server" Text="Gửi phản ánh" CssClass=" ml-5 mb-3 btn btn-primary" OnClick="btnSubmit_Click" />
                        </div>
                        </formview>
                       
                    </div>

                    
                </div>
            </div>
            <div style="border: 1px gainsboro solid; padding: 0.2rem; margin-top: 20px">
                <div style="text-align: center; background-color: gainsboro; padding: 1rem">
                    <span>Bản quyền Trung tâm Quản lý Giao thông công cộng Thành phố Đà Lạt </span>
                    <br />
                    <span>Phát triển bởi </span>
                    <span class="highlight">Công ty Hệ thống thông tin DLU</span>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
