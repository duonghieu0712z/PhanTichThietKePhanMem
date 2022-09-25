<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StopRoutePage.aspx.cs" Inherits="Web.Pages.StopRoutePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý lộ trình - điểm dừng</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous"/>
</head>
<body>
    <div class="" style="margin-left: 48px; margin-right:48px;margin-top:24px;">
     <form id="form1" runat="server">
      <div class="row">
        <div class="col-sm">
          <div runat="server">
                <h4>Danh sách lộ trình - điểm dừng: </h4><br />
                <asp:GridView CssClass="table table-bordered table-striped" ID="GridViewStopRoute" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridViewStopRoute_SelectedIndexChanged"></asp:GridView>
            </div>
        </div>
        <div class="col-sm" style="margin-top: 52px">

              <div class="form-group">
                <asp:Label runat="server">Mã Lộ trình - điểm dừng</asp:Label><br />
                <div class="row">
                    <div class="col-sm-10">
                        <asp:TextBox type="text" class="form-control" runat="server" id="StopRouteIDStopRoute" aria-describedby="stopRouteIDHelp" ReadOnly="true" placeholder="Mã lộ trình - điểm dừng"/>
                        <small id="stopRouteIDHelp" class="form-text text-muted">Xác nhận lộ trình - điểm dừng nào được cập nhật hay xóa, tăng tự động khi thêm.</small>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button runat="server" CssClass="btn btn-primary" style="width: 100%" text="Xóa"/>
                    </div>
                </div>
              </div>

            <div class="row">
                <div class="col-sm-4">
                    <div class="form-group">
                        <asp:Label runat="server">Mã Lộ trình</asp:Label>
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
                </div>
                <div class="col-sm-8">
                        <asp:Label runat="server">Tên lộ trình</asp:Label>
                        <asp:TextBox runat="server" ID="StopRouteIDRoute" CssClass="form-control" ReadOnly="true" placeholder="Tên lộ trình"></asp:TextBox>
                </div>
            </div>


            <div class="row">
                <div class="col-sm-4">
                    <div class="form-group">
                        <asp:Label runat="server">Mã vị trí cuối</asp:Label>
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
                </div>
                <div class="col-sm-8">
                        <asp:Label runat="server">Tên vị trí cuối</asp:Label>
                        <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" ReadOnly="true" placeholder="Tên vị trí cuối"></asp:TextBox>
                </div>
            </div>



            <div class="form-group">
                <label runat="server">Số thứ tự</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="StopRouteOrder" TextMode="SingleLine" placeholder="Số thứ tự" ></asp:TextBox>
                <small id="stopRouteOrderIDHelp" class="form-text text-muted">Số thứ tự của điểm dừng trong lộ trình.</small>
            </div>

            <div class="row mt-4">
                <div class="col-sm-6">
                    <asp:Button CssClass="btn btn-primary" style="width:100%" runat="server" text="Sửa"/>
                </div>
                <div class="col-sm-6">
                    <asp:Button CssClass="btn btn-primary" style="width:100%" runat="server" text="Thêm"/>
                </div>
            </div>
        </div>
      </div>
    </form>
</div>
    <script type="text/javascript">
    </script>
</body>
</html>

