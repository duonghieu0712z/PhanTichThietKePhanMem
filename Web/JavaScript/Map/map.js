const TypeChoice = 1;
const TypeBus = 2;
const TypeStart = 3;
const TypeEnd = 4;
const TypePickLocation = 5;
let zoom = 15;
let listBusStop;
var uniqueId = 1;
let startData = {};
let endData = {};
let tempData = {};
let currentMaker;
let startPoint;
let markerStart;
let listMaker = [];
let wark = "Đi bộ";
let goOnRoute = "Trên tuyến";
let markerEnd;
let markerChoice;
let map;
let mapPoint = "Điểm được chọn trên map";
let buttonSearch = document.getElementById("MainContent_imgbtnSearch");
let drawLine = [];
let infoWindow;
let busStops = [];
let dataJson;
let lineDirection;
let listPosition;
let btnSearchDrop = $("input#MainContent_imgbtnSearch");
let btnSearchMapJS = $("button#btn-search-map-js");
let dropStart = $("select#MainContent_dlStartPosition");
let dropEnd = $("select#MainContent_dlEndPosition");
let clearEndInput = $("button#btnRemoveEndPosition");
let clearStartInput = $("button#btnRemoveStartPosition");
let inputEnd = $("input#inputChoseEndPosition");
let inputStart = $("input#inputChoseStartPosition");
let componentStart = $("div#choseStartPositionContainer");
let componentEnd = $("div#choseEndPositionContainer");
let typeMap = $("input#typeMap").val();
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
let displaySubRouteData;
//let directionsDisplay;
CheckDisplay();
let polylineWark;
let polylineDriving;
const typeMaps = ["pickLocation", "getRoute"];
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
	polylineWark = new google.maps.Polyline({
		strokeColor: "#00D107",
		strokeOpacity: 1.0,
		strokeWeight: 3,
	});
	polylineDriving = new google.maps.Polyline({
		strokeColor: "#0015B3",
		strokeOpacity: 1.0,
		strokeWeight: 4,
	});
	switch (typeMap) {
		case "pickLocation":
			break;
		case "getRoute":
			directionsService = new google.maps.DirectionsService();
			directionsRenderer = new google.maps.DirectionsRenderer({
				map: map,
				suppressMarkers: true,
			});
			directionsRenderer.setOptions({
				polylineOptions: {
					strokeColor: "red",
				},
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
			showInfoByTypeMap();
		});
		showInfoByTypeMap();
	});
	loadAllStopBus();
}
function resetDataMap() {
	$("input#hfData").val("");
}
function showInfoByTypeMap() {
	switch (typeMap) {
		case "pickLocation":
			let position = markerChoice.getPosition();
			showInfo(map, markerChoice, TypePickLocation, position);
			getLocation(position.lat(), position.lng());
			break;
		case "getRoute":
			showInfo(map, markerChoice, TypeChoice);
			break;
		default:
			break;
	}
}
function drawDirection(listLatLng) {
	if (lineDirection != null) {
		lineDirection.setMap(null);
		lineDirection = null;
	}
	lineDirection = new google.maps.Polyline({
		path: listLatLng,
		geodesic: true,
		strokeColor: "#FF0000",
		strokeOpacity: 1.0,
		strokeWeight: 2,
	});
	lineDirection.setMap(map);
}

