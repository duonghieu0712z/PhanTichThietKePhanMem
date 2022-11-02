<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusStopPage.aspx.cs" Inherits="Web.Pages.BusStopPage" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: #F4F9F6; min-height: 100vh; box-shadow: 0px 6px 15px rgba(0,0,0,0.15); border-radius: 15px">

        <h2 style="text-align: center; color: #8D7F7F; font-weight: bold; padding-top: 20px" class="mt-3">QUẢN LÝ ĐIỂM DỪNG</h2>

        <div class="card-header">
            <div class="form-row d-flex justify-content-end">
                <div class="col-md-1">
                    <asp:DropDownList CssClass="custom-select" AutoPostBack="true" ID="dlPageNumber" runat="server" OnSelectedIndexChanged="dlPageNumber_SelectedIndexChanged">
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>100</asp:ListItem>
                        <asp:ListItem>150</asp:ListItem>
                        <asp:ListItem>200</asp:ListItem>
                        <asp:ListItem>250</asp:ListItem>
                        <asp:ListItem>300</asp:ListItem>
                        <asp:ListItem>350</asp:ListItem>
                        <asp:ListItem>400</asp:ListItem>
                        <asp:ListItem>450</asp:ListItem>
                        <asp:ListItem>500</asp:ListItem>
                        <asp:ListItem>1000</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="txtKeyword" placeholder="Keyword" runat="server">
                </div>
                <div class="cod-md-2">
                    <asp:Button ID="btTim" runat="server" CssClass="btn btn-primary" Text="Tìm" OnClick="btTim_Click" BackColor="#29CB7E" BorderColor="#29CB7E" />
                    <asp:Button ID="btThemMoi" CssClass="btn btn-primary " runat="server" Text="Thêm mới" OnClick="btThemMoi_Click" BackColor="#29CB7E" BorderColor="#29CB7E" />
                    <asp:Button ID="btXoa" runat="server" CssClass="btn btn-primary ml-3 mr-3" Text="Xóa" OnClientClick="return confirm('Bạn có muốn xóa không?')" OnClick="btXoa_Click" BackColor="#EF4B4B" BorderColor="#EF4B4B" />
                </div>
            </div>


        </div>
        <div class="card-body">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>

        <!-- Controls -->
        <asp:Panel ID="pnControls" runat="server" Visible="false">
            <div style="background: #ffffff; box-shadow: 0px 6px 15px rgba(0,0,0,0.15); border-radius: 15px; margin: 0 10px">
                <div style="padding: 10px;" class="form-group">
                    <div class="row mb-2">
                        <div class="col">
                            <input type="text" class="form-control" placeholder="ID" id="txtID" readonly runat="server">
                        </div>
                        <div class="col">
                            <input type="text" class="form-control" placeholder="Tên điểm dừng" id="txtName" runat="server">
                        </div>
                    </div>
                    <div class="form-floating mb-2">
                        <input type="text" class="form-control" id="txtStreet" placeholder="Đường\Phố" runat="server">
                    </div>
                    <div class="form-floating mb-2">
                        <input type="text" class="form-control" id="txtWard" placeholder="Xã\Phường" runat="server">
                    </div>
                    <div class="form-floating mb-2">
                        <input type="text" class="form-control" id="txtDistrict" placeholder="Quận\Huyện" runat="server">
                    </div>
                    <div class="form-group">
                        <div class="row mb-2">
                            <div class="col">
                                <input type="text" class="form-control" placeholder="Kinh độ" id="txtLongitude" runat="server">
                            </div>
                            <div class="col">
                                <input type="text" class="form-control" placeholder="Vĩ độ" id="txtLatitude" runat="server">
                            </div>
                        </div>
                        <div class="form-floating">
                            <textarea class="form-control" placeholder="Mô tả" id="txtDescription" runat="server" style="height: 100px"></textarea>

                        </div>

                    </div>
                </div>
            </div>
            <asp:Panel ID="pnMap" runat="server" CssClass="p-3 ">
            <div id="map" style="height: 400px; box-shadow: 0px 6px 15px rgba(0,0,0,0.15); border-radius: 15px;"></div>
        </asp:Panel>
            <div style="padding-bottom: 10px; display:flex; gap: 5px; justify-content: end;"  >
                <asp:Button ID="btXoaTrang" runat="server" Text="Làm mới" CssClass="btn btn-primary ml-4" OnClick="btXoaTrang_Click" BackColor="#29CB7E" BorderColor="#29CB7E" />
                <asp:Button ID="btLuu" runat="server" Text="Lưu" CssClass="btn btn-primary" OnClick="btLuu_Click" BackColor="#29CB7E" BorderColor="#29CB7E" />
                    
               
               </div>
                
        
        </asp:Panel>
        

      
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pnTable" runat="server" CssClass="pl-3 pr-3">
                    <div style="background-color: #ffffff; box-shadow: 0px 6px 15px rgba(0,0,0,0.15); border-radius: 15px;" class="table-responsive">
                        <table style="text-align: center" class="table table-bordered">
                            <thead>
                                <tr>
                                    <th>
                                        <input id="selectAll" type="checkbox"><label for='selectAll'></label></th>
                                    <th style="text-align: center">Edit</th>
                                    <th style="text-align: center">Tên điểm dừng</th>
                                    <th style="text-align: center">Số đường</th>
                                    <th style="text-align: center">Đường</th>
                                    <th style="text-align: center">Phường</th>
                                    <th style="text-align: center">Thành phố</th>
                                    <th style="text-align: center">Kinh độ</th>
                                    <th style="text-align: center">Vĩ độ</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in ls)
                                    { %>
                                <tr>
                                    <td style="width: 40px; text-align: center">
                                        <input name='cbID' value='<%=item.BusStopID %>' type='checkbox' /></td>
                                    <td style="width: 50px">
                                        <a style="text-align: center; background-color: #29CB7E" href="?idEdit=<%=item.BusStopID %>" class="btn btn-primary">Edit</a>
                                    </td>
                                    <td><%=item.BusStopName %></td>
                                    <td><%=item.BusStopDescription %></td>
                                    <td><%=item.Street %></td>
                                    <td><%=item.Wards %></td>
                                    <td><%=item.District %></td>
                                    <td><%=item.Longitude %></td>
                                    <td><%=item.Latitude %></td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>

                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <div class="card-footer text-right" style="margin-top: 10px;">
        <asp:Panel ID="pnPhanTrang" runat="server">
            <div class="form-row" style="display: flex; gap: 5px ; justify-content: center; ">
                <div class="col-auto">
                    <asp:Button ID="btTruoc" runat="server" Text="Trước" class="btn btn-dark" OnClick="btPhanTrang_Click" />
                </div>
                <div class="col-auto" >
                    <asp:HiddenField ID="hPageIndex" runat="server" />
                    <asp:HiddenField ID="hTotalRows" runat="server" />
                    <asp:HiddenField ID="hPageSize" runat="server" />
                    <asp:Panel ID="pnButton" runat="server" style="display: flex; gap: 2px;"></asp:Panel>

                </div>
                <div class="col-auto">
                    <asp:Button ID="btSau" runat="server" Text="Sau" class="btn  btn-dark" OnClick="btPhanTrang_Click" />
                </div>
            </div>
        </asp:Panel>
    </div>
    <script>
        $("#selectAll").click(function () {
            $("input[type=checkbox]").prop('checked', $(this).prop('checked'));

        });
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyALdDivjYtOHE2M63dHeuXKnYARJdSllSE&callback=initMap" defer></script>
     <script>  
         const center = { lat: 10.771119394974335, lng: 106.70050611220746 };
         let zoom = 15;
         var map;
         let marker = [];
         let busStop = [];
         let dataBusStop;
         let markerChoice;
         
       //  const imgCurrent = "/Access/iconBus.png";
        

         function initMap() {
             map = new google.maps.Map(document.getElementById("map"), {
                 zoom: zoom,
                 center: center,
             });

             /*google.maps.event.addDomListener(window, 'load', initMap);  */
             map.addListener("click", (e) => {
                 currentPoint = e.latLng;
                 if (markerChoice != null) {
                     markerChoice.setMap(null);
                     markerChoice = null;
                 }
                 console.log(currentPoint.lat());
                 console.log(e.latLng.toJSON());
                 markerChoice = placeMarkerAndPanTo(currentPoint, map, imgCurrent);
                 google.maps.event.addListener(markerChoice, "click", function (e) {
                     //showInfo(map, markerChoice, TypeChoice);
                     infoWindow = new google.maps.InfoWindow({
                         position: e.latLng,
                         anchor: markerChoice,
                         shouldfocus: false,
                         map: map
                     });
                     infoWindow.setContent(
                         JSON.stringify(e.latLng.toJSON(), null, 2)
                     );
                     infoWindow.open(map, markerChoice);

                     
                 });

                 // showInfo(map, markerChoice, TypeChoice);
                 getLocation(currentPoint.lat(), currentPoint.lng());
                 // Create a new InfoWindow.
                 
             });
         }

         
         function placeMarkerAndPanTo(latLng, map, img, typeShow, info, id) {
             let maker = new google.maps.Marker({
                 position: latLng,
                 map: map,
                 
             });
             map.panTo(latLng);
                 google.maps.event.addListener(maker, "click", function (e) {
                   //  showInfo(map, maker, typeShow, info);
                    
                 });
             
             return maker;
         }

         function getLocation(lat, lng) {
             
             let txtlng = document.getElementById("MainContent_txtLongitude");
             let txtlat = document.getElementById("MainContent_txtLatitude");
             console.log(txtlng);
             txtlng.value = lng.toString();
             txtlat.value = lat.toString();
         }
         window.initMap = initMap;

     </script>


</asp:Content>
