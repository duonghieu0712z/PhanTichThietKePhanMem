<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UIRouteDetail.aspx.cs" Inherits="Web.Pages.UIRouteDetail" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hfData" Value="" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="typeMap" Value="getRoute" runat="server" ClientIDMode="Static" />
    <script src ="../JavaScript/Map/map.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBK9sw5PYYq0MW-HBbXVMNN6rwZIEBuvhw&callback=initMap" defer></script>
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

            <!-- SHOW ROUTE ON MAP BY THANH'S TEAM -->
            <div class="row mt-4" style="padding-left:8px; padding-right: 8px">
            <div class="col-sm-12 overflow-auto">
                <asp:Label id="lblRoute" Visible="true" runat="server"
                ><h4>Danh sách Lộ trình</h4></asp:Label>
                <div>
                    <asp:Repeater ID="RepeatRoute" runat="server" Visible="false">
                        <HeaderTemplate>  
                            <table style="width: 100%">  
                        </HeaderTemplate> 
                        <ItemTemplate>
                            <tr style="background-color:#34B67A; width:100%; height: 48px; border: 2px solid white; color: white; cursor:pointer">
                                <td style="padding-left: 24px">
                                    <%#DataBinder.Eval(Container, "DataItem.RouteID") %>
                                </td>
                                <td>
                                    <%#DataBinder.Eval(Container, "DataItem.RouteName") %>
                                </td>
                                <td>
                                    <div style="display: flex; align-items:center;">
                                        <div style="width:36px; height:36px; border-radius: 50%; background-color: white; display:flex; justify-content:center; align-items:center;">
                                            <img src="../SetImg/ic-walk.png" alt="icon-walk" />
                                        </div>
                                        <div style="padding: 0px 8px 0px 8px">-</div>
                                    </div>
                                </td>
                                <td>
                                    <div style="display: flex; align-items:center;">
                                        <div style="width:36px; height:36px; border-radius: 50%; background-color: white; display:flex; justify-content:center; align-items:center;">
                                            <img src="../SetImg/ic-car.png" alt="icon-car" />
                                        </div>
                                        <div style="padding: 0px 8px 0px 8px">-</div>
                                    </div>
                                </td>
                                <td>
                                    <div style="display: flex; align-items:center;">
                                        <div style="width:36px; height:36px; border-radius: 50%; background-color: white; display:flex; justify-content:center; align-items:center;">
                                            <img src="../SetImg/ic-clock.png" alt="icon-clock" />
                                        </div>
                                        <div style="padding: 0px 8px 0px 8px">
                                            <%#DataBinder.Eval(Container, "DataItem.RouteTime") %>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div style="display: flex; align-items:center;">
                                        <div style="width:36px; height:36px; border-radius: 50%; background-color: white; display:flex; justify-content:center; align-items:center;">
                                            <img src="../SetImg/ic-money.png" alt="icon-money" />
                                        </div>
                                        <div style="padding: 0px 8px 0px 8px">
                                            <%#DataBinder.Eval(Container, "DataItem.RouteAmount") %>
                                        </div>
                                    </div>
                                </td>
                                <td >
                                    <div style="display:flex;justify-content:right; padding-right:6px;">
                                        <asp:Button runat="server" 
                                            ID="TrRoute" 
                                            OnCommand="TrRoute_Command" 
                                            CommandName="RouteClick" 
                                            CommandArgument='<%#DataBinder.Eval(Container, "DataItem.RouteID") %>' 
                                            Text="Xem chi tiết" 
                                            style="background-image: url(../SetImg/ic-view.png); background-repeat:no-repeat; background-position: 8px ; padding: 0px 12px 0px 48px; height: 36px; border:none; background-color: white; color: black; border-radius: 4px" >
                                        </asp:Button>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            </div>

            <div class="row" style="height: 500px;padding: 24px 22px 0px 8px; margin: 0px 0px 48px 0px">
                <div class="col-sm-4 overflow-auto" style="height: 500px; ">
                    <asp:Label ID="lblBusStops" runat="server" Visible="false"><h4>Danh sách điểm dừng</h4></asp:Label>
                    <asp:Repeater ID="RepeaterBusStops" runat="server">
                        <ItemTemplate>
                            <tr style="">
                                <td>
                                    <div style="height: 48px; border: 2px solid white; display:flex; align-items:center; box-shadow: 0px 1px 3px rgba(0,0,0,0.4); padding: 0px 8px 0px 8px; margin: 8px 0px 8px 0; border-radius:4px">
                                        <div style="width:40px; height:40px; border-radius:50%; background-color:white; display:flex; align-items:center">
                                            <asp:ImageButton ImageUrl="~/SetImg/ic-busStop32.png" Width="30px" Height="36px" AlternateText="iconBusStop" runat="server" ID="btnImgBusStop" />
                                        </div>
                                            <%#DataBinder.Eval(Container, "DataItem.BusStopName") %>
                                    </div>
                                </td>
                            
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-sm-8">
                    <div class="row">
                    </div>
                    <div class="row">
                        <div id="map" style="width: 100%; height: 500px; border: 5px solid #5e5454;"></div>
                    </div>
                </div>
            </div>
            
            </div>
            <!-- END SHOW ROUTE ON MAP BY THANH'S TEAM-->


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

