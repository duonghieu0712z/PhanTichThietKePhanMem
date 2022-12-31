const TypeChoice = 1;
const TypeBus = 2;
const TypeStart = 3;
const TypeEnd = 4;
const TypePickLocation = 5;
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
let typeMap = $('input#typeMap').val();
const center = { lat: 11.948958322797099, lng: 108.44351244220658 };
const centerDefault = { lat: 11.948958322797099, lng: 108.44351244220658 };
const imgStart = "/SetImg/imgStart.png";
const imgEnd = "/SetImg/imgStop.png";
const imgCurrent = "/SetImg/imgCurrent.png";
const imgStopBus = "/SetImg/imgStopBus.png";
let directionsService;
let directionsRenderer;
let latStartPoint;
let lngStarPoint;
let latEndPoint;
let lngEndPoint;
let idStartPoint;
let idEndPoint;
let dataBusStops;
const typeMaps = [
    'pickLocation',
    'getRoute',
]
 
function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        zoom: zoom,
        center: centerDefault,
        styles: [
            {
                featureType: "poi.business",
                stylers: [{ visibility: "off" }],
            },
            {
                featureType: "transit",
                elementType: "labels.icon",
                stylers: [{ visibility: "off" }],
            },
        ],
    });
 

    switch (typeMap) {
        case 'pickLocation':

            break;
        case 'getRoute':
            directionsService = new google.maps.DirectionsService();
            directionsRenderer = new google.maps.DirectionsRenderer({
                'map': map,
                'suppressMarkers': true,
            });
            directionsRenderer.setOptions({
                polylineOptions: {
                    strokeColor: 'red'
                }
            });
            getRoute();
            break;
        default:
            break;
    }

    map.addListener("click", (e) => {
        currentPoint = e.latLng;
        if (markerChoice != null) {
            markerChoice.setMap(null);
            markerChoice = null;
        }
        markerChoice = placeMarkerAndPanTo(currentPoint, map, imgCurrent);
        google.maps.event.addListener(markerChoice, "click", function (e) {
            console.log(typeMap);
            showInforByTypeMap();
        });
        showInforByTypeMap();
        console.log(typeMap);
    });
    loadAllStopBus();
 
}
function showInforByTypeMap() {
    switch (typeMap) {
        case 'pickLocation':
            let position = markerChoice.getPosition();
            showInfo(map, markerChoice, TypePickLocation, position);
            getLocation(position.lat(), position.lng());
            break;
        case 'getRoute':
            showInfo(map, markerChoice, TypeChoice);
            break;
        default:
            break;
    }
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


function getContentInfoWindow(type, data) {
    console.log(data);
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
        case TypePickLocation:
            content += `<h4 id="firstHeading" class="">${strChoice}</h4>
                        <div id="bodyContent">
                        <p>Vĩ độ: ${data.lat() }</p>
                        <p>Kinh độ: ${data.lng()}</p>
                        <button type="button" class="btn btn-danger" id = "btn_delete_choice" click = getDeletePoint(maker)>${strDelete}</button>
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
$(document).on('click', '#btn_delete_choice', function getStartPoint() {
    if (markerChoice != null) {
        markerChoice.setMap(null);
        markerChoice = null;
        getLocation("", "");
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
        waypoints: midPoints,
        travelMode: 'DRIVING'
    };
    directionsService.route(request, function (result, status) {
        if (status == 'OK') {
            console.log(result);

            directionsRenderer.setDirections(result);
            directionsRenderer.setMap(map);
        } else {
            alert("Đã có lỗi xảy ra !! Vui lòng thử lại ");
        }
    });
}
function renderMaker(BusStops, haveDraw) {
    if (listMaker != []) {
        listMaker.forEach(marker => {
            marker.setMap(null);
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
    if (haveDraw) {
        //  drawDirection(drawLine);
        calcRoute(listPosition);
    }

}



$(document).on('click', '#btn_start_point', function getStartPoint() {
    if (markerStart != null) {
        markerStart.setMap(null);
        markerStart = null;
    }
    markerChoice.setMap(null);
    markerStart = placeMarkerAndPanTo(currentPoint, map, imgStart, TypeStart);
    markerStart.setMap(map);
    latStartPoint = currentPoint.lat();
    lngStarPoint = currentPoint.lng();
  

});
$(document).on('click', '#btn_end_point', function getEndPonit() {
    if (markerEnd != null) {
        markerEnd.setMap(null);
        markerEnd = null;
    }
    markerChoice.setMap(null);
    markerEnd = placeMarkerAndPanTo(currentPoint, map, imgEnd, TypeEnd);
    markerEnd.setMap(map);
    latEndPoint = currentPoint.lat();
    lngEndPoint = currentPoint.lng();
  
});
//    $(document).on('click', '#load_all_stop_bus', loadAllStopBus());


function postLocation() {
    console.log(latStartPoint);
    console.log(latEndPoint);
    console.log(lngStarPoint);
    console.log(lngEndPoint);
    let coordinatesStart = { id: idStartPoint, latitudes: latStartPoint, longitudes: lngStarPoint }
    let coordinatesEnd = { id: idEndPoint, latitudes: latEndPoint, longitudes: lngEndPoint }
    let startAndEndPoint = { start: coordinatesStart, end: coordinatesEnd }
    $.ajax({
        type: "POST",
        url: "UISearchRoute.aspx/findNearByBusStop",
        data: JSON.stringify(startAndEndPoint),
        // data: '{latitude:"' + lat + '",longitude:"' + lng + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        error: OnErrorCall
    });

    function OnSuccess(response) {
        alert(response.d);
        console.log(response.d);

    }
    function OnErrorCall(response) {
        console.log("error");

    }

}

//

//
function loadAllStopBus() {
    if (busStops != []) {
        busStops = [];
    }
    $.ajax({
        type: "GET", //GET
        url: "BusStopPage.aspx/GetAllBusStop",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            let data = msg.d;
            console.log(data);
            renderMaker(data, false);
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

    }
    //else {
    //    lineDirection.setMap(null);
    //}


}
function getLocation(lat, lng) {

    let txtlng = document.getElementById("MainContent_txtLongitude");
    let txtlat = document.getElementById("MainContent_txtLatitude");
    console.log(txtlng);
    txtlng.value = lng.toString();
    txtlat.value = lat.toString();
}

function onClickRouteItem(routeItemId) {
    var subItems = document.getElementById(`route-sub-item-${routeItemId}`)
    subItems.style.display = subItems.style.display === 'block' ? 'none' : 'block'
    if (subItems.childNodes.length === 1) {
        subItems.append(createSubRoute())
    }
}

function createSubRoute() {
    var table = document.createElement('table')
    table.style.width = '100%'
    table.style.borderCollapse = 'separate'
    table.style.borderSpacing = '0 4px'

    var tbody = document.createElement('tbody')
    var routeItem = {
        isWalk: true,
        routeNumber: 0,
        guidText: 'Đi bộ',
        startName: 'Điểm được chọn trên bản đồ',
        endName: 'Điểm kết thúc',
        distanceLength: 8,
        time: 45,
        prices: 6000
    }

    tbody.appendChild(
        createSubRouteItem(
            routeItem.isWalk, routeItem.routeNumber, routeItem.guidText,
            routeItem.startName, routeItem.endName, routeItem.distanceLength,
            routeItem.time, routeItem.prices))

    routeItem.routeNumber = 45
    routeItem.isWalk = false

    tbody.appendChild(
        createSubRouteItem(
            routeItem.isWalk, routeItem.routeNumber, routeItem.guidText,
            routeItem.startName, routeItem.endName, routeItem.distanceLength,
            routeItem.time, routeItem.prices))

    table.appendChild(tbody)

    return table
}

function createSubRouteItem(isWalk, routeNumber, guidText, startName, endName, distanceLength, time, prices) {

    var tr = document.createElement('tr')
    tr.style.backgroundColor = 'white'
    tr.style.boxShadow = '0px 1px 3px rgba(0,0,0,0.4)'
    tr.style.width = '100%'
    tr.style.height = '48px'

    var td_icon = document.createElement('td')
    td_icon.style.padding='0px 8px'
    if (isWalk === true) {
        var img = document.createElement('img')
        img.src = '../SetImg/ic-walk.png'
        img.alt = 'ic-walk'
        td_icon.appendChild(img)
    } else if (isWalk === false) {
        let div = document.createElement('div')
        div.style.width = '32px'
        div.style.height = '32px'
        div.style.borderRadius = '50%'
        div.style.backgroundColor = '#34B67A'
        div.style.display = 'flex'
        div.style.justifyContent = 'center'
        div.style.alignItems = 'center'
        div.style.color='white'
        div.innerHTML = routeNumber
        td_icon.appendChild(div)
    }

    var td_guidText = document.createElement('td')
    td_guidText.innerHTML = guidText
    td_guidText.style.width='32%'

    var td_start = document.createElement('td')
    var start_div_1 = document.createElement('div')
    start_div_1.style.fontSize = '12px'
    var start_div_2 = document.createElement('div')
    start_div_2.style.textAlign = 'center'
    start_div_2.innerHTML = 'Từ'
    var start_div_3 = document.createElement('div')
    start_div_3.style.color = '#34b67a'
    start_div_3.style.textAlign = 'center'
    start_div_3.innerHTML = startName
    start_div_2.appendChild(start_div_3)
    start_div_1.appendChild(start_div_2)
    td_start.appendChild(start_div_1)
    
    var td_end = document.createElement('td')
    var end_div_1 = document.createElement('div')
    end_div_1.style.fontSize = '12px'
    var end_div_2 = document.createElement('div')
    end_div_2.style.textAlign = 'center'
    end_div_2.innerHTML = 'Từ'
    var end_div_3 = document.createElement('div')
    end_div_3.style.color = '#34b67a'
    end_div_3.style.textAlign = 'center'
    end_div_3.innerHTML = endName
    end_div_2.appendChild(end_div_3)
    end_div_1.appendChild(end_div_2)
    td_end.appendChild(end_div_1)

    var td_distanceLenght = document.createElement('td')
    td_distanceLenght.innerHTML = `${distanceLength} km`

    var td_time = document.createElement('td')
    td_time.innerHTML = `${time} phút` 

    var td_prices = document.createElement('td')
    td_prices.innerHTML = `${prices} đ` 

    //-- append
    tr.appendChild(td_icon)
    tr.appendChild(td_guidText)
    tr.appendChild(td_start)
    tr.appendChild(td_end)
    tr.appendChild(td_distanceLenght)
    tr.appendChild(td_time)
    tr.appendChild(td_prices)

    return tr
}


/*  window.document.addEventListener('DOMContentLoaded', );*/
window.initMap = initMap;