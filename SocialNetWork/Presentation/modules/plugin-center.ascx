<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="plugin-center.ascx.cs" Inherits="Presentation.modules.plugin_center" %>
<script>
    function scrollToDiv() {
        $('html, body').animate({ scrollTop: $(document).height() }, 2000);
        return false;
    }
</script>
<asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
    <ContentTemplate>
         <%=_Error %>
        <asp:ListView ID="ListViewAll" runat="server" DataKeyNames="ID_News" ItemPlaceholderID="lstViewAll" OnItemCommand="ListViewAll_ItemCommand" OnItemDataBound="ListViewAll_ItemDataBound">
            <ItemTemplate>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="timeline">
                            <h4 class="timeline-title">
                                <asp:Label ID="lb_lst_titile_vn" runat="server" Text='<%# Eval("Titile") %>'/>
                                <asp:Label ID="lbID" runat="server" Text='<%# Eval("ID_News") %>' Visible="False"/>
                                <input type="hidden" id="hiddenId" value='<%# Eval("ID_News") %>' runat="server" name="hiddenId" />
                            </h4>
                            <p><small class="text-muted"><i class="fa fa-clock-o"></i> Đăng vào lúc : <%# Eval("DateBegin","{0:dd-MM-yyyy}") %></small></p>
                        </div>
                        <div class="timeline-body">
                            <a class="imgfancy" href='<%# Eval("Img") %>'>
                                <img src='<%# Eval("Img") %>' class="img-responsive" style="width: 100%;height: 300px;"/>
                            </a>
                            <p>
                                <asp:Label ID="lb_lst_shortconent" runat="server" Text='<%# Eval("ShortContent") %>'/>
                            </p>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <asp:Button ID="btnLike" runat="server" CssClass="btn btn-danger btn-xs" CommandName="Like_lst" title="Thích" Text="Thích" />
                        <asp:Button ID="btnUnLike" runat="server" CssClass="btn btn-danger btn-xs" CommandName="Unlike_lst" title="Bỏ thích" Text="Bỏ thích" />
                        <asp:Button ID="btnShare" runat="server" CssClass="btn btn-danger btn-xs" CommandName="Share_lst" title="Chia sẻ" Text="Chia sẽ" />
                        <asp:Button ID="btnComment" runat="server" CssClass="btn btn-danger btn-xs" CommandName="Comment_lst" title="Bình luận" Text="Bình luận" />
                        <asp:Label ID="lb_lst_like" runat="server" Text='<%# Eval("Likes") %>'/> Lượt thích
                    </div>
                </div>
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
<asp:UpdateProgress ID="UpdateProgressViewMore" runat="server" AssociatedUpdatePanelID="UpdatePanelViewMore">
    <ProgressTemplate>
       <img src="../img/facebook_loading.gif"/>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelViewMore" runat="server">
    <ContentTemplate>
        <asp:Label ID="lbTotal" runat="server" Text="" Visible="False"/>
        <asp:Button runat="server" ID="btnViewMore" CssClass="btn btn-danger btn-xs btn-block" Text="Xem thêm" OnClick="btnViewMore_Click"/>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnViewMore" EventName="Click"/>
    </Triggers>
</asp:UpdatePanel>
<div style="height: 8px;"></div>
 <%--Process--%>
<asp:UpdateProgress ID="UpdateProgressNews" runat="server" AssociatedUpdatePanelID="UpdatePanelGrid">
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

<%--Popup--%>
<div class="modal fade modal-width" id="myModalComment" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header modal-header-background">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title modal-titile">Bình luận</h4>
            </div>
            <div class="modal-body modal-body-height" style="padding: 10px;">
                <asp:UpdatePanel ID="UpdatePanelComment" runat="server">
                    <ContentTemplate>
                        <div class="col-sm-6">
                            <div class="timeline-body">
                                <img src='<%# Eval("Img") %>' class="img-responsive" style="width: 100%;height: 300px;"/>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="timeline">
                                <h4 class="timeline-title">
                                    <asp:Label ID="lb_lst_titile" runat="server" Text=''/>
                                    <asp:Label ID="lbID_News" runat="server" Text='' Visible="False"/>
                                </h4>
                                <p><small class="text-muted"><i class="fa fa-clock-o"></i> Đăng vào lúc : <asp:Label ID="lbDateBegin" runat="server" Text=''/></small></p>
                            </div>
                            <p>
                                <asp:Label ID="lb_lst_shortconent" runat="server" Text=''/>
                            </p>
                            <hr/>
                            <div class="well well-sm">
                                <ul class="chat">
                                    <li class="left clearfix">
                                        <span class="chat-img pull-left">
                                            <img src="../img/unnamed.png" alt="User Avatar" class="img-circle" />
                                        </span>
                                        <div class="chat-body clearfix">
                                            <div class="header" style="color: #000080;font-weight: bold">
                                                User Comment
                                            </div>
                                            <p><small class="text-muted"><i class="fa fa-clock-o"></i> 11 hours ago via Twitter</small></p>
                                            <p>
                                                <asp:Label ID="lb_lst_comment" runat="server" Text=''/>
                                            </p>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            <div class="clr"></div>
            </div>
            <div class="modal-footer modal-footer-height">
                <button type="button" class="btn btn-danger btn-sm" style="margin-top: -20px;" data-dismiss="modal">Đóng lại</button>
            </div>
        </div>
    </div>
</div>
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header modal-header-background">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title modal-titile">Thông Báo</h4>
            </div>
            <div class="modal-body modal-body-height" style="padding: 10px;">
                    <asp:UpdatePanel ID="UpdatePanelControl" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lbMsg" runat="server" Text=""/>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            <div class="clr"></div>
            </div>
            <div class="modal-footer modal-footer-height">
                <button type="button" class="btn btn-danger btn-sm" style="margin-top: -20px;" data-dismiss="modal">Đóng lại</button>
            </div>
        </div>
    </div>
</div>
<%--End--%>