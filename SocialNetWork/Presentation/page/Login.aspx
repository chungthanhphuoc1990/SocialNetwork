<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentation.page.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chào mừng bạn đến với Social Network</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content="Chung Thành Phước"/>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap/dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../css/bootstrap-social/bootstrap-social.css" rel="stylesheet" />
    <%--End--%>
    
    <!-- Custom CSS -->
    <%--<link href="../css/dist/css/sb-admin-2.css" rel="stylesheet" />--%>
    <link href="../css/page/style.css" rel="stylesheet" />
    <%--End--%>
    
    <!-- Custom Fonts -->
    <link href="../css/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <%--End--%>
    
     <!-- jQuery -->
    <script src="../js/jquery-2.1.3.js"></script>
    <script src="../js/MyScript.js"></script>
    <script src="../js/Mask/jquery.maskedinput.js"></script>
    <%--PageLoad--%>
    <script>
        function pageLoad() {
            TooltipA(".deltotrash", "bottom");
            TooltipA(".btnAddNew", "bottom");
            TooltipA(".btnDel", "bottom");
            TooltipA(".btnSave", "bottom");
            TooltipA(".btnCancel", "bottom");
            TooltipA(".btnlist", "bottom");
            TooltipA(".refresh", "bottom");
            TooltipA(".btnSearch", "bottom");
            TooltipA(".textbox-search", "bottom");
            TooltipA(".dropdownlistfillter", "bottom");
            TooltipA(".btn-refresh", "right");
            TooltipA(".groupbutton", "bottom");
            TooltipA(".search", "bottom");
            TooltipA(".num", "bottom");
            MarkInputDay(".daytime");
        }
    </script>
    <%--End--%>
    
    <!-- Bootstrap Core JavaScript -->
    <script src="../css/bootstrap/dist/js/bootstrap.min.js"></script>
    <%--End--%>
</head>
<body style="background: #ffffff">
    <form id="formLoginPage" runat="server">
    <asp:ScriptManager runat="server"/>
        <nav class="navbar navbar-default navbar-fixed-top" style="background: #f2dede;">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="/">Social Network</a>
                </div>

                <div class="navbar-form navbar-right">
                    <div style="margin-right: 10px;">
                        <asp:Panel ID="PanelLogin" runat="server" DefaultButton="btnLogin">
                        <b style="font-weight: 500;font-family: sans-serif">Đăng nhập tài khoản :</b>
                        <input type="text" class="form-control" runat="server" ID="txtUserNameLogin" placeholder="Tên đăng nhập"/>
                        <input type="password" class="form-control" runat="server" ID="txtPasswordLogin" placeholder="Mật khẩu"/>
                        <asp:CheckBox ID="chkRemember" runat="server" /> Ghi nhớ
                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-danger btn-sm" Text="Đăng nhập" OnClick="btnLogin_Click" />
                    </asp:Panel>
                    </div>
                </div>
            </div>
        </nav>
        <div class="container" style="margin-top: 60px;">
            <div class="col-md-8">
                <div class="background-page-login-left"></div>
            </div>
            <div class="col-md-4">
                <%=_ErrorLogin %>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Đăng ký tài khoản
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <input type="text" class="form-control btn-refresh" title="Lưu ý : Tên đăng nhập phải không dấu và không có ký tự đặc biệt và nhỏ hơn 500 ký tự" runat="server" ID="txtUserName" placeholder="Tên đăng nhập"/>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control btn-refresh" title="Lưu ý : Tên đầy đủ không chứa ký tự đặc biệt và nhỏ hơn 500 ký tự" runat="server" ID="txtFullName" placeholder="Tên đầy đủ"/>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control btn-refresh" title="Lưu ý : Vui lòng điền Email thực của bạn,để chúng tôi có thể liên lạc và khắc phục sự cố giúp bạn" runat="server" ID="txtEmail" placeholder="Email"/>
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
                            <input type="password" class="form-control" runat="server" ID="txtPassword" placeholder="Mật khẩu"/>
                        </div>
                        <div class="form-group">
                            <%=_Error %>
                        </div>
                    </div>
                    <div class="panel-footer" style="text-align: right">
                        <button type="submit" class="btn btn-danger btn-sm" runat="server" ID="btnSigin" OnServerClick="btnSigin_Click">Đăng ký</button>
                        <button type="submit" class="btn btn-danger btn-sm" runat="server" ID="btnReset" OnServerClick="btnReset_Click">Làm lại</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>