<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UIHomePage.aspx.cs" Inherits="DocumentWebDemo.pages.UIHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/RoutePage.css" rel="stylesheet" type="text/css" />
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
                <div class="bodyContentContainer">
                    <div class="posts">
                        <% foreach (var item in ls)
                            { %>
                        <div class="card mb-3 flex-row" style="margin: 20px 0 20px 20px; display: none; width: 700px; height: 200px;">

                            <div class="col-md-4 d-flex align-items-center">
                                <img src="<%=item.Link %>" class="card-img border p-2 " alt="...">
                            </div>
                            <div class="col-md-8">
                                <div class="card-body">
                                    <a href="/Pages/UIDetailPost?id=<%= item.ID %>" class="card-title" style="font-size: 15px;"><%=item.Title %></a>
                                    <div class="card-text" style="height: 110px; max-height: 120px; text-overflow: ellipsis; white-space: pre-line; overflow: hidden;"><%=item.SummaryContent %></div>
                                </div>
                            </div>
                        </div>
                        <%} %>
                    </div>

                <%--    <div class="card mb-3" style="margin: 20px; padding: 0px 15px 15px 15px;">
                        <h4 style="color: #34b67a; font-weight: bold">Thông tin</h4>
                        <div id="informations">
                            <%
                                int i = 1;
                                foreach (var info in informations)
                                {
                                    i++;
                            %>
                            <div class="infoLink" id="infoLink<%= i%>">
                                <div class="img"><%= info.Image%></div>
                                <div class="infoTexts">
                                    <div class="titleContainer">
                                        <a href="NoiDung.aspx?id=<%=info.ID%>" class="infoTitle"><%= info.Title%><span class="infoLinkSpan"></span></a>
                                    </div>
                                    <span class="time">Ngày đăng: <%= info.DateSubmitted %></span>
                                    <%if (DateTime.Compare(info.DateSubmitted, DateTime.Now.AddDays(-5)) >= 0)
                                        { %>
                                    <span class="newInfo">Mới!</span>
                                    <%} %>
                                </div>
                            </div>
                            <%
                                }
                            %>
                        </div>
                    </div>--%>

                </div>
                <div class="d-flex justify-content-center">
                    <button class="rmorebtn btn btn-success item-center" runat="server">Xem thêm 3 bản tin</button>
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
    <script>
        $(".card").slice(0, 3).show();

        $(".rmorebtn").on("click", () => {
            event.preventDefault();
            $(".card:hidden").slice(0, 3).show();
            if ($(".card").length == 0) {
                $(".rmorebtn").fadeOut()
            }
        })

        var informations = document.getElementById('informations');

        [].map.call(informations.children, Object).sort(function (b, a) {
            return +a.id.match(/\d+/) - +b.id.match(/\d+/);
        }).forEach(function (elem) {
            informations.appendChild(elem);
        });
    </script>
</asp:Content>
