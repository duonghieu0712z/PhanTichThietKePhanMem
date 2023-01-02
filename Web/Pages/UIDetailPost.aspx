<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UIDetailPost.aspx.cs" Inherits="Web.Pages.UIDetailPost" ValidateRequest="false"%>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../CSS/RoutePage.css" rel="stylesheet" type="text/css" />
    <div class="main-container bg-light shadow-lg">
        <div class="NewsTwoBackgroundGradient">
            <div class="NewsTwoMain">
                <div class="header">
                    <div class="portalName text-center h-100 bg-light m-auto">
                        Sở Giao Thông Vận Tải Thành phố Đà Lạt<br />
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
                <div class="form-control d-flex align-items-center mt-5 border-3 rounded-0" style="background-color: slategrey; color: white; font-weight: 500">
                    <h4>Bài viết</h4>
                </div>

                <div class="p-5">
                    <p><%=ls.NgayDang %></p>
                    <h2><%=ls.Title %></h2>
                    <h5 style="font-size:15px; margin-top:50px;"><%=ls.Content %></h5>
                </div>
            </div>
        </div>
        <div class=" w-auto" style="border: 1px gainsboro solid; padding: 0.2rem; margin-top: 30px">
            <div style="text-align: center; background-color: gainsboro; padding: 1rem">
                <span>Bản quyền Trung tâm Quản lý Giao thông công cộng Thành phố Đà Lạt </span>
                <br />
                <span>Phát triển bởi </span>
                <span class="highlight">Công ty Hệ thống thông tin DLU</span>
            </div>
        </div>
    </div>
</asp:Content>