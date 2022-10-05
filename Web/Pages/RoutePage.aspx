<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoutePage.aspx.cs" Inherits="Web.Pages.RoutePage" %>



<asp:Content ID="RoutePageHead" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="RoutePageMainContent" ContentPlaceHolderID="MainContent" runat="server">
 <div class="" style="margin-left: 48px; margin-right: 48px; margin-top: 24px;">
            <div class="row">
                <div class="col-sm-6">
                    <h4>Danh sách lộ trình: </h4>
                    <div runat="server" class="overflow-auto" style="margin-top: 24px; height: 900px">
                        <asp:GridView style="width: 1800px !important; max-width: 1800px !important" 
                            ID="GridViewRoute" 
                            CssClass="table table-bordered table-striped" 
                            runat="server" 
                            AutoGenerateSelectButton="true" 
                            OnSelectedIndexChanged="GridViewRoute_SelectedIndexChanged"
                            SelectedRowStyle-BackColor="Teal"
                            OnRowDataBound="GridViewRoute_RowDataBound"></asp:GridView>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="" style="margin-left: 0; margin-right: 0; margin-top: 48px">
                        <div class="form-group">
                            <div class="row">
                                <label>Mã lộ trình</label>
                                <div class="col-sm-10">
                                    <asp:TextBox style="width:100%; max-width:100%" CssClass="form-control" ReadOnly="true" runat="server" TextMode="SingleLine" ID="IDRoute" placeholder="Mã lộ trình" />
                                    <small class="form-text text-muted">Xác nhận lộ trình nào được cập nhật hay xóa, tăng tự động khi thêm.</small>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Button Text="Xóa" runat="server" Style="width: 100%; background-color: teal; color: white" ID="btnDelete" CssClass="btn" OnClick="ButtonDeleteRoute_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label>Tên lộ trình</label>
                            <asp:TextBox style="width:100%; max-width:100%" runat="server" CssClass="form-control" TextMode="SingleLine" ID="RouteName" placeholder="Tên lộ trình"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <label>Tên Tuyến</label>
                                    <asp:DropDownList style="width:100%; max-width:100%" CssClass="form-control" AutoPostBack="true" ID="dlIDBusRoutes" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <label>Tên Điểm bắt đầu</label>
                                    <asp:DropDownList style="width:100%; max-width:100%" CssClass="form-control" AutoPostBack="true" ID="dlIDStartPosition" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <label>Tên Điểm kết thúc</label>
                                    <asp:DropDownList style="width:100%; max-width:100%" CssClass="form-control" AutoPostBack="true" ID="dlIDEndPosition" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-6">
                                    <label>Số chuyến</label>
                                    <asp:TextBox style="width:100%; max-width:100%" type="number" class="form-control" placeholder="0" min="1" max="100" runat="server" ID="RouteAmount" />
                                </div>
                                <div class="col-sm-6">
                                    <label>Thời gian chuyến</label>
                                    <asp:TextBox style="width:100%; max-width:100%" type="number" class="form-control" placeholder="0" min="1" max="100" runat="server" ID="RouteTime" />
                                    <small class="form-text text-muted">Số phút hoàn thành một chuyến.</small>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-6">
                                    <label>Thời gian bắt đầu hoạt động</label>
                                    <asp:TextBox style="width:100%; max-width:100%" runat="server" ID="StartTime" CssClass="form-control" TextMode="Time" />
                                </div>
                                <div class="col-sm-6">
                                    <label>Thời gian kết thúc hoạt động</label>
                                    <asp:TextBox style="width:100%; max-width:100%" runat="server" ID="EndTime" CssClass="form-control" TextMode="Time"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label>Ngày áp dụng</label>
                            <asp:TextBox style="width:100%; max-width:100%" runat="server" ID="ApplicableDate" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Ngày hoạt động</label>
                            <asp:CheckBoxList style="width:100%; max-width:100%; height: 200px" runat="server" CssClass="form-control" ID="OperationDate">
                                        <asp:ListItem>Thứ 2</asp:ListItem>
                                        <asp:ListItem>Thứ 3</asp:ListItem>
                                        <asp:ListItem>Thứ 4</asp:ListItem>
                                        <asp:ListItem>Thứ 5</asp:ListItem>
                                        <asp:ListItem>Thứ 6</asp:ListItem>
                                        <asp:ListItem>Thứ 7</asp:ListItem>
                                        <asp:ListItem>Chủ nhật</asp:ListItem>
                            </asp:CheckBoxList>
                        </div>

                        <div class="form-group ">
                            <div class="row mt-3">
                                <div class="col-sm-4">
                                <asp:Button runat="server" Text="Cập nhật" CssClass="btn" Style="width: 100%; background-color: teal; color: white" OnClick="ButtonUpdateRoute_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button runat="server" Text="Thêm" CssClass="btn" Style="width: 100%; background-color: teal; color: white" OnClick="ButtonAddRoute_Click" />
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </div>


    </div>
    </asp:Content>

