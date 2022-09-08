<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowRouteOnMap.aspx.cs" Inherits="Web.Pages.ShowRouteOnMap" %>

<asp:Content ID="ShowOnMap" ContentPlaceHolderID="Head" runat="server">
 


    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&key=AIzaSyDz0PKtri5vQnfnCGvMbnQYF6s-1z649LE" type="text/javascript"></script>
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
        function getmap() {
            var completeaddress = document.getElementById('txt_location').value;
            mapcode.geocode({ 'address': completeaddress }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    diag.setCenter(results[0].geometry.location);
                    var hint = new google.maps.Marker({
                        diag: diag,
                        position: results[0].geometry.location
                    });
                } else {
                    alert('Location Not Tracked. ' + status);
                }
            });
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>

</asp:Content>


    <asp:Content ID="route" ContentPlaceHolderID="MainContent" runat="server">
 
        <div>
            <h1>enter your location details</h1>
        </div>
        <div>
            <asp:textbox id="txt_location" textmode="multiline" width="400px" height="70px" runat="server"></asp:textbox>
        </div>
        <div>
            <input type="button" value="search" onclick="getmap()">
        </div>
        <div id="map_populate" style="width: 100%; height: 500px; border: 5px solid #5e5454;">
        </div>
    </asp:Content>

