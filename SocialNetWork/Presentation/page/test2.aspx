<%@ Page Title="" Language="C#" MasterPageFile="~/page/page-child.Master" AutoEventWireup="true" CodeBehind="test2.aspx.cs" Inherits="Presentation.page.test2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CplChildPage" runat="server">
    <a href="?lang=en" runat="server" id="linkEnglishLang">
        <asp:Literal ID="Literal1" runat="server" Text="<%$Resources:English.language, langEnglish%>" /></a>
    <a href="?lang=vi" runat="server" id="linkVietnameseLang">
        <asp:Literal ID="Literal2" runat="server" Text="<%$Resources:English.language, langVietnamese%>" /></a>
<asp:Button ID="InsertButton" CssClass="btn btn-danger btn-xs" runat="server" Text="<%$Resources:English.language, langPostcomment%>"/>
</asp:Content>
