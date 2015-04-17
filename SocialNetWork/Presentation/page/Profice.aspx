<%@ Page Title="" Language="C#" MasterPageFile="~/page/page-child.Master" AutoEventWireup="true" CodeBehind="Profice.aspx.cs" Inherits="Presentation.page.Profice" %>
<%@ Register Src="~/modules/plugin-profice.ascx" TagPrefix="uc1" TagName="pluginprofice" %>
<asp:Content ID="Chead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="CplChildPage" ContentPlaceHolderID="CplChildPage" runat="server">
<uc1:pluginprofice runat="server" id="pluginprofice" />
</asp:Content>