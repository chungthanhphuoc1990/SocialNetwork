<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="slidebar.aspx.cs" Inherits="Presentation.page.slidebar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="Chung Thành Phước" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap/dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../css/bootstrap-social/bootstrap-social.css" rel="stylesheet" />
    <%--End--%>

    <!-- Custom CSS -->
    <link href="../css/dist/css/sb-admin-2.css" rel="stylesheet" />
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

    <%--Fancybox--%>
    <script src="../js/fancyBox/lib/jquery.mousewheel-3.0.6.pack.js"></script>
    <link href="../js/fancyBox/source/jquery.fancybox.css" rel="stylesheet" />
    <script src="../js/fancyBox/source/jquery.fancybox.pack.js"></script>

    <link href="../js/fancyBox/source/helpers/jquery.fancybox-buttons.css" rel="stylesheet" />
    <script src="../js/fancyBox/source/helpers/jquery.fancybox-buttons.js"></script>
    <script src="../js/fancyBox/source/helpers/jquery.fancybox-media.js"></script>

    <link href="../js/fancyBox/source/helpers/jquery.fancybox-thumbs.css" rel="stylesheet" />
    <script src="../js/fancyBox/source/helpers/jquery.fancybox-thumbs.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".imgfancy").fancybox({
                openEffect: 'elastic',
                closeEffect: 'elastic',

                helpers: {
                    title: {
                        type: 'inside'
                    }
                }
            });
            $(".fancybox-button").fancybox({
                prevEffect: 'none',
                nextEffect: 'none',
                closeBtn: false,
                helpers: {
                    title: { type: 'inside' },
                    buttons: {}
                }
            });
            $('.fancybox-media').fancybox({
                openEffect: 'none',
                closeEffect: 'none',
                helpers: {
                    media: {}
                }
            });
            $(".fancybox").fancybox({
                openEffect: 'elastic',
                closeEffect: 'elastic',
                autoSize: true,
                type: 'iframe',
                iframe: {
                    preload: false // fixes issue with iframe and IE
                }
            });
            $(".gallerypdf").click(function () {
                $.fancybox({
                    type: 'html',
                    autoSize: false,
                    content: '<embed src="' + this.href + '#nameddest=self&page=1&view=FitH,0&zoom=80,0,0" type="application/pdf" height="99%" width="100%" />',
                    beforeClose: function () {
                        $(".fancybox-inner").unwrap();
                    }
                }); //fancybox
                return false;
            }); // pdf 
            $("#DialogLink").fancybox({
                openEffect: 'elastic',
                closeEffect: 'elastic',

                helpers: {
                    title: {
                        type: 'inside'
                    }
                }
            }).trigger("click"); //Adv
        });
    </script>
    <%--End--%>

    <!-- Bootstrap Core JavaScript -->
    <script src="../css/bootstrap/dist/js/bootstrap.min.js"></script>
    <%--End--%>

    <!-- Custom Theme JavaScript -->
    <script src="../js/sb-admin-2.js"></script>
    <%--End--%>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="../css/metisMenu/dist/metisMenu.js"></script>
    <%--PageLoad--%>
    <script>
        function pageLoad() {
            TooltipA(".btnCloseFormedit", "right");
            TooltipA("#btnCloseForm", "right");
            TooltipA("#btnCloseFormedit", "right");
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
    <style>
        body {
            padding-bottom: 40px;
            padding-top: 60px;
        }

        .sidebar-nav-fixed {
            width: 20%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar navbar-fixed-top navbar-default">
            <div class="container">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">Project name</a><a class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="glyphicon glyphicon-bar"></span>
                        <span class="glyphicon glyphicon-bar"></span>
                        <span class="glyphicon glyphicon-bar"></span>
                    </a>
                </div>
                <div class="navbar-collapse">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="#">Home</a>
                        </li>
                        <li><a href="#about">About</a>
                        </li>
                        <li><a href="#contact">Contact</a>
                        </li>
                    </ul>

                </div>
                <!--/.navbar-collapse -->
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <div class="sidebar-nav-fixed affix">
                        <div class="well">
                            <ul class="nav ">
                                <li class="nav-header">Sidebar</li>
                                <li class="active"><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li class="nav-header">Sidebar</li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li class="nav-header">Sidebar</li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                            </ul>
                        </div>
                        <!--/.well -->
                    </div>
                    <!--/sidebar-nav-fixed -->
                </div>
                <!--/span-->
                <div class="col-md-6">
                    <div class="jumbotron">
                        <h1>Hello, world!</h1>

                        <p>
                            This is a template for a simple marketing or informational website. It
                    includes a large callout called the hero unit and three supporting pieces
                    of content. Use it as a starting point to create something more unique.
                        </p>
                        <p>
                            <a class="btn btn-primary btn-lg">Learn more »</a>
                        </p>
                    </div>
                    <div class="jumbotron">
                        <h1>Hello, world!</h1>

                        <p>
                            This is a template for a simple marketing or informational website. It
                    includes a large callout called the hero unit and three supporting pieces
                    of content. Use it as a starting point to create something more unique.
                        </p>
                        <p>
                            <a class="btn btn-primary btn-lg">Learn more »</a>
                        </p>
                    </div>
                    <div class="jumbotron">
                        <h1>Hello, world!</h1>

                        <p>
                            This is a template for a simple marketing or informational website. It
                    includes a large callout called the hero unit and three supporting pieces
                    of content. Use it as a starting point to create something more unique.
                        </p>
                        <p>
                            <a class="btn btn-primary btn-lg">Learn more »</a>
                        </p>
                    </div>
                    <div class="jumbotron">
                        <h1>Hello, world!</h1>

                        <p>
                            This is a template for a simple marketing or informational website. It
                    includes a large callout called the hero unit and three supporting pieces
                    of content. Use it as a starting point to create something more unique.
                        </p>
                        <p>
                            <a class="btn btn-primary btn-lg">Learn more »</a>
                        </p>
                    </div>
                    <div class="jumbotron">
                        <h1>Hello, world!</h1>

                        <p>
                            This is a template for a simple marketing or informational website. It
                    includes a large callout called the hero unit and three supporting pieces
                    of content. Use it as a starting point to create something more unique.
                        </p>
                        <p>
                            <a class="btn btn-primary btn-lg">Learn more »</a>
                        </p>
                    </div>
                    <div class="jumbotron">
                        <h1>Hello, world!</h1>

                        <p>
                            This is a template for a simple marketing or informational website. It
                    includes a large callout called the hero unit and three supporting pieces
                    of content. Use it as a starting point to create something more unique.
                        </p>
                        <p>
                            <a class="btn btn-primary btn-lg">Learn more »</a>
                        </p>
                    </div>
                    <div class="jumbotron">
                        <h1>Hello, world!</h1>

                        <p>
                            This is a template for a simple marketing or informational website. It
                    includes a large callout called the hero unit and three supporting pieces
                    of content. Use it as a starting point to create something more unique.
                        </p>
                        <p>
                            <a class="btn btn-primary btn-lg">Learn more »</a>
                        </p>
                    </div>
                </div>
                <!--/span-->
                <div class="col-md-3">
                    <div class="sidebar-nav-fixed pull-right affix">
                        <div class="well">
                            <ul class="nav ">
                                <li class="nav-header">Sidebar</li>
                                <li class="active"><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li class="nav-header">Sidebar</li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li class="nav-header">Sidebar</li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                                <li><a href="#">Link</a>
                                </li>
                            </ul>
                        </div>
                        <!--/.well -->
                    </div>
                    <!--/sidebar-nav-fixed -->
                </div>
                <!--/span-->
            </div>
            <!--/row-->

            <footer>
                <p>© Company 2012</p>
            </footer>
        </div>
        <!--/.fluid-container-->
    </form>
</body>
</html>
