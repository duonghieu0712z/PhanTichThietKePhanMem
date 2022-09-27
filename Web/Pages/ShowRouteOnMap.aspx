<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowRouteOnMap.aspx.cs" Inherits="Web.Pages.ShowRouteOnMap" %>

<asp:Content ID="ShowOnMap" ContentPlaceHolderID="Head" runat="server">
    <asp:HiddenField runat="server" ID="start_point" />
    <asp:HiddenField runat="server" ID="end_point" />
    <asp:HiddenField runat="server" ID="current_point" />
    <script>
        const TypeChoice = 1;
        const TypeBus = 2;
        const TypeStart = 3;
        const TypeEnd = 4;
        let zoom = 15;
        var uniqueId = 1;
        let curentMaker;
        let startPoint;
        let markerStart;
        let markerEnd;
        let markerChoice;
        let map;
        let infoWindow;
        let listStopbus = [];
        const centerDefault = { lat: 10.771119394974335, lng: 106.70050611220746 };
        const imgStart = "/SetImg/imgStart.png";
        const imgEnd = "/SetImg/imgStop.png";
        const imgCurent = "/SetImg/imgCurrent.png";
        const imgStopBus = "/SetImg/imgStopBus.png";
        function initMap() {
            map = new google.maps.Map(document.getElementById("map"), {
                zoom: zoom,
                center: centerDefault,
            });

            map.addListener("click", (e) => {
                curentPoint = e.latLng;
                if (markerChoice != null) {
                    markerChoice.setMap(null);
                    markerChoice = null;
                }
                console.log(e.latLng);
                markerChoice = placeMarkerAndPanTo(curentPoint, map, imgCurent);
                google.maps.event.addListener(markerChoice, "click", function (e) {
                    showInfo(map, markerChoice, TypeChoice);
                });
                showInfo(map, markerChoice, TypeChoice);

            });
        }

        function getContentInfoWindow(type) {
            const strChoie = "Điểm được chọn";
            const strStart = "Điểm bắt đầu";
            const strEnd = "Điểm kết thúc";
            const strBusStop = "Điểm được chọn";
            const strDelete = "Xóa điểm";
            let content =
                '<div id="content">' +
                '<div  id="siteNotice">' +
                "</div>";
            switch (type) {
                case TypeChoice:
                    content += `<h4 id="firstHeading" class="">${strChoie}</h4>
                        <div id="bodyContent">
                        <button type="button" class="btn btn - success" id = "btn_start_point" click = getStartPoint()>${strStart}</button>
                        <button type="button" class="btn btn-warning" id = "btn_end_point" click = getEndPoint()>${strEnd}</button>`;
                    break;
                case TypeBus:

                    break;
                case TypeStart:
                    content += `<h4 id="firstHeading" class="firstHeading">${strStart}</h4>
                        <div id="bodyContent">
                        <button type="button" class="btn btn-danger" id = "btn_delete_point" click = getDeletePoint(maker)>${strDelete}</button> 
                        </div>`
                    break;
                case TypeEnd:
                    content += `<h4 id="firstHeading" class="firstHeading">${strEnd}</h4>
                        <div id="bodyContent">
                        <button type="button" class="btn btn-danger" id = "btn_delete_point" click = getDeletePoint(maker)>${strDelete}</button> 
                        </div>`
                    break;
            }
            content += `</div>
                </div>
                </div>`
            return content;
        }

        function showInfo(map, maker, typeContent, info) {
            if (infoWindow != null && infoWindow.getMap() != null) {
                infoWindow.close();
            }
            infoWindow = new google.maps.InfoWindow({
                content: getContentInfoWindow(typeContent, info)
            });
            infoWindow.open(map, maker);
        }
        $(document).on('click', '#btn_delete_point', function getStartPoint() {
            if (markerStart != null) {
                markerStart.setMap(null);
                markerStart = null;
            }


        });

        $(document).on('click', '#btn_start_point', function getStartPoint() {
            if (markerStart != null) {
                markerStart.setMap(null);
                markerStart = null;
            }
            markerChoice.setMap(null);
            markerStart = placeMarkerAndPanTo(curentPoint, map, imgStart, TypeStart);
            markerStart.setMap(map);



        });
        $(document).on('click', '#btn_end_point', function getEndPonit() {
            if (markerEnd != null) {
                markerEnd.setMap(null);
                markerEnd = null;
            }
            markerChoice.setMap(null);
            markerEnd = placeMarkerAndPanTo(curentPoint, map, imgEnd, TypeEnd);
            markerEnd.setMap(map);
        });
    //    $(document).on('click', '#load_all_stop_bus', loadAllStopBus());

        function loadAllStopBus() {
            if (listStopbus != []) {
                listStopbus = [];
            }
            $.ajax({
                type: "GET", //GET
                url: "ShowRouteOnMap.aspx/GetAllBusStop",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    console.log(msg);
                    alert(response.d);
                },
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }
        function placeMarkerAndPanTo(latLng, map, img, typeShow, info) {
            let maker = new google.maps.Marker({
                position: latLng,
                map: map,
                icon: img
            });
            map.panTo(latLng);
            if (typeShow == TypeEnd || typeShow == TypeStart) {
                google.maps.event.addListener(maker, "click", function (e) {

                    showInfo(map, maker, typeShow, info);
                });
            }
            return maker;
        }


        window.initMap = initMap;

    </script>
</asp:Content>


<asp:Content ID="route" ContentPlaceHolderID="MainContent" runat="server">
    <div id="map" style="width: 100%; height: 500px; border: 5px solid #5e5454;"></div>
    <script
        src="https://maps.googleapis.com/maps/api/js?key=&callback=initMap"
        defer></script>

    <input type="button" id="load_all_stop_bus" Text="Tất cả địa điểm" onclick="loadAllStopBus()"/>

</asp:Content>
