<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UISearchRoute.aspx.cs"
    Inherits="Web.Pages.UISearchRoute" %>

    <asp:Content ID="UISearchRouteHead" ContentPlaceHolderID="Head" runat="server">
        <asp:HiddenField ID="hfData" Value="" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="typeMap" Value="getRoute" runat="server" ClientIDMode="Static" />
        <script src ="../JavaScript/Map/map.js"></script>
       <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBK9sw5PYYq0MW-HBbXVMNN6rwZIEBuvhw&callback=initMap" defer></script>
    <style type="text/css">
        .desc-icon{
            width: 40px;
            height: 40px;
            border-radius: 24px;
            background-color: #ffffff;
            display:inline-block;
            padding:4px;
        }
        .online-table-data{
            display:inline-block;
            margin-top: -1px;
            float: right;
            border:none;
        }
        .tr-search-route-result{
            background-color: #34B67A;
            border: 2px solid #ffffff;
            font-size: 18px;
            font-weight: 600;
            color: #ffffff;
            cursor: pointer;
            width:100%;
        }
        .center-vertical-container{
            display:flex;
            justify-items:center;
            align-items:center;
            height: 40px;
        }
        .desc-detail-icon{
            width: 40px;
            height:40px;
            padding: 4px;
        }
        .desc-detail-bus-route-number{
            width:40px;
            height:40px;
            background-color: #34B67A;
            border-radius: 20px;
            font-size: 18px;
            color: #ffffff;
            text-align:center;
            padding-top: 8px;
        }
        .td-detail-text-container{
            text-align: center;
            font-size:12px;
        }
        .tr-search-route-result-detail-container{
            padding: 4px;
            background-color: #f4f4f4;
            margin:2px;
        }
        .table-detail{
            border: 1px solid #c4c4c4;
        }
        .tb-detail-tr{
            border: 1px solid #c4c4c4;
        }
        .tb-detail-td{
            padding: 4px;
        }
        .table-header{
            margin-bottom: 0px;
        }

        .route-tr{
            background-color: #34B67A;
            height:48px;
        }
    </style>
    
    <script type="text/javascript">
        function handleClickOnTrResultRoute()
        {
            this.lbTest.Text = "def";
        }
    </script>
</asp:Content>

