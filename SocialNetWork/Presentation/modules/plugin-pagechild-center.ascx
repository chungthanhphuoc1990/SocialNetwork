<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="plugin-pagechild-center.ascx.cs" Inherits="Presentation.modules.plugin_pagechild_center" %>
<div class="col-sm-4">
    <div class="well">
        <div class="alert alert-success alert-dismissable">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. <a href="#" class="alert-link">Alert Link</a>.
        </div>
    </div>
    <ul class="list-group">
        <li class="list-group-item">
        <span class="badge">14</span>
        Cras justo odio
        </li>
        <li class="list-group-item">
        <span class="badge">2</span>
        Dapibus ac facilisis in
        </li>
        <li class="list-group-item">
        <span class="badge">1</span>
        Morbi leo risus
        </li>
    </ul>
    <%--<div class='panel panel-danger'>
        <div class='panel-heading'>
            <h3 class='panel-title'>BẠN BÈ (0) </h3>
        </div>
        <div class='panel-body' style='margin: 0 0 0 0;padding: 11px 0 12px 0;text-align: center'>
            <div class="col-md-4" style="width: 103px">
                <img src='../Upload/piano.jpg' style='width: 103px;height: 103px;border: 2px solid #f2dede' class='img-rounded'/>
            </div>
            <div class="col-md-4" style="width: 103px">
                <img src='../Upload/piano.jpg' style='width: 103px;height: 103px;border: 2px solid #f2dede' class='img-rounded'/>
            </div>
            <div class="col-md-4" style="width: 103px">
                <img src='../Upload/piano.jpg' style='width: 103px;height: 103px;border: 2px solid #f2dede' class='img-rounded'/>
            </div>
        </div>
    </div>--%>
    <%=_htmlGetUserFollower %>
    <div class="panel panel-danger">
        <div class="panel-heading">
        <h3 class="panel-title">ALBUM ẢNH (0) </h3>
        </div>
        <div class="panel-body" style="margin: 0 0 0 0;text-align: center">
            <table class="table-responsive" style="border:none;text-align: center;width: 100%;margin: 0 0 0 0;padding: 0 0 0 0">
                <tr>
                    <td style="text-align: center;vertical-align: middle;">
                        <img src="../Upload/piano.jpg" style="width: 103px;height: 103px;border: 2px solid #f2dede" class="img-rounded"/>
                    </td>
                    <td style="text-align: center;vertical-align: middle;">
                        <img src="../Upload/piano.jpg" style="width: 103px;height: 103px;border: 2px solid #f2dede" class="img-rounded"/>
                    </td>
                    <td style="text-align: center;vertical-align: middle;">
                        <img src="../Upload/piano.jpg" style="width: 103px;height: 103px;border: 2px solid #f2dede" class="img-rounded"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<div class="col-sm-8">
    <asp:UpdatePanel ID="UpdatePanelbtnSendMessageClick" runat="server">
         <ContentTemplate>
             <asp:Button ID="btnSendMessageClick" Visible="False" style="margin-bottom: 10px;" CssClass="btn btn-danger btn-sm btn-block" runat="server" Text="Gửi tin nhắn" OnClick="btnSendMessageClick_Click" />
         </ContentTemplate>
         <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSendMessageClick" EventName="Click"/>
        </Triggers>
     </asp:UpdatePanel>

    <div class="panel panel-danger" runat="server" ID="PostStatusPanel">
        <div class="panel-heading">
            <ul class="nav nav-tabs">
                <li class="active">
                    <a href="#Status-pills" data-toggle="tab">
                        <span class="glyphicon glyphicon-pencil"></span> Trạng thái
                    </a>
                </li>
                <li>
                    <a href="#Album-pills" data-toggle="tab">
                        <span class="glyphicon glyphicon-picture"></span> Ảnh video
                    </a>
                </li>
            </ul>
        </div>
        <div class="panel-body">
            <asp:Label ID="lbUserMain" runat="server" Text="" Visible="False"></asp:Label>
            <div id="myTabContent" class="tab-content">
            <div class="tab-pane fade in active" id="Status-pills">
                <asp:UpdatePanel ID="UpdatePanelContentMain" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbIDUser" runat="server" Text="" Visible="False"></asp:Label>
                        <div class="form-group">
                            <input type="text" class="form-control" runat="server" ID="txTitilePost" placeholder="Bạn đang nghĩ gì"/>
                        </div>
                        <div class="form-group">
                            <textarea class="form-control" rows="3" runat="server" ID="txtContentPost" placeholder="Nội dung của bạn"></textarea>
                        </div>
                        <div class="form-group">
                            <%=_ErrorPost %>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="tab-pane fade" id="Album-pills">
                <asp:Button ID="btnUpload" runat="server" Text="Thêm ảnh/Vieo" CssClass="btn btn-default" />
                <asp:Button ID="Button1" runat="server" Text="Tạo Album" CssClass="btn btn-default" />
            </div>
        </div>
        </div>
        <div class="panel-footer">
            <div class="col-md-8">
                <asp:LinkButton ID="btnAddPhoto" runat="server" CssClass="btn btn-default btn-sm search" title="Thêm ảnh">
                    <span class="glyphicon glyphicon-camera"></span>
                </asp:LinkButton>
                <asp:LinkButton ID="btnTag" runat="server" CssClass="btn btn-default btn-sm search" title="Gắn thẻ mọi người trong bài viết của bạn">
                    <span class="glyphicon glyphicon-tag"></span>
                </asp:LinkButton>
            </div>
            <div class="col-md-4" style="text-align: right">
                 <asp:UpdatePanel ID="UpdatePanelContentFooter" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="drChoose" runat="server" AppendDataBoundItems="True" CssClass="btn btn-default btn-sm">
                            <asp:ListItem Value="1">Mọi người</asp:ListItem>
                            <asp:ListItem Value="2">Bạn bè</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnPost" runat="server" CssClass="btn btn-danger btn-sm" Text="Đăng" OnClick="btnPost_Click" />
                     </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"/>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div class="clr"></div>
        </div>
    </div>
    
    <asp:UpdatePanel ID="UpdatePanelWallFollower" runat="server">
        <ContentTemplate>
            <asp:ListView ID="ListViewWallFollwer" runat="server" DataKeyNames="AccountID1" ItemPlaceholderID="lstViewWallFollwer" OnItemCommand="ListViewWallFollwer_ItemCommand" OnItemDataBound="ListViewWallFollwer_ItemDataBound">
                <ItemTemplate>
                        <asp:Label ID="lbFollower" runat="server" Text='<%# Eval("AccountID2") %>' Visible="False"/>
                        <asp:ListView ID="ListViewSubWallFollower" runat="server" OnItemCommand="ListViewSubWallFollower_ItemCommand" OnItemDataBound="ListViewSubWallFollower_ItemDataBound">
                            <ItemTemplate>
                                <div class="panel panel-default" runat="server" ID="BodyWallFollower">
                                    <div class="panel-body">
                                        <div class="timeline">
                                            <ul class="chat">
                                                <li class='left clearfix'>
                                                    <span class='chat-img pull-left'>
                                                        <img src='<%# Eval("User_Image") %>' style="width: 40px;height: 40px;" runat="server" ID="imgAvatarPost" class="img-rounded"/>
                                                    </span>
                                                    <div class='chat-body clearfix'>
                                                        <div class='header'>
                                                            <a href='/profice/<%# Eval("UserName") %>' style="font-weight: 600;color: #000000">
                                                                <asp:Label ID="lb_lst_user_post" runat="server" Text='<%# Eval("FullName") %>'/>
                                                                <input type="hidden" id="hiddenId" value='<%# Eval("Wall_ID") %>' runat="server" name="hiddenId" />
                                                                <asp:Label ID="lb_lst_account_ID" runat="server" Visible="False" Text='<%# Eval("AccountID") %>'/>
                                                            </a>
                                                        </div>
                                                        <small class="text-muted">
                                                            <i class="fa fa-clock-o"></i> <asp:Label ID="lb_lst_datebegntext" runat="server" Text="Đăng vào lúc :"/> <asp:Label ID="lb_lst_datebegin" runat="server" Text='<%# Eval("DateBegin","{0:dd-MM-yyyy}") %>'/> | 
                                                            <i class="fa fa-clock-o" runat="server" ID="iconDateUpdate" Visible="False"/> <asp:Label ID="lb_lst_dateupdatetext" runat="server" Text="Thay đổi vào lúc :" Visible="False"/> <asp:Label ID="lb_lst_dateupdate" Visible="False" runat="server" Text='<%# Eval("DateUpdate","{0:dd-MM-yyyy}") %>'/>
                                                        </small>
                                                    </div>
                                                </li>
                                            </ul>
                                            <p style="font-weight: bold">
                                                <asp:Label ID="lb_lst_titileFollower" runat="server" Text='<%# Eval("Wall_Titile") %>'/>
                                            </p>
                                    </div>
                                        <div class="timeline-body">
                                            <p style="text-align: justify">
                                                <asp:Label ID="lb_lst_ContentFollower" runat="server" Text='<%# Eval("Wall_Content") %>'/>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Button ID="btnLike" runat="server" CssClass="btn btn-danger btn-xs search" CommandName="Like_lst" title="Thích" Text="Thích" />
                                        <asp:Button ID="btnUnLike" runat="server" CssClass="btn btn-danger btn-xs search" CommandName="Unlike_lst" title="Bỏ thích" Text="Bỏ thích" />
                                        <asp:Button ID="btnShare" runat="server" CssClass="btn btn-danger btn-xs search" CommandName="Share_lst" title="Chia sẻ" Text="Chia sẻ" />
                                        <asp:Label ID="lb_lst_like" runat="server" Text='<%# Eval("LikeCount") %>'/> Lượt thích
                                    </div>
                                 </div>
                            </ItemTemplate>
                        </asp:ListView>
                </ItemTemplate>
            </asp:ListView>
         </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ListViewWallFollwer" EventName="ItemCommand"/>
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
        <ContentTemplate>
            <%=_Error %>
            <asp:ListView ID="ListViewAll" runat="server" DataKeyNames="Wall_ID" ItemPlaceholderID="lstViewAll" OnItemCommand="ListViewAll_ItemCommand" OnItemDataBound="ListViewAll_ItemDataBound">
                <ItemTemplate>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="timeline">
                                <ul class="chat">
                                    <li class='left clearfix'>
                                        <span class='chat-img pull-left'>
                                            <img src='<%# Eval("User_Image") %>' style="width: 40px;height: 40px;" runat="server" ID="imgAvatarPost" class="img-rounded"/>
                                        </span>
                                        <div class='chat-body clearfix'>
                                            <div class='header'>
                                                <a href='/profice/<%# Eval("UserName") %>' style="font-weight: 600;color: #000000">
                                                    <asp:Label ID="lb_lst_user_post" runat="server" Text='<%# Eval("FullName") %>'/>
                                                    <input type="hidden" id="hiddenId" value='<%# Eval("Wall_ID") %>' runat="server" name="hiddenId" />
                                                    <asp:Label ID="lb_lst_account_ID" runat="server" Visible="False" Text='<%# Eval("AccountID") %>'/>
                                                </a>
                                                <div class="pull-right">
                                                <div class="btn-group" runat="server" ID="btngroup">
                                                    <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                                        <i class="fa fa-chevron-down"></i>
                                                    </button>
                                                    <ul class="dropdown-menu pull-right" role="menu">
                                                        <li style="margin-bottom: 0;padding-bottom: 5px;border-bottom: none">
                                                            <asp:Button ID="btnEditPost" runat="server" CommandName="_EditPost" Text="Sửa bài viết" CssClass="btn-link"/>
                                                        </li>
                                                        <li style="margin-bottom: 0;padding-bottom: 5px;border-bottom: none">
                                                            <asp:Button ID="btnDelPost" runat="server" CommandName="_DelPost" Text="Xoá bài viết" CssClass="btn-link"/>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            </div>
                                            <small class="text-muted">
                                                <i class="fa fa-clock-o"></i> <asp:Label ID="lb_lst_datebegntext" runat="server" Text="Đăng vào lúc :"/> <asp:Label ID="lb_lst_datebegin" runat="server" Text='<%# Eval("DateBegin","{0:dd-MM-yyyy}") %>'/> | 
                                                <i class="fa fa-clock-o" runat="server" ID="iconDateUpdate" Visible="False"/> <asp:Label ID="lb_lst_dateupdatetext" runat="server" Text="Thay đổi vào lúc :" Visible="False"/> <asp:Label ID="lb_lst_dateupdate" Visible="False" runat="server" Text='<%# Eval("DateUpdate","{0:dd-MM-yyyy}") %>'/>
                                                <asp:DropDownList ID="drPublic" runat="server" CssClass="btn btn-default btn-xs" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="1">Mọi người</asp:ListItem>
                                                    <asp:ListItem Value="2">Bạn bè</asp:ListItem>
                                                </asp:DropDownList>
                                            </small>
                                        </div>
                                    </li>
                                </ul>
                                <p style="font-weight: bold">
                                   <asp:Label ID="lb_lst_titile" runat="server" Text='<%# Eval("Wall_Titile") %>'/>
                                </p>
                            </div>
                            <div class="timeline-body">
                                <p style="text-align: justify">
                                    <asp:Label ID="lb_lst_Content" runat="server" Text='<%# Eval("Wall_Content") %>'/>
                                </p>
                            </div>
                        </div>

                        <div class="panel-footer">
                            <asp:Button ID="btnLike" runat="server" CssClass="btn btn-danger btn-xs search" CommandName="Like_lst" title="Thích" Text="Thích" />
                            <asp:Button ID="btnUnLike" runat="server" CssClass="btn btn-danger btn-xs search" CommandName="Unlike_lst" title="Bỏ thích" Text="Bỏ thích" />
                            <asp:Button ID="btnShare" runat="server" CssClass="btn btn-danger btn-xs search" CommandName="Share_lst" title="Chia sẻ" Text="Chia sẻ" />
                            <asp:Label ID="lb_lst_like" runat="server" Text='<%# Eval("LikeCount") %>'/> Lượt thích
                        </div>
                        
                        <div style="margin-top: 8px;margin-bottom: 8px;margin-left: 9px;">
                            <asp:Label ID="lbTotalComment" runat="server" Text="" Visible="False"/>
                            <asp:Button runat="server" ID="btnViewMoreComment" CommandName="_btnViewMoreComment" CssClass="btn btn-danger btn-xs" Text="Bình luận"/>
                        </div>

                        <div ID="PanelComment" runat="server" class="panel panel-default" style="margin-left: 10px;margin-top: 8px;width: 97.5%;">
                            <div class="panel-heading" style="font-weight: bold;color: #0000cd">
                                Bình luận
                            </div>
                            <asp:ListView ID="ListViewComment" runat="server" OnItemCommand="ListViewComment_ItemCommand">
                                <ItemTemplate>
                                    <div class='panel-body' style="padding: 0;padding-left: 8px;padding-top: 8px;">
                                         <div class='timeline'>
                                             <ul class='chat'>
                                                 <li class='left clearfix'>
                                                     <span class='chat-img pull-left'>
                                                         <img src='<%# Eval("User_Image") %>' style='width: 40px;height: 40px;' runat='server' ID='img1' class='img-rounded'/>
                                                     </span>
                                                     <div class='chat-body clearfix'>
                                                         <div class='header'>
                                                            <a href='/profice/<%# Eval("UserName") %>' style='font-weight: 600;color: #000000'>
                                                                <asp:Label ID='lbFullNameComment' runat='server' Text='<%# Eval("FullName") %>'/>
                                                                <asp:Label ID='lbAccountID' runat='server' Visible='False' Text='<%# Eval("AccountID") %>'/>
                                                                <asp:Label ID='lbCommentWall_ID' runat='server' Visible='False' Text='<%# Eval("WallComment_ID") %>'/>
                                                            </a>
                                                              <div class="pull-right" style="margin-right: 8px;">
                                                                    <div class="btn-group" runat="server" ID="btngroup">
                                                                        <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                                                            <i class="fa fa-chevron-down"></i>
                                                                        </button>
                                                                        <ul class="dropdown-menu pull-right" role="menu">
                                                                            <li style="margin-bottom: 0;padding-bottom: 5px;border-bottom: none">
                                                                                <asp:Button ID="btnDelComment" runat="server" CommandName="_DelComment" Text="Xoá bình luận" CssClass="btn-link"/>
                                                                            </li>
                                                                        </ul>
                                                                    </div>
                                                                </div>
                                                        </div>
                                                         <small class='text-muted'>
                                                            <i class='fa fa-clock-o'></i> Đăng vào ngày : <%# Eval("DateCreate","{0:dd-MM-yyyy}") %> | vào lúc : <%# Eval("DateCreate","{0:hh:mm}") %>
                                                        </small>
                                                     </div>
                                                 </li>
                                             </ul>
                                         </div>
                                         <div class='timeline-body'>
                                            <p style='text-align: justify'>
                                                <asp:Label ID='lbCommentContent' runat='server' Text='<%# Eval("Content") %>'/>
                                            </p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>

                        <div class="panel-footer">
                            <%=_ErrorComment %>
                            <div style="margin-top: 8px;margin-bottom: 8px;">
                                <asp:TextBox ID="txtWallComment" TextMode="MultiLine" CssClass="form-control" runat="server" Text='' placeholder="Viết lời bình luận..." />
                                <div style="padding-top: 5px;text-align: right">
                                    <asp:Button ID="InsertButton" CssClass="btn btn-danger btn-xs" runat="server" Text="Bình luận" CommandName="_btnInsert" />
                                </div>
                            <div class="clr"></div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
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
</div>

