﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UISearchRoute.aspx.cs" Inherits="Web.Pages.UISearchRoute" %>

<asp:Content ID="UISearchRoute" ContentPlaceHolderID="Head" runat="server">
    <asp:TextBox runat="server" ID="UISearchRouteBusRouteName" TextMode="SingleLine" Text="Nhập tên tuyến..." Columns="40"></asp:TextBox>
    <asp:Button runat="server" ID="ButtonSearchRouteByBusRouteName" Text="Tìm kiếm lộ trình" />
    <br />
    <br />
    <asp:TextBox runat="server" ID="UISearchRouteStartPoint" TextMode="SingleLine" PlaceHolder="Nhập điểm bắt đầu..." Columns="40"></asp:TextBox>
    <br />
    <asp:TextBox runat="server" ID="UISearchRouteEndPoint" TextMode="SingleLine" PlaceHolder="Nhập điểm kết thúc..." Columns="40"></asp:TextBox>
    <asp:Button runat="server" ID="ButtonSearchRouteByPoint" Text="Tìm kiếm lộ trình" />
    <div runat="server">
        <h2>Danh sách kết quả lộ trình: </h2>
        <asp:GridView ID="GridViewUISearchRouteListRoute" runat="server"></asp:GridView>
        <h2>Thông tin tuyến: </h2>
        <asp:GridView ID="GridViewUISearchRouteRouteInfomation" runat="server"></asp:GridView>
    </div>
</asp:Content>