<asp:Content ID="UISearchRouteMainContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="form-group">
        <div class="row">
            <div class="d-flex justify-content-center mt-4 align-items-center" style="width: 100%">
                <div class="col-sm-3 align-items-center">
                    <asp:ImageButton ImageUrl="~/SetImg/ic-swap.png" runat="server" 
                        Style="float: right;background-color: #34B67A; width:48px; height: 80px; padding: 24px 8px 24px 8px; border-radius: 4px" />
                </div>
                <div class="col-sm-6 " style="padding: 0px 24px 0px 24px">
                    <div class="form-group">
                        <asp:DropDownList CssClass="form-control" 
                            AutoPostBack="true" ID="dlStartPosition"
                            runat="server"
                            Style="width: 100% !important; max-width: 100% !important;"
                            Visible="true">
                        </asp:DropDownList>

                        <div id="choseStartPositionContainer"
                            style="position: relative; display: flex; align-items: center; justify-content: space-between; border: 1px solid #c4c4c4; padding:0; margin: 0; border-radius: 4px">
                            <input id="inputChoseStartPosition" 
                            placeholder="<Điểm được chọn trên bản đồ>"
                                style="height: 40px; border: none; width: 100%; border-radius: 4px; padding: 0px 32px 0px 12px"/>
                            <button id="btnRemoveStartPosition" 
                                style="width:32px; height:32px; background-color: transparent; position: absolute; right: 4px; top: 5px; display: flex; justify-content:center; border: none; border-radius: 4px; padding: 2px 0px">
                                <img src="../SetImg/ic-close-red.png" alt="ic-close"
                                style="width: 24px; height: 24px; object-fit:contain"/>
                            </button>
                        </div>

                        <asp:DropDownList
                            CssClass="form-control mt-1"
                            AutoPostBack="true"
                            ID="dlEndPosition"
                            runat="server"
                            Style="width: 100% !important; max-width: 100% !important;"
                            Visible="true">
                        </asp:DropDownList>

                        <div id="choseEndPositionContainer"
                            style="position: relative; display: flex; align-items: center; justify-content: space-between; border: 1px solid #c4c4c4; padding:0; margin: 0; border-radius: 4px">
                            <input id="inputChoseEndPosition" 
                            placeholder="<Điểm được chọn trên bản đồ>"
                                style="height: 40px; border: none; width: 100%; border-radius: 4px; padding: 0px 32px 0px 12px"/>
                            <button id="btnRemoveEndPosition" 
                                style="width:32px; height:32px; background-color: transparent; position: absolute; right: 4px; top: 5px; display: flex; justify-content:center; border: none; border-radius: 4px; padding: 2px 0px">
                                <img src="../SetImg/ic-close-red.png" alt="ic-close"
                                style="width: 24px; height: 24px; object-fit:contain"/>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3 d-flex justify-content-left align-items-center">
                    <asp:ImageButton ImageUrl="~/SetImg/ic-search.png" runat="server" 
                        ID="imgbtnSearch" 
                        OnClick="imgbtnSearch_Click" 
                        Style="background-color: #34B67A; width:48px; height: 80px; padding: 24px 8px 24px 8px; border-radius: 4px" />
                    <%--Nút để tìm điểm gần nhất--%>
                    <button type="button" onclick="postLocation()"></button>
                </div>
            </div>
        </div>


        <div class="row mt-4" style="padding-left:8px; padding-right: 8px">
        <div class="col-sm-12 overflow-auto">
            <asp:Label id="lblRoute" Visible="false" runat="server"
            ><h4>Danh sách Lộ trình</h4></asp:Label>
            <asp:GridView Visible="false" style="width:100%" 
                OnRowDataBound="GridViewSearchRoute_RowDataBound" 
                ID="GridViewSearchRoute" 
                CssClass="table table-bordered table-striped" 
                runat="server" 
                AutoGenerateSelectButton="true"
                OnSelectedIndexChanged="GridViewSearchRoute_SelectedIndexChanged"
                SelectedRowStyle-BackColor="#34B67A"
                SelectedRowStyle-ForeColor="White">
            </asp:GridView>
            <div>
                <asp:Repeater ID="RepeatRoute" runat="server" Visible="false">
                    <ItemTemplate>
                        <table style="width: 100%">  
                        <tr id="route-item-<%#DataBinder.Eval(Container, "DataItem.RouteID") %>" 
                            onClick="onClickRouteItem(<%#DataBinder.Eval(Container, "DataItem.RouteID") %>)"
                            style="background-color:#34B67A; width:100%; height: 48px; border: 2px solid white; color: white; cursor:pointer">
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
                        </table>
                        <div class="route-sub-item" id="route-sub-item-<%#DataBinder.Eval(Container, "DataItem.RouteID") %>"
                            style="padding:0px 4px 0px 4px; background-color:#f0f0f0; margin: 4px; display:none">
                            <%--<table style="width: 100%; border-spacing: 0 4px; border-collapse: separate">
                                <tr class="rsi-walk" 
                                    style="background-color:white; box-shadow: 0px 1px 3px rgba(0,0,0,0.4); width:100%; height: 48px;">
                                    <td style="padding:0px 8px"><img src="../SetImg/ic-walk.png" alt="ic-walk"/></td>
                                    <td style="width:32%">Đi bộ</td>
                                    <td><div style="font-size: 12px"> 
                                        <div style="text-align:center;">Từ</div>
                                        <div style="color: #34B67A; text-align:center; "><Điểm được chọn trên bản đồ></div>
                                    </div></td>
                                    <td><div style="font-size: 12px">
                                        <div style="text-align:center">Đến</div>
                                        <div style="color: #34B67A; text-align: center; "><Điểm được chọn trên bản đồ></div>
                                    </div></td>
                                    <td>0.3 km</td>
                                    <td>3 phút</td>
                                    <td>6.0000 đ</td>
                                </tr>
                                <tr class="rsi-route" 
                                    style="background-color:white; box-shadow: 0px 1px 3px rgba(0,0,0,0.4); width:100%; height: 48px;">
                                    <td style="padding:0px 8px"><div 
                                        style="width:32px; height: 32px; border-radius: 50%; background-color: #34B67A; display: flex; justify-content:center; align-items:center; color: white; "
                                        >45</div></td>
                                    <td style="width:32%">Đi bộ</td>
                                    <td><div style="font-size: 12px"> 
                                        <div style="text-align:center;">Từ</div>
                                        <div style="color: #34B67A; text-align:center; "><Điểm được chọn trên bản đồ></div>
                                    </div></td>
                                    <td><div style="font-size: 12px">
                                        <div style="text-align:center">Đến</div>
                                        <div style="color: #34B67A; text-align: center; "><Điểm được chọn trên bản đồ></div>
                                    </div></td>
                                    <td>0.3 km</td>
                                    <td>3 phút</td>
                                    <td>6.0000 đ</td>
                                </tr>
                            </table>--%>
                        </div>
                    </ItemTemplate>
                    
                </asp:Repeater>
            </div>
        </div>
        
        </div>
        <div class="row" style="padding-left: 8px; padding-right: 22px; height: 500px; padding-top:24px">
            <div class="col-sm-4 overflow-auto" style="height: 500px; ">
                <asp:GridView Visible="false"
                    ID="GridViewSearchBusStop"
                    OnRowDataBound="GridViewSearchBusStop_RowDataBound"
                    CssClass="table table-bordered table-striped"
                    runat="server">
                </asp:GridView>
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

   


    </asp:Content>
