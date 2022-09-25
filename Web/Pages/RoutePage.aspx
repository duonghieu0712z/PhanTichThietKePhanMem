<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StopRoutePage.aspx.cs" Inherits="Web.Pages.RoutePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý lộ trình</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous"/>
</head>
<body>
    <div class="" style="margin-left: 0; margin-right:0;margin-top:24px;">
     <form id="form1" runat="server">
         <div runat="server">
            <h2>Danh sách lộ trình: </h2><br />
            <asp:GridView ID="GridViewRoute" CssClass="table table-bordered table-striped" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridViewRoute_SelectedIndexChanged"></asp:GridView>
      </div>
      
    <div class="" style="margin-left: 48px; margin-right: 48px;">
        <div class="form-group">
        <div class="row">
            <label>Mã lộ trình</label>
            <div class="col-sm-10">
                <asp:TextBox CssClass="form-control" ReadOnly="true" runat="server" TextMode="SingleLine" ID="a" placeholder="Mã lộ trình"/>
                <small class="form-text text-muted">Xác nhận lộ trình nào được cập nhật hay xóa, tăng tự động khi thêm.</small>
            </div>
            <div class="col-sm-2">
                <asp:Button Text="Xóa" runat="server" style="width: 100%" CssClass="btn btn-primary"/> 
            </div>
        </div>
        </div>

        <div class="form-group">
            <label>Tên lộ trình</label>
            <asp:TextBox runat="server" CssClass="form-control" TextMode="SingleLine" ID="text" placeholder ="Tên lộ trình"></asp:TextBox>
        </div>

        <div class="form-group">
        <div class="row">
            <div class="col-sm-4">
                <label>Mã tuyến</label>
                <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="dlPageNumber" runat="server">
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
            <div class="col-sm-8">
                <label>Tên tuyến</label>
                <asp:TextBox CssClass="form-control" ReadOnly="true" runat="server" TextMode="SingleLine" ID="TextBox2" placeholder="Tên tuyến"/>
            </div>
        </div>
        </div>
    
        <div class="form-group">
        <div class="row">
            <div class="col-sm-4">
                <label>Mã Điểm bắt đầu</label>
                <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="DropDownList1" runat="server">
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
            <div class="col-sm-8">
                <label>Tên Điểm bắt đầu</label>
                <asp:TextBox CssClass="form-control" ReadOnly="true" runat="server" TextMode="SingleLine" ID="TextBox1" placeholder="Tên Điểm bắt đầu"/>
            </div>
        </div>
        </div>


        <div class="form-group">
        <div class="row">
            <div class="col-sm-4">
                <label>Mã Điểm kết thúc</label>
                <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="DropDownList2" runat="server">
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
            <div class="col-sm-8">
                <label>Tên Điểm kết thúc</label>
                <asp:TextBox CssClass="form-control" ReadOnly="true" runat="server" TextMode="SingleLine" ID="TextBox3" placeholder="Tên Điểm kết thúc"/>
            </div>
        </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-sm-6">
                    <label>Số chuyến</label>
                    <input type="number" class="form-control" placeholder="0" min="1", max="100"/>
                </div>
                <div class="col-sm-6">
                    <label>Thời gian chuyến</label>
                    <input type="number" class="form-control" placeholder="0" min="1", max="100"/>
                    <small class="form-text text-muted">Số phút hoàn thành một chuyến.</small>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-sm-6">
                    <label>Thời gian bắt đầu hoạt động</label>
                    <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control" TextMode="Time" />
                </div>
                <div class="col-sm-6">
                    <label>Thời gian kết thúc hoạt động</label>
                     <asp:TextBox runat="server" ID="TextBox5" CssClass="form-control" TextMode="Time"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="form-group">
            <label>Ngày áp dụng</label>
            <asp:TextBox runat="server" ID="TextBox6" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Ngày hoạt động</label>
            <div class="row">
                <div class="col-sm-12">
                    <asp:CheckBoxList runat="server" CssClass="form-control">
                        <asp:ListItem>Thứ 2</asp:ListItem>
                        <asp:ListItem>Thứ 3</asp:ListItem>
                        <asp:ListItem>Thứ 4</asp:ListItem>
                        <asp:ListItem>Thứ 5</asp:ListItem>
                        <asp:ListItem>Thứ 6</asp:ListItem>
                        <asp:ListItem>Thứ 7</asp:ListItem>
                        <asp:ListItem>Chủ nhật</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>

        <div class="form-group row mt-3">
            <div class="col-sm-4">
                <asp:Button runat="server" Text="Cập nhật" CssClass="btn btn-primary" style="width: 100%"/>
            </div>
            <div class="col-sm-3">
                <asp:Button runat="server" Text="Thêm"  CssClass="btn btn-primary" style="width: 100%"/>
            </div>
        </div>

    </div>
    
      </form>
    </div>
</body>
</html>


