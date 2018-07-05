<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="myWaiter.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>myWaiter</title>
    <link href="../css/home.css" rel="stylesheet" />
    <script src="../../jquery-1.11.3.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <script>
            $(document).ready(function () {
                $("#imgLogar").click(function(){
                    $("#msgBox").css("visibility", "visible");
                    $("#main").css("opacity", 0.2);
                    $("#main").css("pointer-events", "none");
                })
            })
        </script>
        <div id="main">
        <div id="logo">
            <img src="images/logo.fw.png" height="350" />
        </div>
        <div id="formSection">
            <br />
            <asp:Image runat="server" ImageUrl="~/Admin/Home/images/txtLogin.fw.png" />
            <asp:TextBox ID="txtUser" CssClass="txt" MaxLength="50" Columns="20" runat="server" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
            <asp:Image runat="server" ImageUrl="~/Admin/Home/images/txtSenha.fw.png" />
            <asp:TextBox ID="txtPass" MaxLength="50" Columns="20" TextMode="Password" runat="server" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
            <hr id="lane"/>
            <asp:Label ID="lblErroLog" CssClass="label" runat="server">&nbsp</asp:Label><br /><br />
            <asp:Image ID="imgLogar" ImageUrl="../Home/images/btnOk.fw.png" CssClass="btns" runat="server" />
            
        </div>
        </div>
        <div id="msgBox">
            <div id="head">
                Atenção
            </div>
            <div id="body">
                <p>Deseja Continuar?</p>
            </div>
            <div id="feet">     
                <asp:ImageButton runat="server" ID="Cancelar" OnClick="No_Click" ImageUrl="~/Mobile/images/msgBox/btnCancelar.fw.png" />
                <asp:ImageButton runat="server" ID="Ok" OnClick="Yes_Click" ImageUrl="~/Mobile/images/msgBox/btnOk.fw.png" />
            </div>
        </div>
    </form>
    
</body>
</html>
