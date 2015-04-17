<%@ Page Title="" Language="C#" MasterPageFile="~/page/PresentationPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentation.Default" %>
<%@ Register Src="~/modules/plugin-center.ascx" TagPrefix="uc1" TagName="plugincenter" %>
<asp:Content ID="Chead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="CPl" ContentPlaceHolderID="CPl" runat="server">
<uc1:plugincenter runat="server" id="plugincenter" />
</asp:Content>