<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowRouteOnMap.aspx.cs" Inherits="Web.Pages.ShowRouteOnMap" %>

<asp:Content ID="ShowOnMap" ContentPlaceHolderID="Head" runat="server">
    <asp:HiddenField runat="server" ID="start_point" />
    <asp:HiddenField runat="server" ID="end_point" />
    <asp:HiddenField runat="server" ID="current_point" />
  
</asp:Content>


<asp:Content ID="route" ContentPlaceHolderID="MainContent" runat="server">
  
</asp:Content>