<%--Popup--%>
<div class="modal fade modal-width" id="myModalSendMessage" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header modal-header-background">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title modal-titile">Gửi tin nhắn</h4>
            </div>
            <asp:UpdatePanel ID="UpdatePanelSendMessage" runat="server">
            <ContentTemplate>
                <div class="modal-body modal-body-height" style="padding: 10px;">
                    <asp:Label ID="lbAccountID2" runat="server" Text="" Visible="False"/>
                    <asp:Label ID="lbFullNameMessage" runat="server" Text="" Visible="False"/>
                    <asp:Label ID="lbMsgSendMessage" runat="server" Text=""/>
                    <div class="form-group" style="margin-top: 10px;">
                        <textarea type="text" rows="3" class="form-control" runat="server" ID="txtMessage"/>
                    </div>
                    <div class="form-group">
                        <%=_ErrorPostMessage %>
                    </div>
                <div class="clr"></div>
                </div>
                <div class="modal-footer modal-footer-height">
                    <asp:Button ID="btnSendMessage" runat="server" CssClass="btn btn-danger btn-sm" style="margin-top: -15px;" Text="Gửi" OnClick="btnSendMessage_Click" />
                    <button type="button" class="btn btn-danger btn-sm" style="margin-top: -15px;" data-dismiss="modal">Đóng lại</button>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSendMessage" EventName="Click"/>
            </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<div class="modal fade modal-width" id="myModalStatusEdit" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header modal-header-background">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title modal-titile">Thay đổi trạng thái</h4>
            </div>
            <div class="modal-body modal-body-height" style="padding: 10px;">
                <asp:UpdatePanel ID="UpdatePanelWall" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbIDUserEdit" runat="server" Text="" Visible="False"></asp:Label>
                        <asp:Label ID="lbWallID" runat="server" Text="" Visible="False"></asp:Label>
                        <div class="form-group">
                            <input type="text" runat="server" class="form-control" ID="txtTitilePostEdit"/>
                        </div>
                        <div class="form-group">
                            <textarea type="text" rows="3" class="form-control" runat="server" ID="txtContentPostEdit"/>
                        </div>
                        <div class="form-group">
                            <%=_ErrorPostEdit %>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            <div class="clr"></div>
            </div>
            <div class="modal-footer modal-footer-height">
                <asp:UpdatePanel ID="UpdatePanelFooter" runat="server">
                    <ContentTemplate>
                        <button runat="server" ID="btnPostEdit" class="btn btn-danger btn-sm" style="margin-top: -15px;" OnServerClick="btnPostEdit_Click">Cập nhật</button>
                        <button type="button" class="btn btn-danger btn-sm" style="margin-top: -15px;" data-dismiss="modal">Đóng lại</button>
                 </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnPostEdit" EventName="ServerClick"/>
                    </Triggers>
                </asp:UpdatePanel>
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
<div class="modal fade" id="myModalDel" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header modal-header-background">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title modal-titile">Xóa bài viết</h4>
            </div>
            <div class="modal-body modal-body-height" style="padding: 10px;">
                <asp:UpdatePanel ID="UpdatePanelDelMain" runat="server">
                    <ContentTemplate>
                        <%=_ErrorDel %>
                        <asp:Label ID="lbUserIDDel" runat="server" Text="" Visible="False"/>
                        <asp:Label ID="lbWallIDDel" runat="server" Text="lbWallIDDel" Visible="False"/>
                        <asp:Label ID="lbMsgDel" runat="server" Text=""/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            <div class="clr"></div>
            </div>
            <div class="modal-footer modal-footer-height">
                <asp:UpdatePanel ID="UpdatePanelDelFooter" runat="server">
                    <ContentTemplate>
                        <button class="btn btn-danger btn-sm" style="margin-top: -20px;" runat="server" ID="btnDelStatus" OnServerClick="btnDelStatus_Click">Xoá bài viết</button>
                        <button type="button" class="btn btn-default btn-sm" style="margin-top: -20px;" data-dismiss="modal">Đóng lại</button>
                  </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnDelStatus" EventName="ServerClick"/>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
