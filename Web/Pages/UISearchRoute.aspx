<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UISearchRoute.aspx.cs" Inherits="Web.Pages.UISearchRoute" %>

<asp:Content ID="UISearchRouteHead" ContentPlaceHolderID="Head" runat="server">
    <asp:HiddenField ID="hfData" Value="" runat="server" ClientIDMode="Static" />
    <script>
        const TypeChoice = 1;
        const TypeBus = 2;
        const TypeStart = 3;
        const TypeEnd = 4;
        let zoom = 15;
        let listBusStop;
        var uniqueId = 1;
        let currentMaker;
        let startPoint;
        let markerStart;
        let listMaker = [];
        let markerEnd;
        let markerChoice;
        let map;
        let drawLine = [];
        let infoWindow;
        let busStops = [];
        let dataJson;
        let lineDirection;
        let listPosition;
        const centerDefault = { lat: 10.771119394974335, lng: 106.70050611220746 };
        const imgStart = "/SetImg/imgStart.png";
        const imgEnd = "/SetImg/imgStop.png";
        const imgCurrent = "/SetImg/imgCurrent.png";
        const imgStopBus = "/SetImg/imgStopBus.png";
        let directionsService;
        let directionsRenderer;
        function initMap() {
            directionsService = new google.maps.DirectionsService();
            directionsRenderer = new google.maps.DirectionsRenderer();
            map = new google.maps.Map(document.getElementById("map"), {
                zoom: zoom,
                center: centerDefault,
            });

            map.addListener("click", (e) => {
                currentPoint = e.latLng;
                if (markerChoice != null) {
                    markerChoice.setMap(null);
                    markerChoice = null;
                }
                console.log(e.latLng);
                markerChoice = placeMarkerAndPanTo(currentPoint, map, imgCurrent);
                google.maps.event.addListener(markerChoice, "click", function (e) {
                    showInfo(map, markerChoice, TypeChoice);
                });
                showInfo(map, markerChoice, TypeChoice);

            });
            getRoute();
        }
        function drawDirection(listLatLng) {
            if (lineDirection != null) {
                lineDirection.setMap(null);
                lineDirection = null
            };
            lineDirection = new google.maps.Polyline({
                path: listLatLng,
                geodesic: true,
                strokeColor: "#FF0000",
                strokeOpacity: 1.0,
                strokeWeight: 2,
            });
            lineDirection.setMap(map);
        }


        function getContentInfoWindow(type,data) {
            const strChoice = "Điểm được chọn";
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
                    content += `<h4 id="firstHeading" class="">${strChoice}</h4>
                        <div id="bodyContent">
                        <button type="button" class="btn btn - success" id = "btn_start_point" click = getStartPoint()>${strStart}</button>
                        <button type="button" class="btn btn-warning" id = "btn_end_point" click = getEndPoint()>${strEnd}</button>
                    </div>`;
                    break;
                case TypeBus:
                    let address = "";
                    if (data.Street) {
                        address += data.Street + ',';
                    }
                    if (data.Wards) {
                        address += data.Wards + ',';
                    } if (data.District) {
                        address += data.District + ",";
                    } if (address != "") {
                        address = "Địa điểm: " + address.substring(0, address.lastIndexOf(","));

                    };
                    content += `<h4 id="firstHeading" class="">${strChoice}</h4>
                        <div id="bodyContent">
                        <p>Tên: ${data.BusStopName}</p>
                        <p>Mô tả: ${data.BusStopDescription}</p>
                        <p>${address}</p>
                        </div>`;
                    break;
                case TypeStart:
                    content += `<h4 id="firstHeading" class="firstHeading">${strStart}</h4>
                        <div id="bodyContent">
                        <button type="button" class="btn btn-danger" id = "btn_delete_start" click = getDeletePoint(maker)>${strDelete}</button> 
                        </div>`
                    break;
                case TypeEnd:
                    content += `<h4 id="firstHeading" class="firstHeading">${strEnd}</h4>
                        <div id="bodyContent">
                        <button type="button" class="btn btn-danger" id = "btn_delete_end" click = getDeletePoint(maker)>${strDelete}</button> 
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
        $(document).on('click', '#btn_delete_start', function getStartPoint() {
            if (markerStart != null) {
                markerStart.setMap(null);
                markerStart = null;
            }
        });
        $(document).on('click', '#btn_delete_end', function getStartPoint() {
            if (markerEnd != null) {
                markerEnd.setMap(null);
                markerEnd = null;
            }
        });
        function calcRoute(listPoint) {
            let lengthList = listPoint.length;
            let start = listPoint[0];
            let midPoints = listPoint.slice(1, lengthList - 1);
            let end = listPoint[lengthList - 1];
            console.log(midPoints);
            let request = {
                origin: start,
                destination: end,
                waypoints: midPoints ,
                travelMode: 'DRIVING'
            };
            directionsService.route(request, function (result, status) {
                if (status == 'OK') {
                    directionsRenderer.setDirections(result);
                }
            });
        }
        function renderMaker(BusStops, haveDraw) {
            if (listMaker != []) {
                listMaker.forEach(marker => {
                    maker.setMap(null);
                });
            }
            listMaker = [];
            listPosition = [];
            BusStops.forEach(busStop => {
                let latLng = { lat: busStop.Latitude, lng: busStop.Longitude }
                drawLine.push(latLng);
                listMaker.push(placeMarkerAndPanTo(latLng, map, imgStopBus, TypeBus, busStop));
                listPosition.push({ location: latLng });

            });
            listBusStop = BusStops;
            if (haveDraw)
                drawDirection(drawLine);
            calcRoute(listPosition);
        }



        $(document).on('click', '#btn_start_point', function getStartPoint() {
            if (markerStart != null) {
                markerStart.setMap(null);
                markerStart = null;
            }
            markerChoice.setMap(null);
            markerStart = placeMarkerAndPanTo(currentPoint, map, imgStart, TypeStart);
            markerStart.setMap(map);


        });
        $(document).on('click', '#btn_end_point', function getEndPonit() {
            if (markerEnd != null) {
                markerEnd.setMap(null);
                markerEnd = null;
            }
            markerChoice.setMap(null);
            markerEnd = placeMarkerAndPanTo(currentPoint, map, imgEnd, TypeEnd);
            markerEnd.setMap(map);
        });
        //    $(document).on('click', '#load_all_stop_bus', loadAllStopBus());

        function loadAllStopBus() {
            if (busStops != []) {
                busStops = [];
            }
            $.ajax({
                type: "GET", //GET
                url: "ShowRouteOnMap.aspx/GetAllBusStop",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    let data = msg.d;
                    console.log(data);

                },
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }
        function placeMarkerAndPanTo(latLng, map, img, typeShow, info, id) {
            let maker = new google.maps.Marker({
                position: latLng,
                map: map,
                icon: img
            });
            map.panTo(latLng);
            if (typeShow == TypeEnd || typeShow == TypeStart || typeShow == TypeBus) {
                google.maps.event.addListener(maker, "click", function (e) {
                    showInfo(map, maker, typeShow, info);
                });
            }
            return maker;
        }
        function getRoute() {
            dataJson = $('input#hfData').val();
            console.log(dataJson, "daylatext");
            if (dataJson != "") {

                let dataRoute = JSON.parse(dataJson);
                renderMaker(dataRoute, true);

            } else {
                lineDirection.setMap(null);
            }


        }
        /*  window.document.addEventListener('DOMContentLoaded', );*/
        window.initMap = initMap;




     


    </script>
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

    <script
        src="https://maps.googleapis.com/maps/api/js?key=&callback=initMap"
        defer></script>


</asp:Content>