function getContentInfoWindow(type, data, maker) {
	const strChoice = "Điểm được chọn";
	const strStart = "Điểm bắt đầu";
	const strEnd = "Điểm kết thúc";
	const strBusStop = "Điểm được chọn";
	const strDelete = "Xóa điểm";
	let value = maker.getPosition();
	if (type != TypeChoice && type != TypePickLocation) {
		deleteCurrent();
	}
	let content = '<div id="content">' + '<div  id="siteNotice">' + "</div>";
	switch (type) {
		case TypeChoice:
			content += `<h4 id="firstHeading" class="">${strChoice}</h4>
                        <div id="bodyContent">
                        <button type="button" class="btn btn-success" id = "btn_start_point" onclick = "setStartPoint('${value.lat()}','${value.lng()}')">${strStart}</button>
                        <button type="button" class="btn btn-warning" id = "btn_end_point" onclick = "setEndPoint('${value.lat()}','${value.lng()}')">${strEnd}</button>
                    </div>`;
			break;
		case TypePickLocation:
			content += `<h4 id="firstHeading" class="">${strChoice}</h4>
                        <div id="bodyContent">
                        <p>Vĩ độ: ${data.lat()}</p>
                        <p>Kinh độ: ${data.lng()}</p>
                        <button type="button" class="btn btn-danger" id = "btn_delete_choice" click = getDeletePoint()>${strDelete}</button>
                    </div>`;
			break;
		case TypeBus:
			let address = "";
			if (data.Street) {
				address += data.Street + ",";
			}
			if (data.Wards) {
				address += data.Wards + ",";
			}
			if (data.District) {
				address += data.District + ",";
			}
			if (address != "") {
				address = "Địa điểm: " + address.substring(0, address.lastIndexOf(","));
			}
			content += `<h4 id="firstHeading" class="">${strChoice}</h4>
                        <div id="bodyContent">
                        <p>Tên: ${data.BusStopName}</p>
                        <p>Mô tả: ${data.BusStopDescription}</p>
                        <p>${address}</p>
                        <button type="button" class="btn btn-success" id = "btn_start_point" onclick = "setStartPoint('${value.lat()}','${value.lng()}','${
				data ? data.BusStopID : ""
			}')">${strStart}</button>
                       <button type="button" class="btn btn-warning" id = "btn_end_point" onclick = "setEndPoint('${value.lat()}','${value.lng()}','${
				data ? data.BusStopID : ""
			}')">${strEnd}</button>
                        </div>`;
			break;
		case TypeStart:
			content += `<h4 id="firstHeading" class="firstHeading">${strStart}</h4>
                        <div id="bodyContent">
                        <button type="button" class="btn btn-danger" id = "btn_delete_start" onclick = "deleteStartPoint()">${strDelete}</button> 
                        </div>`;
			break;
		case TypeEnd:
			content += `<h4 id="firstHeading" class="firstHeading">${strEnd}</h4>
                        <div id="bodyContent">
                        <button type="button" class="btn btn-danger" id = "btn_delete_end" onclick = "deleteEndPoint()">${strDelete}</button> 
                        </div>`;
			break;
	}
	content += `</div>
                </div>
                </div>`;
	return content;
}

function deleteStartPoint() {
	if (markerStart != null) {
		markerStart.setMap(null);
		markerStart = null;
	}
	inputStart.val("");
	startData = null;
	CheckDisplay();
}
function deleteEndPoint() {
	if (markerEnd != null) {
		markerEnd.setMap(null);
		markerEnd = null;
	}
	inputEnd.val("");
	endData = null;
	CheckDisplay();
}
function CheckDisplay() {
	if (markerStart || markerEnd) {
		showDropDown(false);
		showInput(true);
	} else {
		showInput(false);
		showDropDown(true);
	}
}
function deleteCurrent() {
	if (markerChoice != null) {
		markerChoice.setMap(null);
		markerChoice = null;
	}
}
function showDropDown(display) {
	if (display) {
		dropEnd.css("display", "");
		dropStart.css("display", "");
		btnSearchDrop.css("display", "");
	} else {
		dropEnd.css("display", "none");
		dropStart.css("display", "none");
		btnSearchDrop.css("display", "none");
	}
}
function showInput(display) {
	if (display) {
		btnSearchMapJS.css("display", "");
		componentStart.css("display", "");
		componentEnd.css("display", "");
	} else {
		btnSearchMapJS.css("display", "none");
		componentStart.css("display", "none");
		componentEnd.css("display", "none");
	}
}
function setStartPoint(lat, lng, id) {
	showDropDown();
	deleteStartPoint();
	clearDirection();
	if (id) {
		startData = { ...tempData };
		if (startData) inputStart.val(startData.BusStopName);
	} else {
		inputStart.val(mapPoint);
	}
	let latLng = { lat: Number(lat), lng: Number(lng) };
	infoWindow.close();
	markerStart = placeMarkerAndPanTo(latLng, map, imgStart, TypeStart);
	CheckDisplay();
}
function setEndPoint(lat, lng, id) {
	deleteEndPoint();
	showDropDown();
	clearDirection();
	if (id) {
		endData = { ...tempData };
		if (endData) inputEnd.val(endData.BusStopName);
	} else {
		inputEnd.val(mapPoint);
	}
	let latLng = { lat: Number(lat), lng: Number(lng) };
	infoWindow.close();
	markerEnd = placeMarkerAndPanTo(latLng, map, imgEnd, TypeEnd);
	CheckDisplay();
}
function showInfo(map, maker, typeContent, info) {
	if (infoWindow != null && infoWindow.getMap() != null) {
		infoWindow.close();
	}
	tempData = { ...info };
	infoWindow = new google.maps.InfoWindow({
		content: getContentInfoWindow(typeContent, info, maker),
	});
	infoWindow.open(map, maker);
}

