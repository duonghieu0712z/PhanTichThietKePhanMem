<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowRouteOnMap.aspx.cs" Inherits="Web.Pages.ShowRouteOnMap" %>

<asp:Content ID="ShowOnMap" ContentPlaceHolderID="Head" runat="server">
    <script>
        let array = [];
        function initMap() {
            const myLatlng = { lat: -25.363, lng: 131.044 };
            const map = new google.maps.Map(document.getElementById("map"), {
                zoom: 4,
                center: myLatlng,
            });
            const marker = new google.maps.Marker({
                position: myLatlng,
                map,
                title: "Click to zoom",
            });

            map.addListener("center_changed", () => {
                // 3 seconds after the center of the map has changed, pan back to the
                // marker.
                window.setTimeout(() => {
                    map.panTo(marker.getPosition());
                }, 3000);
            });
            map.addListener("click", (e) => {
                placeMarkerAndPanTo(e.latLng, map);
            });

        }
        function placeMarkerAndPanTo(latLng, map) {
            new google.maps.Marker({
                position: latLng,
                map: map,
            });
            map.panTo(latLng);
        }
        window.initMap = initMap;
    </script>
</asp:Content>
<asp:Content ID="route" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 800px">
        <div class="col-sm-9">
            <div id="map" style="height: 100%"></div>
        </div>
        <div class="col-sm-3">
            <h1>test</h1>
        </div>

    </div>
    <script
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDz0PKtri5vQnfnCGvMbnQYF6s-1z649LE&region=VN&language=vi&callback=initMap&v"
        defer></script>

</asp:Content>


