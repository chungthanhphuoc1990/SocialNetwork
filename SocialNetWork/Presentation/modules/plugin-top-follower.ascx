<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="plugin-top-follower.ascx.cs" Inherits="Presentation.modules.plugin_top_follower" %>
<div class="chat-panel panel panel-danger">
    <div class="panel-heading">
        Theo dõi nhiều nhất
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
                                    <asp:Label ID="lbUrl" runat="server" Text='<%# Eval("User_Image") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="lbID" runat="server" Text="" Visible="False"></asp:Label>
                                </span>
                                <div class='chat-body clearfix'>
                                    <div class='header'>
                                        <a href="/profice/<%# Eval("UserName") %>" style="font-weight: bold;color: #3b5998;  font-family: helvetica, arial, 'lucida grande', sans-serif;font-size: 12px;">
                                            <asp:Label ID="lb_lst_FullName" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
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
            </asp:UpdatePanel>
        </ul>
        <div class="clearfix"></div>
    </div>
</div>