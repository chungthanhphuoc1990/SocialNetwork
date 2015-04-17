<%@ Page Title="" Language="C#" MasterPageFile="~/page/page-child.Master" AutoEventWireup="true" CodeBehind="page-childs.aspx.cs" Inherits="Presentation.page.page_childs" %>

<%@ Register Src="~/modules/plugin-pagechild-center.ascx" TagPrefix="uc1" TagName="pluginpagechildcenter" %>
<asp:Content ID="Chead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="CplChildPage" ContentPlaceHolderID="CplChildPage" runat="server">
    <uc1:pluginpagechildcenter runat="server" ID="pluginpagechildcenter" />
</asp:Content>
