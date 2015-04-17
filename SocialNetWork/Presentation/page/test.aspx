<%@ Page Title="" Language="C#" MasterPageFile="~/page/page-child.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Presentation.page.test" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../js/Choosen/My_Style.css" rel="stylesheet" />
    <link href="../js/Choosen/chosen.css" rel="stylesheet" />
    <script src="../js/Choosen/chosen.jquery.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CplChildPage" runat="server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</asp:Content>
