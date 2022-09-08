<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowRouteOnMap.aspx.cs" Inherits="Web.Pages.ShowRouteOnMap" %>

<asp:Content ID="ShowOnMap" ContentPlaceHolderID="Head" runat="server">

    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false" type="text/javascript"></script>
    <script>  
        var mapcode;
        var diag;
        function initialize() {
            mapcode = new google.maps.Geocoder();
            var lnt = new google.maps.LatLng(11.955537325881393, 108.44341625091612);
            var diagChoice = {
                zoom: 16,
                center: lnt,
                diagId: google.maps.MapTypeId.ROADMAP
            }
            diag = new google.maps.Map(document.getElementById('map_populate'), diagChoice);
        }

        google.maps.event.addDomListener(window, 'load', initialize);


    </script>
</asp:Content>
    <asp:Content ID="route" ContentPlaceHolderID="MainContent" runat="server">
 
        <div id="map_populate" style="width: 100%; height: 500px; border: 5px solid #5e5454;">
        </div>
    </asp:Content>

