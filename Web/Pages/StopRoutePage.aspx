<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StopRoutePage.aspx.cs" Inherits="Web.Pages.StopRoutePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý lộ trình - điểm dừng</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous" />
</head>
<body>
    <div class="" style="margin-left: 48px; margin-right:48px;margin-top:24px;">
     <form id="form1" runat="server">
      <div class="row">
        <div class="col-sm">
        <h4>Danh sách lộ trình - điểm dừng: </h4>
          <div runat="server" class="overflow-auto">
                <asp:GridView CssClass="table table-bordered table-striped" 
                    ID="GridViewStopRoute" 
                    runat="server" 
                    AutoGenerateSelectButton="true" 
                    OnSelectedIndexChanged="GridViewStopRoute_SelectedIndexChanged"
                    SelectedRowStyle-BackColor="Gray"></asp:GridView>
            </div>
        </div>
        <div class="col-sm" style="margin-top: 24px">
              <div class="form-group">
                <asp:Label runat="server">Mã Lộ trình - điểm dừng</asp:Label>
                <div class="row">
                    <div class="col-sm-10">
                        <asp:TextBox type="text" class="form-control" runat="server" id="IDStopRoute" aria-describedby="stopRouteIDHelp" ReadOnly="true" placeholder="Mã lộ trình - điểm dừng"/>
                        <small id="stopRouteIDHelp" class="form-text text-muted">Xác nhận lộ trình - điểm dừng nào được cập nhật hay xóa, tăng tự động khi thêm.</small>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button runat="server" CssClass="btn btn-primary" ID="btnDeleteStopRoute" style="width: 100%" text="Xóa" OnClick="ButtonDeleteStopRoute_Click"/>
                    </div>
                </div>
                <div class="col-sm" style="margin-top: 0">

            <div class="row">
                <div class="col-sm-12">
                    <div class="form-group">
                        <asp:Label runat="server">Tên Lộ trình</asp:Label>
                        <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="dlRouteID" runat="server">
                        </asp:DropDownList>
                  </div>
                </div>
            </div>


            <div class="row">
                <div class="col-sm-12">
                    <div class="form-group">
                        <asp:Label runat="server">Tên vị trí cuối</asp:Label>
                        <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="dlEndPositionID" runat="server">
                        </asp:DropDownList>
                  </div>
                </div>
            </div>



            <div class="form-group">
                <label runat="server">Số thứ tự</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="Order" type="number" min="1" max="1000" TextMode="SingleLine" placeholder="Số thứ tự" ></asp:TextBox>
                <small id="stopRouteOrderIDHelp" class="form-text text-muted">Số thứ tự của điểm dừng trong lộ trình.</small>
            </div>

            <div class="row mt-4">
                <div class="col-sm-6">
                    <asp:Button CssClass="btn btn-primary" style="width:100%" runat="server" text="Cập nhật" ID="btnUpdate" OnClick="ButtonUpdateStopRoute_Click"/>
                </div>
                <div class="col-sm-6">
                    <asp:Button CssClass="btn btn-primary" style="width:100%" runat="server" text="Thêm" ID="btnAdd" OnClick="ButtonAddStopRoute_Click"/>
                </div>
            </div>
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
