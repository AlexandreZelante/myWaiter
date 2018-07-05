<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagina1.aspx.cs" Inherits="myWaiter.pagina1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>myWaiter</title>
    <link href="~/Mobile/css/tutorial.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="background1">
        <asp:Image ID="ImageButton1" runat="server" ImageUrl="~/Mobile/images/pagina1/botaoUnica.fw.png" CssClass="clickContaUnica" />
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Mobile/images/pagina1/contaSeparada.fw.png"  PostBackUrl="~/Mobile/Pages/pagina2.aspx"/>
    </div>

        <div id="msgBoxComanda">

            <asp:Image ID="imgGarcom" CssClass="garcomMsgBox" runat="server" ImageUrl="~/Mobile/images/msgBox/garcomVectorMsgBox.fw.png" />

            <div id="msgtext" class="msgText" runat="server">
                <p>Tem certeza que deseja iniciar    uma conta única?</p>
            </div>

            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Mobile/images/msgBox/btnCancelar.fw.png"  />
            <asp:ImageButton ID="btnOk" runat="server" ImageUrl="~/Mobile/images/msgBox/btnOk.fw.png" OnClick="ImageButton1_Click" />
        </div>

        <script src="../../jquery-1.11.3.js"></script>
        <script>
            $(document).ready(function () {
                $(".clickContaUnica").click(function () {
                    $("#msgBoxComanda").css("visibility", "visible");
                    $("#background1").css("opacity", 0.2);
                    $("#background1").css("pointer-events", "none");
                })
            })        
        </script>
    </form>
</body>
</html>
