<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/webPages/masterPg.Master" AutoEventWireup="true" CodeBehind="mesasAdmin.aspx.cs" Inherits="myWaiter.Admin.webPages.mesasAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"><title>Mesas</title>
    <meta http-equiv="refresh" content="10" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <div id="header">
        Mesas
    </div>
    <br /><br />
    <div id="imgMesas">
        <ul id="ulImgs" runat="server">

        </ul>
    </div>
</asp:Content>