function calcRoute(listPoint) {
	let lengthList = listPoint.length;
	let start = listPoint[0];
	let midPoints = listPoint.slice(1, lengthList - 1);
	let end = listPoint[lengthList - 1];
	let request = {
		origin: start,
		destination: end,
		waypoints: midPoints,
		travelMode: "DRIVING",
	};
	directionsService.route(request, function (result, status) {
		if (status == "OK") {
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
		listMaker.forEach((marker) => {
			marker.setMap(null);
		});
	}
	listMaker = [];
	listPosition = [];
	BusStops.forEach((busStop) => {
		let latLng = { lat: busStop.Latitude, lng: busStop.Longitude };
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
function getStartPoint(e, marker) {
	if (markerStart != null) {
		markerStart.setMap(null);
		markerStart = null;
	}
	if (marker) {
		markerStart = placeMarkerAndPanTo(marker.getPosition(), map, imgStart, TypeStart);
	} else {
		if (markerChoice) markerChoice.setMap(null);
		markerStart = placeMarkerAndPanTo(currentPoint, map, imgStart, TypeStart);
	}

	markerStart.setMap(map);
}
// $(document).on("click", "#btn_start_point", function getStartPoint(e, marker) {
// 	if (markerStart != null) {
// 		markerStart.setMap(null);
// 		markerStart = null;
// 	}
// 	if (marker) {
// 		markerStart = placeMarkerAndPanTo(
// 			marker.getPosition(),
// 			map,
// 			imgStart,
// 			TypeStart
// 		);
// 	} else {
// 		if (markerChoice) markerChoice.setMap(null);
// 		markerStart = placeMarkerAndPanTo(currentPoint, map, imgStart, TypeStart);
// 	}
// 	markerStart.setMap(map);
// });

//    $(document).on('click', '#load_all_stop_bus', loadAllStopBus());

function postLocation() {
	if (!markerStart) {
		alert("Không có điểm bắt đầu");
		return;
	}
	if (!markerEnd) {
		alert("Không có điểm bắt đầu");
		return;
	}
	let startLocation = markerStart.getPosition();
	let endLocation = markerEnd.getPosition();
	let coordinatesStart = {
		id: startData ? startData.BusStopID : 0,
		latitudes: startLocation.lat(),
		longitudes: startLocation.lng(),
	};

	let coordinatesEnd = {
		id: endData ? endData.BusStopID : 0,
		latitudes: endLocation.lat(),
		longitudes: endLocation.lng(),
	};
	let startAndEndPoint = { start: coordinatesStart, end: coordinatesEnd };
	$.ajax({
		type: "POST",
		url: "UISearchRoute.aspx/findNearByBusStop",
		data: JSON.stringify(startAndEndPoint),
		// data: '{latitude:"' + lat + '",longitude:"' + lng + '"}',
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: OnSuccess,
		error: OnErrorCall,
	});

	function OnSuccess(response) {
		if (response.d.length == 0) {
			alert("Hai điểm được chọn quá gần nhau");
			return;
		}
		clearDirection();
		displaySubRouteData = loadRouteToMap(coordinatesStart, coordinatesEnd, response.d);
		createSubRoute(displaySubRouteData);
		createDisplayRoute(response.d, displaySubRouteData);
	}
	function OnErrorCall(response) {
		console.log("error");
	}
}

function createDisplayRoute(routes, subRouteItems) {
	//clear data
	var oldtable = document.getElementById("server-side-route-table");
	oldtable.style.display = "none";
	try {
		document.getElementById("server-side-route-title").style.display = "none";
	} catch (ex) {}
	document.getElementById("old-stop-route-container").style.display = "none";

	var container = document.getElementById("display-sub-route-container");
	container.innerHTML = null;
	var title = document.createElement("h4");
	title.innerHTML = "Danh sách lộ trình";
	container.appendChild(title);

	for (let i = 0; i < routes.length; i++) {
		let subContainer = document.createElement("div");

		let table = document.createElement("table");
		table.style.width = "100%";

		let tbody = document.createElement("tbody");

		tbody.appendChild(createDisplayRouteItem(i + 1, routes[i].route, routes[i].listBusStop));

		let div_subs_container = document.createElement("div");
		div_subs_container.style.padding = "0px 4px 0px 4px";
		div_subs_container.style.backgroundColor = "#f0f0f0";
		div_subs_container.style.margin = "4px";
		div_subs_container.style.display = "block";
		div_subs_container.id = `subs-container-${i + 1}`;
		div_subs_container.appendChild(createSubRoute(subRouteItems));

		table.appendChild(tbody);
		subContainer.appendChild(table);
		subContainer.appendChild(div_subs_container);
		container.appendChild(subContainer);
		addfunctionToDisplayRouteItem(i + 1);
	}
}
function addfunctionToDisplayRouteItem(order) {
	var tr = document.getElementById(`display-tr-${order}`);
	let cont = document.getElementById(`subs-container-${order}`);

	tr.addEventListener("click", function () {
		let cont = document.getElementById(`subs-container-${order}`);
		cont.style.display == "block" ? (cont.style.display = "none") : (cont.style.display = "block");
	});
}

function createDisplayRouteItem(order, routeItem, stopRoutes) {
	let tr = document.createElement("tr");
	tr.style.backgroundColor = "#34b67a";
	tr.style.width = "100%";
	tr.style.height = "48px";
	tr.style.border = "2px solid white";
	tr.style.color = "white";
	tr.style.cursor = "pointer";
	tr.id = `display-tr-${order}`;

	let td_icon = document.createElement("td");
	td_icon.style.paddingLeft = "24px";
	td_icon.innerHTML = order;

	let td_routeName = document.createElement("td");
	td_routeName.innerHTML = routeItem.RouteName;

	//--walk

	let td_walk = document.createElement("td");
	let div_walk_1 = document.createElement("div");
	div_walk_1.style.display = "flex";
	div_walk_1.style.alignItems = "center";
	let div_walk_2 = document.createElement("div");
	div_walk_2.style.width = "36px";
	div_walk_2.style.height = "36px";
	div_walk_2.style.borderRadius = "50%";
	div_walk_2.style.backgroundColor = "white";
	div_walk_2.style.display = "flex";
	div_walk_2.style.justifyContent = "center";
	div_walk_2.style.alignItems = "center";
	let img_walk = document.createElement("img");
	img_walk.src = "../SetImg/ic-walk.png";
	let div_walk_3 = document.createElement("div");
	div_walk_3.style.padding = "0px 8px 0px 8px";
	div_walk_3.innerHTML = "-";

	td_walk.appendChild(div_walk_1);
	div_walk_1.appendChild(div_walk_2);
	div_walk_2.appendChild(img_walk);
	div_walk_1.appendChild(div_walk_3);

	//--car

	let td_car = document.createElement("td");
	let div_car_1 = document.createElement("div");
	div_car_1.style.display = "flex";
	div_car_1.style.alignItems = "center";
	let div_car_2 = document.createElement("div");
	div_car_2.style.width = "36px";
	div_car_2.style.height = "36px";
	div_car_2.style.borderRadius = "50%";
	div_car_2.style.backgroundColor = "white";
	div_car_2.style.display = "flex";
	div_car_2.style.justifyContent = "center";
	div_car_2.style.alignItems = "center";
	let img_car = document.createElement("img");
	img_car.src = "../SetImg/ic-car.png";
	let div_car_3 = document.createElement("div");
	div_car_3.style.padding = "0px 8px 0px 8px";
	div_car_3.innerHTML = "-";

	td_car.appendChild(div_car_1);
	div_car_1.appendChild(div_car_2);
	div_car_2.appendChild(img_car);
	div_car_1.appendChild(div_car_3);

	//--time
	let td_time = document.createElement("td");
	let div_time_1 = document.createElement("div");
	div_time_1.style.display = "flex";
	div_time_1.style.alignItems = "center";
	let div_time_2 = document.createElement("div");
	div_time_2.style.width = "36px";
	div_time_2.style.height = "36px";
	div_time_2.style.borderRadius = "50%";
	div_time_2.style.backgroundColor = "white";
	div_time_2.style.display = "flex";
	div_time_2.style.justifyContent = "center";
	div_time_2.style.alignItems = "center";
	let img_time = document.createElement("img");
	img_time.src = "../SetImg/ic-clock.png";
	let div_time_3 = document.createElement("div");
	div_time_3.style.padding = "0px 8px 0px 8px";
	div_time_3.innerHTML = "-";

	td_time.appendChild(div_time_1);
	div_time_1.appendChild(div_time_2);
	div_time_2.appendChild(img_time);
	div_time_1.appendChild(div_time_3);

	//--money

	let td_money = document.createElement("td");
	let div_money_1 = document.createElement("div");
	div_money_1.style.display = "flex";
	div_money_1.style.alignItems = "center";
	let div_money_2 = document.createElement("div");
	div_money_2.style.width = "36px";
	div_money_2.style.height = "36px";
	div_money_2.style.borderRadius = "50%";
	div_money_2.style.backgroundColor = "white";
	div_money_2.style.display = "flex";
	div_money_2.style.justifyContent = "center";
	div_money_2.style.alignItems = "center";
	let img_money = document.createElement("img");
	img_money.src = "../SetImg/ic-money.png";
	let div_money_3 = document.createElement("div");
	div_money_3.style.padding = "0px 8px 0px 8px";
	div_money_3.innerHTML = "-";

	td_money.appendChild(div_money_1);
	div_money_1.appendChild(div_money_2);
	div_money_2.appendChild(img_money);
	div_money_1.appendChild(div_money_3);

	//--option button
	let td_option = document.createElement("td");
	let div_option = document.createElement("div");
	div_option.style.display = "flex";
	div_option.style.justifyContent = "right";
	div_option.style.paddingRight = "6px";
	let btn_option = document.createElement("button");
	btn_option.textContent = "Xem bản đồ";
	btn_option.style.backgroundImage = "url(../SetImg/ic-view.png)";
	btn_option.style.backgroundRepeat = "no-repeat";
	btn_option.style.backgroundPosition = "8px";
	btn_option.style.padding = "0px 12px 0px 48px";
	btn_option.style.height = "36px";
	btn_option.style.border = "none";
	btn_option.style.backgroundColor = "white";
	btn_option.style.color = "black";
	btn_option.style.borderRadius = "4px";
	btn_option.onclick = (e) => {
		handleClickViewMapInDisplayRoute(e, stopRoutes);
		return false;
	};

	td_option.appendChild(div_option);
	div_option.appendChild(btn_option);

	//--append

	tr.appendChild(td_icon);
	tr.appendChild(td_routeName);
	tr.appendChild(td_walk);
	tr.appendChild(td_car);
	tr.appendChild(td_time);
	tr.appendChild(td_money);
	tr.appendChild(td_option);

	return tr;
}
function handleClickViewMapInDisplayRoute(e, stopRoutes) {
	e.stopPropagation();
	var stopRouteContainer = document.getElementById("display-stop-route-container");
	stopRouteContainer.innerHTML = null;
	var h4 = document.createElement("h4");
	h4.innerText = "Danh sách điểm dừng";
	document.getElementById("display-stop-route-title").innerHTML = null;
	document.getElementById("display-stop-route-title").appendChild(h4);

	var table = document.createElement("table");
	table.style.width = "100%";
	var tbody = document.createElement("tbody");
	table.appendChild(tbody);
	stopRouteContainer.appendChild(table);

	for (let i = 0; i < stopRoutes.length; i++) {
		let tr = document.createElement("tr");
		let td = document.createElement("td");
		let div_1 = document.createElement("div");
		div_1.style.height = "48px";
		div_1.style.border = "2px solid white";
		div_1.style.display = "flex";
		div_1.style.alignItems = "center";
		div_1.style.boxShadow = "0px 1px 3px rgba(0,0,0,0.4)";
		div_1.style.padding = "0px 8px 0px 8px";
		div_1.style.margin = "2px 4px 2px 4px";
		div_1.style.borderRadius = "4px";
		div_1.style.backgroundColor = "white";
		let div_2 = document.createElement("div");
		div_2.style.width = "40px";
		div_2.style.height = "40px";
		div_2.borderRadius = "50%";
		div_2.backgroundColor = "white";
		div_2.display = "flex";
		div_2.alignItems = "center";
		let img = document.createElement("img");
		img.src = "../SetImg/ic-busStop32.png";
		img.style.width = "30px";
		img.style.height = "36px";

		div_2.appendChild(img);
		div_1.appendChild(div_2);

		let span = document.createElement("span");
		span.innerText = stopRoutes[i].BusStopName;
		div_1.appendChild(span);
		td.appendChild(div_1);
		tr.appendChild(td);
		tbody.appendChild(tr);
	}
}
function clearDirection() {
	// if (directionsDisplay != null) {
	// 	directionsDisplay.setOptions({
	// 		suppressPolylines: true,
	// 	});
	// }
}
function calcRoutesRender(listPoint, typeMode) {
	let lengthList = listPoint.length;
	let start = listPoint[0];
	let midPoints = listPoint.slice(1, lengthList - 1);
	let end = listPoint[lengthList - 1];
	let travelMode = {};
	if (typeMode) {
		travelMode = {
			travelMode: typeMode,
		};
	}
	let request = {
		origin: start,
		destination: end,
		waypoints: midPoints,
		...travelMode,
	};
	directionsService.route(request, function (result, status) {
		if (status == "OK") {
			var directionsDisplay = new google.maps.DirectionsRenderer({
				suppressMarkers: true,
				map: map,
				polylineOptions: typeMode === "DRIVING" ? polylineDriving : polylineWark,
			});
			directionsDisplay.setDirections(result);
		} else {
			alert("Đã có lỗi xảy ra !! Vui lòng thử lại ");
		}
	});
}
function loadRouteToMap(startPoint, endPoint, list) {
	let routeItems = [];
	console.log(list);
	if (startPoint.id === 0 || (list && list[0].listBusStop[0].BusRoutesID !== startPoint.id)) {
		let routeItem = new Object();
		routeItem.isWalk = true;
		routeItem.travelMode = "WALKING";
		routeItem.guidText = "-";
		routeItem.startName = mapPoint;
		routeItem.listPoint = [{ location: { lat: startPoint.latitudes, lng: startPoint.longitudes } }];
		let busStop = list[0].listBusStop[0];
		routeItem.listPoint.push({ location: { lat: busStop.Latitude, lng: busStop.Longitude } });
		routeItem.endName = busStop.BusStopName;
		if (JSON.stringify(routeItem.listPoint[0]) !== JSON.stringify(routeItem.listPoint[1])) routeItems.push(routeItem);
	}
	routeItems = routeItems.concat(
		list.map((item) => {
			let routeItem = new Object();
			routeItem.isWalk = false;
			routeItem.guidText = item.route.RouteName;
			routeItem.travelMode = "DRIVING";
			routeItem.startName = item.listBusStop[0].BusStopName;
			routeItem.listPoint = item.listBusStop.map((busStop) => {
				return {
					location: {
						lat: busStop.Latitude,
						lng: busStop.Longitude,
					},
				};
			});
			if (list && list.length > 0) {
				let busStop = list[0].listBusStop[0];
				routeItem.listPoint.push({ location: { lat: busStop.Latitude, lng: busStop.Longitude } });
				routeItem.endName = item.listBusStop[item.listBusStop.length - 1].BusStopName;
			}
			return routeItem;
		})
	);

	let info = list[list.length - 1];
	let lastListBusStop = info.listBusStop;
	let lastItem = lastListBusStop[lastListBusStop.length - 1];

	if (endPoint.id === 0 || (lastItem !== endPoint.id && list)) {
		let routeItem = new Object();
		routeItem.isWalk = true;
		routeItem.guidText = "-";
		routeItem.startName = lastItem.BusStopName;
		routeItem.listPoint = [{ location: { lat: endPoint.latitudes, lng: endPoint.longitudes } }];
		let busStop = lastListBusStop[lastListBusStop.length - 1];
		routeItem.listPoint.push({ location: { lat: busStop.Latitude, lng: busStop.Longitude } });
		routeItem.endName = "-";
		if (JSON.stringify(routeItem.listPoint[0]) !== JSON.stringify(routeItem.listPoint[1])) routeItems.push(routeItem);
	}
	console.log(routeItems);
	return routeItems;
}

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
			renderMaker(data, false);
		},
		failure: function (response) {
			alert(response.d);
		},
		error: function (response) {
			alert(response.d);
		},
	});
}
function placeMarkerAndPanTo(latLng, map, img, typeShow, info, id) {
	let maker = new google.maps.Marker({
		position: latLng,
		map: map,
		icon: img,
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
	dataJson = $("input#hfData").val();
	if (dataJson != "") {
		let dataRoute = JSON.parse(dataJson);
		renderMaker(dataRoute, true);
	}
}
function getLocation(lat, lng) {
	let txtlng = document.getElementById("MainContent_txtLongitude");
	let txtlat = document.getElementById("MainContent_txtLatitude");
	txtlng.value = lng.toString();
	txtlat.value = lat.toString();
}

function onClickRouteItem(routeItemId) {
	var subItems = document.getElementById(`route-sub-item-${routeItemId}`);
	subItems.style.display = subItems.style.display === "block" ? "none" : "block";
	if (subItems.childNodes.length === 1) {
		subItems.append(createSubRoute(displaySubRouteData));
	}
}

function createSubRoute(array) {
	var table = document.createElement("table");
	table.style.width = "100%";
	table.style.borderCollapse = "separate";
	table.style.borderSpacing = "0 4px";

	var tbody = document.createElement("tbody");
	// var routeItem = {
	// 	isWalk: true,
	// 	routeNumber: 0,
	// 	guidText: "Đi bộ",
	// 	startName: "Điểm được chọn trên bản đồ",
	// 	endName: "Điểm kết thúc",
	// 	distanceLength: 8,
	// 	time: 45,
	// 	prices: 6000,
	// };
	array.map((routeItem) => {
		calcRoutesRender(routeItem.listPoint, routeItem.travelMode);
		tbody.appendChild(
			createSubRouteItem(
				routeItem.isWalk,
				routeItem.routeNumber ? routeItem.routeNumber : "-",
				routeItem.guidText ? routeItem.guidText : "-",
				routeItem.startName ? routeItem.startName : "-",
				routeItem.endName ? routeItem.endName : "-",
				routeItem.distanceLength ? routeItem.distanceLength : "-",
				routeItem.time ? routeItem.time : "-",
				routeItem.prices ? routeItem.prices : "-"
			)
		);
	});

	// routeItem.routeNumber = 45;
	// routeItem.isWalk = false;

	// tbody.appendChild(
	// 	createSubRouteItem(
	// 		routeItem.isWalk,
	// 		routeItem.routeNumber,
	// 		routeItem.guidText,
	// 		routeItem.startName,
	// 		routeItem.endName,
	// 		routeItem.distanceLength,
	// 		routeItem.time,
	// 		routeItem.prices
	// 	)
	// );

	table.appendChild(tbody);

	return table;
}

function createSubRouteItem(isWalk, routeNumber, guidText, startName, endName, distanceLength, time, prices) {
	var tr = document.createElement("tr");
	tr.style.backgroundColor = "white";
	tr.style.boxShadow = "0px 1px 3px rgba(0,0,0,0.4)";
	tr.style.width = "100%";
	tr.style.height = "48px";

	var td_icon = document.createElement("td");
	td_icon.style.padding = "0px 8px";
	if (isWalk === true) {
		var img = document.createElement("img");
		img.src = "../SetImg/ic-walk.png";
		img.alt = "ic-walk";
		td_icon.appendChild(img);
	} else if (isWalk === false) {
		let div = document.createElement("div");
		div.style.width = "32px";
		div.style.height = "32px";
		div.style.borderRadius = "50%";
		div.style.backgroundColor = "#34B67A";
		div.style.display = "flex";
		div.style.justifyContent = "center";
		div.style.alignItems = "center";
		div.style.color = "white";
		div.innerHTML = routeNumber;
		td_icon.appendChild(div);
	}

	var td_guidText = document.createElement("td");
	td_guidText.innerHTML = guidText;
	td_guidText.style.width = "32%";

	var td_start = document.createElement("td");
	var start_div_1 = document.createElement("div");
	start_div_1.style.fontSize = "12px";
	var start_div_2 = document.createElement("div");
	start_div_2.style.textAlign = "center";
	start_div_2.innerHTML = "Từ";
	var start_div_3 = document.createElement("div");
	start_div_3.style.color = "#34b67a";
	start_div_3.style.textAlign = "center";
	start_div_3.innerHTML = startName;
	start_div_2.appendChild(start_div_3);
	start_div_1.appendChild(start_div_2);
	td_start.appendChild(start_div_1);

	var td_end = document.createElement("td");
	var end_div_1 = document.createElement("div");
	end_div_1.style.fontSize = "12px";
	var end_div_2 = document.createElement("div");
	end_div_2.style.textAlign = "center";
	end_div_2.innerHTML = "Đến";
	var end_div_3 = document.createElement("div");
	end_div_3.style.color = "#34b67a";
	end_div_3.style.textAlign = "center";
	end_div_3.innerHTML = endName;
	end_div_2.appendChild(end_div_3);
	end_div_1.appendChild(end_div_2);
	td_end.appendChild(end_div_1);

	var td_distanceLenght = document.createElement("td");
	td_distanceLenght.innerHTML = `${distanceLength} km`;

	var td_time = document.createElement("td");
	td_time.innerHTML = `${time} phút`;

	var td_prices = document.createElement("td");
	td_prices.innerHTML = `${prices} đ`;

	//-- append
	tr.appendChild(td_icon);
	tr.appendChild(td_guidText);
	tr.appendChild(td_start);
	tr.appendChild(td_end);
	tr.appendChild(td_distanceLenght);
	tr.appendChild(td_time);
	tr.appendChild(td_prices);

	return tr;
}

/*  window.document.addEventListener('DOMContentLoaded', );*/
window.initMap = initMap;
