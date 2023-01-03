<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UIBusRoute.aspx.cs" Inherits="Web.Pages.UIBusRoute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../CSS/RoutePage.css" rel="stylesheet" type="text/css" />
    <div class="main-container bg-light shadow-lg">
        <div class="NewsTwoBackgroundGradient">
            <div class="NewsTwoMain">
                <div class="header">
                    <div class="portalName text-center form-control h-100 border-0 bg-light">
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
                <div class="content-top-wraper">
                    <div id="dnn_ContentTop">
                        <div class="DnnModule DnnModule-iBus_TimeTable DnnModule-3591 px-3">
                            <a name="3591"></a>
                            <div class="eds_containers_NewsTwo eds_templateGroup_default eds_template_default">
                                <h2>
                                    <span id="dnn_ctr3591_dnnTITLE_titleLabel" class="Head m-3">Danh sách
                                    <span class="highlight">Tuyến</span>
                                    </span>
                                </h2>
                                <div id="dnn_ctr3591_ContentPane">
                                    <div class="dnnFormItem" style="text-align: center">
                                        <input type="text" class="clearable" id="txtSearch" runat="server" placeholder="<Nhập mã hoặc tên tuyến>" style="padding: 1rem" />
                                        <asp:Button ID="btnRouView" CssClass="cms-button cms-button-small" runat="server" Text="Tìm" OnClick="btnRouView_Click" />
                                    </div>
                                    <div class="w-100">
                                        <asp:Label CssClass="d-flex justify-content-center m-2 text-danger font-weight-bold" ID="Label1" runat="server"></asp:Label>
                                    </div>

                                    <div id="divResult" class="text-center d-flex flex-row flex-wrap justify-content-center mb-2" runat="server">
                                        <% foreach (var item in ls)

                                            { %>
                                        <a href="/Pages/UIRouteDetail?id=<%= item.BusRouteID %>" class="cms-button">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <div class="icon"><%=item.RouteNumber%></div>
                                                        </td>
                                                        <td><%=item.RouteName %>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </a>
                                        <%} %>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
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
