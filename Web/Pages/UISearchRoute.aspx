<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UISearchRoute.aspx.cs"
    Inherits="Web.Pages.UISearchRoute" %>

    <asp:Content ID="UISearchRouteHead" ContentPlaceHolderID="Head" runat="server">
        <asp:HiddenField ID="hfData" Value="" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="typeMap" Value="getRoute" runat="server" ClientIDMode="Static" />
        <script src ="../JavaScript/Map/map.js"></script>
       <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAqDGCtUCp7HDWxfqnWiy-Z2TZfVhDxuKA&callback=initMap" defer></script>
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
            <div class="d-flex justify-content-center mt-4" style="width: 100%">
                <div class="col-sm-3">
                    <asp:ImageButton ImageUrl="~/SetImg/ic-swap.png" runat="server" Style="float: right;background-color: #34B67A; width:48px; height: 72px; margin-bottom: 12px; padding-top: 20px; padding-bottom: 20px;padding-left: 8px; padding-right:8px" />
                </div>
                <div class="col-sm-6 ">
                    <div class="form-group">
                        <asp:DropDownList CssClass="form-control"
                            AutoPostBack="true" ID="dlStartPosition"
                            runat="server"
                            Style="width: 100% !important; max-width: 100% !important">
                        </asp:DropDownList>
                        <asp:DropDownList
                            CssClass="form-control mt-1"
                            AutoPostBack="true"
                            ID="dlEndPosition"
                            runat="server"
                            Style="width: 100% !important; max-width: 100% !important">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-3 d-flex justify-content-left align-items-center">
                    <asp:ImageButton ImageUrl="~/SetImg/ic-search.png" runat="server" ID="imgbtnSearch" OnClick="imgbtnSearch_Click" Style="background-color: #34B67A; width:48px; height: 72px; margin-bottom: 12px; padding-top: 20px; padding-bottom: 20px;padding-left: 8px; padding-right:8px" />
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
            <asp:Label id="lbTest" runat="server"></asp:Label>

             

        </div>
        
        </div>
        <div class="row" style="padding-left: 8px; padding-right: 22px; height: 500px">
            <div class="col-sm-4 overflow-auto" style="height: 500px">
                <asp:GridView Visible="false"
                    ID="GridViewSearchBusStop"
                    OnRowDataBound="GridViewSearchBusStop_RowDataBound"
                    CssClass="table table-bordered table-striped"
                    runat="server">
                </asp:GridView>
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
