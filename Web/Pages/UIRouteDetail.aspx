<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UIRouteDetail.aspx.cs" Inherits="Web.Pages.UIRouteDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../CSS/RouteDetails.css" rel="stylesheet" type="text/css" />
    <div class="container bg-white" runat="server">

        <div class="form-control text-center h-100 font-weight-bold text-success border-0">
            <label>
                SỞ GIAO THÔNG VẬN TẢI THÀNH PHỐ ĐÀ LẠT
                    <br />
                TRUNG TÂM QUẢN LÝ GIAO THÔNG CÔNG CỘNG THÀNH PHỐ ĐÀ LẠT</label>
        </div>

        <div class="container-detail bg-light" style="border: 1px solid #dadada" runat="server">
            <h2 class="" style="font-size: 20px; background: #d8d8d8; padding: 0.5rem;" runat="server">Thông tin 
                    <span class="text-success" style="font-weight: 400">Tuyến <%= br.RouteNumber %>: <%= br.RouteName %></span>
            </h2>

            <div class="RouteDetail bg-light">
                <div class="RouteInfo" style="padding: 0.5rem; font-size: 12px;">
                    <p style="font-weight: bold; white-space: nowrap">Mã số tuyến: <%= br.RouteNumber %></p>
                    <p style="font-weight: bold; white-space: nowrap">Tên tuyến: <%= br.RouteName %></p>

                    <div>
                        <p style="font-weight: bold; white-space: nowrap">Tuyến đường: <%=bst.ElementAt(0).RouteName %></p>
                        <div class="px-4">
                            <% foreach (var item in busStops)
                                {                                         %>
                            <span><%= item.BusStopName  %> ----</span>
                            <%} %>
                        </div>

                    </div>
                    <div class="mt-4">
                        <p style="font-weight: bold; white-space: nowrap">Tuyến đường: <%=bst.ElementAt(1).RouteName %></p>
                        <div class="px-4">
                            <% foreach (var item in Enumerable.Reverse(busStops))
                                {                                         %>
                            <span><%= item.BusStopName  %> ----</span>
                            <%} %>
                        </div>
                    </div>
                    <table class="mt-4">
                        <tbody>
                            <tr style="display: table-row-group; vertical-align: middle;">
                                <td style="font-weight: bold; white-space: nowrap">Đơn vị đảm nhận:</td>
                                <%--<td><%= ru.ReponsibleUnitName %> - <%= ru.PhoneNumber %></td>--%>
                            </tr>
                            <td></td>
                            <tr style="display: table-row-group; vertical-align: middle; white-space: nowrap; vertical-align: top;">
                                <td class="col-sm-2"></td>
                                <td>
                                    <ul style="list-style: circle">
                                        <li>Loại hình hoạt động: <%= br.OperationType %></li>
                                        <li>Cự ly: Cập nhật từ bảng khác</li>
                                        <li>Loại xe: Cập nhật từ bảng loại xe</li>
                                        <li>Thời gian hoạt động: <%= br.OperationTime %></li>
                                    </ul>
                                </td>

                                <td>
                                    <ul style="list-style: circle; margin-left:100px;">
                                        <li>Giá vé: <%= br.Fare %> VNĐ</li>
                                        <li>Số chuyển: <%= br.BusesAmount %></li>
                                        <li>Thời gian chuyến: <%= br.BusesSpace %></li>
                                        <li>Giãn cách chuyến: <%= br.BusesTime %></li>
                                    </ul>
                                </td>

                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div style="border: 1px gainsboro solid; padding: 0.1rem; font-size: 12px; margin-top: 20px;">
            <div style="text-align: center; background-color: #d8d8d8; padding: 0.5rem">
                <span>Bản quyền © Trung tâm Quản lý Giao thông công cộng Thành phố Đà Lạt </span>
                <br />
                <span>Phát triển bởi </span>
                <span class="text-success">Công ty Hệ thống thông tin DLU</span>
            </div>
        </div>
    </div>
</asp:Content>

