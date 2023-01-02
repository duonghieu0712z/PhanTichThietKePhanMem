<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocumentUI.aspx.cs" Inherits="DocumentWebDemo.pages.DocumentUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h2 style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: xx-large; background-color: #FFFFFF; font-weight: bold; color: #38b47c;">Quản lý văn bản</h2>
    <div class="card">
        <div class="card-header">
            <div class="form-row">
                <div class="col-md-1">
                    <asp:DropDownList style="margin-left:-10px;width: 100px; height:30px; border-radius:5px;" CssClass="custom-select" AutoPostBack="true" ID="dlPageNumber" runat="server" OnSelectedIndexChanged="dlPageNumber_SelectedIndexChanged" BackColor="#38b47c" ForeColor="White">
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
                         <input style="width:250px;border-radius:10px; margin-left:30px; font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: medium; font-weight: 100; font-style: italic; font-variant: normal; text-transform: none; background-color: #FFFFFF; color: #40b47c;" type="text" class="form-control" id="txtKeyword" placeholder="Nhập từ khoá bạn muốn tìm..." runat="server">
                </div>
                <div class="cod-md-2">
                    <asp:Button  style="margin-left:110px;" ID="btTim" runat="server" CssClass="btn btn-primary" Text="Tìm" OnClick="btTim_Click" BackColor="#40B47C" />
                </div>
                &nbsp;
                <div class="cod-md-2">
                    &nbsp;<asp:Button ID="btThemMoi" CssClass="btn btn-primary" runat="server" Text="Thêm mới"  OnClick="btThemMoi_Click"  BackColor="#40B47C" />
                    <asp:Button  BackColor="#CC3300" ID="btXoa" runat="server" CssClass="btn btn-primary" Text="Xóa" OnClientClick="return confirm('Bạn có muốn xóa không?')" OnClick="btXoa_Click" />
                </div>
                <div class="cod-md-2">
                    &nbsp;</div>
            </div>
        </div>
        <div class="card-body">
            <asp:Label style="color:orange" ID="Label1" runat="server" Text=""></asp:Label>

            <!-- Controls -->
            <asp:Panel ID="pnControls" runat="server" Visible="false">
              <asp:Label ID="LbTitleh2" style="color:#40b47c; font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: 25px;" runat="server" Text="Label"></asp:Label>

                <div class="form-group">
                    
                          <input style="width:400px;" type="text" class="form-control" id="txtID" readonly runat="server" placeholder="Mã văn bản">
                     
                                 <input style="width:400px;margin-top:10px;" type="text" class="form-control" id="txtTitle" runat="server" placeholder="Tiêu đề văn bản">
                   
                       
                                   
                                 <asp:FileUpload ID="FilePath" style="margin-top:10px" runat="server" Width="423px" />

                            <asp:DropDownList style="width:400px;height:30px;margin-top:10px;border-radius:10px;" ID="drDocumentType" CssClass="custom-select mr-sm-2" runat="server"></asp:DropDownList>
                   

                            <input style="width:400px;margin-top:10px;" type="text" class="form-control" id="txtContent" runat="server" placeholder="Mô tả văn bản">

              
                </div>



                <div class="form-group">
                    <asp:Button ID="btXoaTrang" runat="server" Text="Xóa trắng" CssClass="btn btn-primary" OnClick="btXoaTrang_Click" BackColor="#40B47C" />
                    <asp:Button ID="btLuu" runat="server" Text="Lưu" CssClass="btn btn-primary" OnClick="btLuu_Click" BackColor="#40B47C" />
                    <asp:Button ID="btThoat" runat="server" Text="Thoát" CssClass="btn btn-primary" OnClick="btThoat_Click" BackColor="#40B47C" />
                </div>
            </asp:Panel>

            <!-- Tables -->
            <%--<asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>--%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="pnTable" runat="server">
                        <div class="table-responsive">
                            <table class="table table-bordered">
                                <thead>
                                    <tr>
                                       
                               
                                      
                                        <th style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: bold; background-color: #40b47c; color: #FFFFFF; margin: auto">Tiêu đề</th>
                                        <th style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: bold; background-color: #40b47c; color: #FFFFFF; margin: auto">Mô tả</th>
                                        <th style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: bold; background-color: #40b47c; color: #FFFFFF; margin: auto">Đường dẫn</th>
                                        <th style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: bold; background-color: #40b47c; color: #FFFFFF; margin: auto">Mã thể loại</th>
                                        <th style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: bold; background-color: #40b47c; color: #FFFFFF; margin: auto">Chỉnh sửa</th>
                                         <th style="text-align:center; font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: bold; background-color: #40b47c; color: #FFFFFF;">
                                            <input id="selectAll" type="checkbox"><label for='selectAll'></label></th>
                                        </tr>
                                       
                                </thead>
                                <tbody>
                                    <%  foreach (var item in ls)
                                        { %>
                                    <tr>
                                        
                                        <td style="width: 100px"><%=item.Title %></td>
                                        <td><%=item.Content %></td>
                                         <td> <a style="text-align: center" href="?idLink=<%=item.ID %>">Path</a></td>
                                        <td style="width:200px"><%=item.DocumentTypeID %></td>
                                           <td style="width: 100px">
                                            <a style="text-align: center" href="?idEdit=<%=item.ID %>" class="btn btn-warning">Sửa</a>
                                        </td>
                                        <td style="width: 40px; text-align: center">
                                            <input name='cbID' value='<%=item.ID %>' type='checkbox' /></td>
                                     
                                    </tr>
                                    <% } %>
                                </tbody>
                            </table>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <div class="card-footer" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: small; font-weight: 600; font-style: normal; background-color: #FFFFFF; color: #000000">
            <asp:Panel ID="pnPhanTrang" runat="server">
                <div class="form-row">
                    <div class="col-auto">
                        <asp:Button ID="btTruoc" runat="server" BackColor="#48b47c" class="btn btn-dark" ForeColor="White" OnClick="btPhanTrang_Click" Text="Trước" />
                        &nbsp;&nbsp;
                       
                    </div>
                    <div class="col-auto" style="margin-top: 10px; margin-bottom:10px;">
                       
                        <asp:HiddenField ID="hPageIndex" runat="server" OnValueChanged="hPageIndex_ValueChanged" />
                       
                        <asp:HiddenField ID="hTotalRows" runat="server" />
                  
                        <asp:HiddenField ID="hPageSize" runat="server" />
                        <asp:Panel ID="pnButton" runat="server">&nbsp;</asp:Panel>

                    </div>
                    <div class="col-auto">
                         <asp:Button ID="btSau" runat="server" BackColor="#48b47c" class="btn  btn-dark" ForeColor="White" OnClick="btPhanTrang_Click" Text="Sau" />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>

    <script>
        $("#selectAll").click(function () {
            $("input[type=checkbox]").prop('checked', $(this).prop('checked'));

        });
    </script>


</asp:Content>


