<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="plugin-profice.ascx.cs" Inherits="Presentation.modules.plugin_profice" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<div class="panel panel-danger">
  <div class="panel-heading">
    <h3 class="panel-title">Giới thiệu</h3>
  </div>
  <div class="panel-body">
    <!-- tabs left -->
    <div class="tabbable tabs-left">
        <div class="col-md-2">
            <ul class="nav nav-tabs">
                <li class="active">
                    <a href="#overview" data-toggle="tab">Tổng quan</a>
                </li>
                <li id="Li1" runat="server" Visible="False">
                    <a href="#WorkAndEducation" data-toggle="tab">Công việc và học vấn</a>
                </li>
                <li id="Li2" runat="server" Visible="False">
                    <a href="#Live" data-toggle="tab">Nơi bạn sống</a>
                </li>
                <li id="Li3" runat="server" Visible="False">
                    <a href="#Relationships" data-toggle="tab">Gia đình và mối quan hệ</a>
                </li>
                <li id="Li4" runat="server" Visible="False">
                    <a href="#DetailOfMe" data-toggle="tab">Chi tiết về bạn</a>
                </li>
            </ul>
        </div>
        <div class="col-md-10">
            <div class="tab-content">
                <asp:UpdatePanel ID="UpdatePanelProfice" runat="server">
                    <ContentTemplate>
                        <div class="tab-pane active" id="overview">
                            <div class="panel panel-danger">
                              <div class="panel-heading">
                                <h3 class="panel-title">Cập nhật thông tin cá nhân</h3>
                              </div>
                              <div class="panel-body">
                                <asp:Label ID="lbID" runat="server" Text="" Visible="False"></asp:Label>
                                <div class="form-group">
                                    <input type="text" class="form-control btn-refresh" title="Lưu ý : Tên đầy đủ không chứa ký tự đặc biệt và nhỏ hơn 500 ký tự" runat="server" ID="txtFullName" placeholder="Tên đầy đủ"/>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control btn-refresh" title="Lưu ý : Vui lòng điền Email thực của bạn,để chúng tôi có thể liên lạc và khắc phục sự cố giúp bạn" runat="server" ID="txtEmail" placeholder="Email"/>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control btn-refresh" runat="server" ID="txtCellPhone" placeholder="Điện thoại"/>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control daytime" runat="server" ID="txtBirthday" placeholder="Ngày sinh"/>
                                </div>
                                <div class="form-group">
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="rdMade" GroupName="Gender" runat="server" Text="Nam" Checked="True" />
                                    </label>
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="rdFeMade" GroupName="Gender" runat="server" Text="Nữ" />
                                    </label>
                                </div>
                                <div class="form-group">
                                    <label>Tải ảnh đại diện</label>
                                    <ajax:AsyncFileUpload OnClientUploadComplete="uploadComplete" runat="server" ID="AsyncFileUpload1"
                                        Width="100%" UploaderStyle="Traditional" CompleteBackColor="White" UploadingBackColor="#CCFFFF"
                                        ThrobberID="imgLoader" OnUploadedComplete="FileUploadComplete" OnClientUploadStarted = "uploadStarted" />
                                    <%--<ajax:AjaxFileUpload ID="AjaxFileUpload11" CssClass="uploadimg" runat="server" MaximumNumberOfFiles="1" AllowedFileTypes="jpg,jpeg,png,gif"
                                        ThrobberID="imgLoader" OnUploadedComplete="FileUploadComplete" OnClientUploadStarted = "uploadStarted" Width="100%"/>--%>
                                    <%--<ajax:AjaxFileUpload ID="AjaxFileUpload11" CssClass="uploadimg" runat="server" MaximumNumberOfFiles="1" AllowedFileTypes="jpg,jpeg,png,gif"
                                        OnUploadComplete="AjaxFileUploadEvent" Width="100%"/>--%>
                                    <asp:Label ID="lbPathImg" runat="server" Text="" Visible="False"></asp:Label>
                                    <asp:Label ID="lbDateBegin" runat="server" Text="" Visible="False"></asp:Label>
                                    <asp:Image ID="imgLoader" runat="server" ImageUrl="../js/fancyBox/source/fancybox_loading.gif" />
                                    <img ID = "imgDisplay" runat="server" alt="" src="" style = "display:none"/>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="drCountry" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                        <asp:ListItem Value="-1">--Chọn Quốc Gia--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="drLanguage" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                        <asp:ListItem Value="-1">--Chọn Ngôn Ngữ--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <%=_Error %>
                                </div>
                              </div>
                              <div class="panel-footer" style="text-align: right">
                                <button type="submit" class="btn btn-danger btn-sm" runat="server" ID="btnSigin" OnServerClick="btnUpdate_Click">Cập nhật</button>
                              </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSigin" EventName="ServerClick"/>
                    </Triggers>
                </asp:UpdatePanel>
                <div class="tab-pane" id="WorkAndEducation">
                    Công việc và học vấn
                </div>
                <div class="tab-pane" id="Live">
                    Nơi bạn sống
                </div>
                <div class="tab-pane" id="Relationships">
                    Gia đình và mối quan hệ
                </div>
                <div class="tab-pane" id="DetailOfMe">
                    Chi tiết về bạn
                </div>
            </div>
        </div>
        <div class="clr"></div>
    </div>
    <!-- /tabs -->
  </div>
</div>
 <%--Process--%>
<asp:UpdateProgress ID="UpdateProgressProfice" runat="server" AssociatedUpdatePanelID="UpdatePanelProfice">
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
<script type="text/javascript">
    function uploadStarted() {
        $get("<%= imgDisplay.ClientID %>").style.display = "none";
    }
    function uploadComplete(sender, args) {
        var imgDisplay = $get("<%= imgDisplay.ClientID %>");
        imgDisplay.src = "images/loader.gif";
        imgDisplay.style.cssText = "";
        var img = new Image();
        img.onload = function () {
            imgDisplay.style.cssText = "height:150px;width:150px";
            imgDisplay.src = img.src;
        };
        img.src = "<%=ResolveUrl(UploadFolderPath) %>" + args.get_fileName();
    }
</script>