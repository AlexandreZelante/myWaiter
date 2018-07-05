<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paginaComandas.aspx.cs" Inherits="myWaiter.paginaComandas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>myWaiter</title>
    <link href="~/Mobile/css/comanda.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div id="backgroundComanda">

            <div id="barraUsuario">
                <p id="lblUsuario">Usuários</p>
            </div>

            <div id="divBotoes">
                <asp:Label ID="lblComandas" runat="server" Text="Não há comandas criadas!"></asp:Label>
            </div>

            <div id="logo">
            </div>

                <div id="txtbtn">
                    <asp:TextBox ID="txtNome" runat="server" MaxLength="15" onkeydown ="return(event.keyCode != 13);"></asp:TextBox>
                    <asp:Image ID="btnAdd2" ImageUrl="~/Mobile/images/paginaComandas/botaoAdd.fw.png" runat="server" CssClass="clickBtnComanda" />
                    <br /><br />
                    <asp:Label runat="server" Text="" ID="lblErro" ForeColor="White"></asp:Label>
                </div>

        </div>

        <div id="msgBoxComanda">

            <asp:Image ID="imgGarcom" CssClass="garcomMsgBox" runat="server" ImageUrl="~/Mobile/images/msgBox/garcomVectorMsgBox.fw.png" />

            <div id="msgtext" class="msgText" runat="server">
                <p>Tem certeza que deseja adicionar uma comanda?</p>
            </div>

            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Mobile/images/msgBox/btnCancelar.fw.png" />
            <asp:ImageButton ID="btnOk" runat="server" ImageUrl="~/Mobile/images/msgBox/btnOk.fw.png" OnClick="btnAdd_Click"  />
        </div>

        <script src="../../jquery-1.11.3.js"></script>
        <script>
            $(document).ready(function () {
                $(".clickBtnComanda").click(function () {
                    $("#msgBoxComanda").css("visibility", "visible");
                    $("#backgroundComanda").css("opacity", 0.2);
                    $("#backgroundComanda").css("pointer-events", "none");
                })
                function AlertBox() {
                    $("#msgBoxComanda").css("visibility", "visible");
                    $("#backgroundComanda").css("opacity", 0.2);
                    $("#backgroundComanda").css("pointer-events", "none");
                }
            })

            
        </script>
    </form>
</body>
</html>