<%--End--%>
 <%--Process--%>
<asp:UpdateProgress ID="UpdateProgressNews" runat="server" AssociatedUpdatePanelID="UpdatePanelGrid">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-main">
                    <img src="../js/fancyBox/source/fancybox_loading.gif" style="padding: 10px;top:45%;left:50%;"/>
                    <span class="label label-danger">
                        Đang tải...
                    </span>  
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdateProgress ID="UpdateProgressContentFooter" runat="server" AssociatedUpdatePanelID="UpdatePanelContentFooter">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-main">
                    <img src="../js/fancyBox/source/fancybox_loading.gif" style="padding: 10px;top:45%;left:50%;"/>
                    <span class="label label-danger">
                        Đang tải...
                    </span>  
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdateProgress ID="UpdateProgressEditFooter" runat="server" AssociatedUpdatePanelID="UpdatePanelFooter">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-main">
                    <img src="../js/fancyBox/source/fancybox_loading.gif" style="padding: 10px;top:45%;left:50%;"/>
                    <span class="label label-danger">
                        Đang tải...
                    </span>  
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdateProgress ID="UpdateProgressDelFooter" runat="server" AssociatedUpdatePanelID="UpdatePanelDelFooter">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-main">
                    <img src="../js/fancyBox/source/fancybox_loading.gif" style="padding: 10px;top:45%;left:50%;"/>
                    <span class="label label-danger">
                        Đang tải...
                    </span>  
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdateProgress ID="UpdateProgressSendMessage" runat="server" AssociatedUpdatePanelID="UpdatePanelSendMessage">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-main">
                    <img src="../js/fancyBox/source/fancybox_loading.gif" style="padding: 10px;top:45%;left:50%;"/>
                    <span class="label label-danger">
                        Đang tải...
                    </span>  
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdateProgress ID="UpdateProgressbtnSendMessageClick" runat="server" AssociatedUpdatePanelID="UpdatePanelbtnSendMessageClick">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-main">
                    <img src="../js/fancyBox/source/fancybox_loading.gif" style="padding: 10px;top:45%;left:50%;"/>
                    <span class="label label-danger">
                        Đang tải...
                    </span>  
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdateProgress ID="UpdateProgressWallFollower" runat="server" AssociatedUpdatePanelID="UpdatePanelWallFollower">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-main">
                    <img src="../js/fancyBox/source/fancybox_loading.gif" style="padding: 10px;top:45%;left:50%;"/>
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