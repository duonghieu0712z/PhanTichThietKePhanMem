<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocumentClientUI.aspx.cs" Inherits="Web.Pages.DocumentClientUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link href="../CSS/styles.css" rel="stylesheet" type="text/css" />
    <asp:Panel ID="Panel1" runat="server">
    
        <asp:Label ID="Label1" runat="server" Text="Tra cứu văn bản"  style="margin-left:20px; font-family:'Times New Roman', Times, serif;font-weight:bold;font-size:35px;" BorderColor="White" ForeColor="#38B47C"></asp:Label>
        <br />
    
            <asp:DropDownList style="margin-left:20px; margin-top:10px; width: 100px; height:30px; border-radius:5px;" CssClass="custom-select" AutoPostBack="true" ID="dlPageNumber" runat="server"  BackColor="#38b47c" ForeColor="White" OnSelectedIndexChanged="dlPageNumber_SelectedIndexChanged">
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
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList  style="width: 250px; height:30px; border-radius:5px;" ID="DdrView" runat="server" server="" Width="225px" OnSelectedIndexChanged="DdrView_SelectedIndexChanged" BackColor="#38B47C" CssClass="custom-select" ForeColor="White" Height="50px">
                   <asp:ListItem>Xem tất cả văn bản</asp:ListItem>
                   <asp:ListItem>Xem văn bản theo thể loại</asp:ListItem>
        </asp:DropDownList>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label style="font-family:'Times New Roman', Times, serif;font-weight:bold;font-size:20px;" ID="Label2" runat="server" Text="Label" BorderColor="White" ForeColor="#38B47C"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList  style="width: 100px; height:30px; border-radius:5px;" ID="DdrDocumentType" runat="server" Width="216px" OnSelectedIndexChanged="DdrDocumentType_SelectedIndexChanged" BackColor="#38B47C" CssClass="custom-select" ForeColor="White">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="pnTable" runat="server">
                   <table class="table">
                    <thead style="font-family:'Times New Roman';font-size:20px; color:#38B47C">
                      <tr>
                        <th>Tiêu đề</th>
                        <th>Mô tả</th>
                        <th>Đường dẫn</th>
                      </tr>
                    </thead>
                    <tbody style="font-family:'Times New Roman', Times, serif; font-size:18px;">
                      <%  foreach (var item in ls)
                                        { %>
                                    <tr>
                                        <td style="width: 200px"><a style="text-align: center; color:#18978F;" href="?idLink=<%=item.ID %>"><%=item.Title %></a></td>
                                        <td><%=item.Content %></td>
                                         <td> <a style="margin-left:30px; text-align: center; color:#18978F;" href="?idLink=<%=item.ID %>">Tải</a></td>
                                    </tr>
                                    <% } %>
                    </tbody>
                  </table>
                          </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>

    </asp:Panel>

       <div class="card-footer" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: small; font-weight: 600; font-style: normal; background-color: #FFFFFF; color: #000000">
            <asp:Panel ID="pnPhanTrang" runat="server">
                <div class="form-row">
                    <div class="col-auto">
                        <asp:Button style="margin-left:20px" ID="btTruoc" runat="server" BackColor="#48b47c" class="btn btn-dark"  OnClick="btPhanTrang_Click" ForeColor="White" Text="Trước" />
                        &nbsp;&nbsp;
                       
                    </div>
                    <div class="col-auto" style="margin-left:20px;margin-top: 10px; margin-bottom:10px;">
                       
                        <asp:HiddenField ID="hPageIndex" runat="server" />
                       
                        <asp:HiddenField ID="hTotalRows" runat="server" />
                  
                        <asp:HiddenField ID="hPageSize" runat="server" />
                        <asp:Panel ID="pnButton" runat="server">&nbsp;</asp:Panel>

                    </div>
                    <div class="col-auto">
                         <asp:Button style="margin-left:20px" ID="btSau" runat="server" BackColor="#48b47c" class="btn  btn-dark"  OnClick="btPhanTrang_Click" ForeColor="White" Text="Sau" />
                    </div>
                </div>
            </asp:Panel>
        </div>

</asp:Content>

