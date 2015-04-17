<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="plugin-follower.ascx.cs" Inherits="Presentation.modules.plugin_follower" %>
<div class="chat-panel panel panel-danger">
    <div class="panel-heading">
        Gợi ý theo dõi
    </div>
    <div class="panel-footer">
        <asp:UpdatePanel ID="UpdatePanelSearch" runat="server">
            <ContentTemplate>
                <asp:Panel ID="PanelSearchFollower" runat="server" DefaultButton="btnSearchFriend">
                    <div class="input-group">
                        <input id="txtSearchFriend" type="text" class="form-control input-sm search" title="Nhập vào tên có dấu hoặc không dấu để tìm kiếm" placeholder="Tìm kiếm" runat="server" />
                        <span class="input-group-btn">
                            <asp:LinkButton ID="btnSearchFriend" CssClass="btn btn-danger btn-sm search" runat="server" title="Tìm kiếm" OnClick="btnSearchFriend_Click"><i class="fa fa-search"></i></asp:LinkButton>
                        </span>
                    </div>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearchFriend" EventName="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="panel-body">
        <ul class="chat">
            <asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
                <ContentTemplate>
                    <asp:ListView ID="ListViewAll" runat="server" DataKeyNames="AccountID" ItemPlaceholderID="lstViewAll" OnItemCommand="ListViewAll_ItemCommand" OnItemDataBound="ListViewAll_ItemDataBound">
                        <ItemTemplate>
                             <li class='left clearfix'>
                                <span class='chat-img pull-left'>
                                    <asp:Image ID="lb_lst_Img" ImageUrl='<%# Eval("User_Image") %>' runat="server" CssClass="img-circle" Width="28px" Height="28px" />
                                    <asp:Label ID="lbID" runat="server" Text='<%# Eval("AccountID") %>' Visible="False"></asp:Label>
                                </span>
                                <div class='chat-body clearfix'>
                                    <div class='header'>
                                        <a class="link-name" href="/profice/<%# Eval("UserName") %>" data-popover="true" data-html=true 
                                            data-content='
                                                <asp:Button ID="btnFollow" runat="server" CssClass="btn btn-danger btn-xs" CommandName="_btnFollow" Text="Theo dõi" />
                                            '>
                                            <asp:Label ID="lb_lst_FullName" runat="server" Text='<%# Eval("FullName") %>'/>
                                        </a>
                                    </div>
                                </div>
                            </li>
                         </ItemTemplate>
                        <LayoutTemplate>
                            <asp:PlaceHolder runat="server" ID="lstViewAll"></asp:PlaceHolder>
                        </LayoutTemplate>
                    </asp:ListView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ListViewAll" EventName="ItemCommand"/>
                </Triggers>
            </asp:UpdatePanel>
        </ul>
        <div class="clearfix"></div>
    </div>
</div>
<%--Popup--%>
<div class="modal fade" id="myModalFollower" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header modal-header-background">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title modal-titile">Theo dõi</h4>
            </div>
            <div class="modal-body modal-body-height" style="padding: 10px;">
                <asp:UpdatePanel ID="UpdatePanelFollow" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbFullName" runat="server" Text="" Visible="False"/>
                        <div class="form-group">
                            <%=_ErrorFollower %>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            <div class="clr"></div>
            </div>
            <div class="modal-footer modal-footer-height">
                <button type="button" class="btn btn-danger btn-sm" style="margin-top: -15px;" data-dismiss="modal">Đóng lại</button>
            </div>
        </div>
    </div>
</div>
<%--End--%>

 <%--Process--%>
<asp:UpdateProgress ID="UpdateProgressSearch" runat="server" AssociatedUpdatePanelID="UpdatePanelSearch">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-main">
                    <img src="js/fancyBox/source/fancybox_loading.gif" style="padding: 10px;top:45%;left:50%;"/>
                    <span class="label label-danger">
                        Đang tải...
                    </span>  
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdateProgress ID="UpdateProgressFollow" runat="server" AssociatedUpdatePanelID="UpdatePanelGrid">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-main">
                    <img src="js/fancyBox/source/fancybox_loading.gif" style="padding: 10px;top:45%;left:50%;"/>
                    <span class="label label-danger">
                        Đang tải...
                    </span>  
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<%--End--%>
<script src="../js/extention.js"></script>
